using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace EmployeeServiceTests
{
    public class Session7Tests
    {
        [Fact]
        public void Process_saved_order_and_apply_discount()
        {
            //Arrage
            decimal expectedValue = 78;
            var messageBusMock = new Mock<MessageBus>();
            var databaseMock = new Mock<Database>();

            var controller = new OrdersController(messageBusMock.Object, databaseMock.Object);

            //Act
            var result = controller.ProcessOrder(1);

            //Assert
            Assert.NotNull(result);
            result.TotalPrice.Should().Be(expectedValue);
        }

        [Fact]
        public void Domain_event_should_return_data()
        {
            //Arrange
            var database = new Database();
            int orderId = 1;
            int totalPrice = 156;
            var data = database.GetOrderByOrderId(orderId);
            data.TotalPrice = totalPrice;

            //Act
            data.ApplyDiscount(LoyaltyLevel.Gold, totalPrice);

            //Assert
            data.ProcessOrderEvent.Should().NotBeEmpty();
            data.ProcessOrderEvent.Should().HaveCount(1);
        }
    }

    public class ProcessOrderEvent
    {
        public int OrderId { get; set; }
        public string Message { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<int> ProductIds { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProcessOrderEvent> ProcessOrderEvent { get; private set; }

        public Order(int orderId, int customerId, decimal totalPrice)
        {
            OrderId = orderId;
            CustomerId = customerId;
            TotalPrice = totalPrice;
            ProductIds = new List<int>();
            ProcessOrderEvent = new List<ProcessOrderEvent>();
        }

        public decimal GetTotalPrice(List<object[]> productDatas)
        {
            decimal totalPrice = 0;
            foreach (var productData in productDatas)
            {
                totalPrice += (decimal)productData[0].GetType().GetProperty("price").GetValue(productData[0], null);
            }

            return totalPrice;
        }

        public decimal ApplyDiscount(LoyaltyLevel loyaltyLevel, decimal totalPrice)
        {
            decimal discountedPrice;
            switch (loyaltyLevel)
            {
                case LoyaltyLevel.Bronze:
                    discountedPrice = totalPrice * 0.70m;
                    break;

                case LoyaltyLevel.Silver:
                    discountedPrice = totalPrice * 0.60m;
                    break;

                case LoyaltyLevel.Gold:
                    discountedPrice = totalPrice * 0.50m;
                    break;

                default:
                    discountedPrice = totalPrice;
                    break;
            };

            ProcessOrderEvent.Add(new() { OrderId = OrderId, Message = $"Old price: {totalPrice}, Discounted Price: {discountedPrice}" });

            return discountedPrice;
        }
    }

    public enum LoyaltyLevel
    {
        Bronze,
        Silver,
        Gold
    }

    public interface IMessageBus
    {
        void Send(int orderId, string message);
    }

    public class MessageBus : IMessageBus
    {
        public void Send(int orderId, string message)
        {
            Console.WriteLine($"Message Sent!\r\n\r\n{orderId} {message}");
        }
    }

    public interface IDatabase
    {
        public Order GetOrderByOrderId(int orderId);

        public object[] GetCustomerByCustomerId(object customerId);

        public List<object[]> GetProducts(List<int> productIds);

        public void SaveOrder(Order order);
    }

    public class Database : IDatabase
    {
        public Order GetOrderByOrderId(int orderId)
        {
            return new(orderId, 1, 0)
            {
                ProductIds = new List<int>() { 1, 2, 3 },
            };
        }

        public object[] GetCustomerByCustomerId(object customerId)
        {
            var dynamicObject = new { level = LoyaltyLevel.Gold, name = "John Rimorin", customerId };
            return new object[] { dynamicObject };
        }

        public List<object[]> GetProducts(List<int> productIds)
        {
            var products = new List<object[]>();
            foreach (var id in productIds)
            {
                var dynamicObject = new { productId = id, name = $"test product{id}", price = (50m + id) };
                products.Add(new object[] { dynamicObject });
            }
            return products;
        }

        public void SaveOrder(Order order)
        {
        }
    }

    public class OrderFactory
    {
        public static Order Create(Order order)
        {
            return new(order.OrderId, order.CustomerId, order.TotalPrice) { ProductIds = order.ProductIds };
        }
    }

    public class OrdersController
    {
        private readonly IDatabase _database;
        private readonly IMessageBus _messageBus;

        public OrdersController(IMessageBus messageBus, IDatabase database)
        {
            _messageBus = messageBus;
            _database = database;
        }

        public Order ProcessOrder(int orderId)
        {
            var orderData = _database.GetOrderByOrderId(orderId);
            var order = OrderFactory.Create(orderData);

            var customerData = _database.GetCustomerByCustomerId(order.CustomerId);
            var productDatas = _database.GetProducts(order.ProductIds);

            LoyaltyLevel loyaltyLevel = (LoyaltyLevel)customerData[0].GetType().GetProperty("level").GetValue(customerData[0], null);
            decimal totalPrice = order.GetTotalPrice(productDatas);
            totalPrice = order.ApplyDiscount(loyaltyLevel, totalPrice);

            order.TotalPrice = totalPrice;

            _database.SaveOrder(orderData);
            foreach (ProcessOrderEvent ev in order.ProcessOrderEvent)
            {
                _messageBus.Send(ev.OrderId, ev.Message);
            }

            return order;
        }
    }
}