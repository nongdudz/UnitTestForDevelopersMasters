using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using EmployeeManagement.Services;
using FluentAssertions;
using Moq;
using Moq.Protected;
using System.Net;

namespace EmployeeManagementTests.Services
{
    public class PromotionServiceTests
    {
        [Fact]
        public async Task Promote_internal_employee_should_return_true()
        {
            //Arrange
            var internalEmployee = new InternalEmployee
            {
                EmployeeId = 1,
                JobLevel = 1
            };

            var messageHandler = new Mock<HttpMessageHandler>();
            messageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                                              ItExpr.IsAny<HttpRequestMessage>(),
                                              ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"eligibleForPromotion\": true}")
                });

            var employeegementRepository_Mock = new Mock<IEmployeeRepository>();
            var httpClient_Stub = new HttpClient(messageHandler.Object);

            var sut = new PromotionService(httpClient_Stub, employeegementRepository_Mock.Object);

            //Act
            var response = await sut.PromoteInternalEmployeeAsync(internalEmployee);

            //Assert
            response.Success.Should().BeTrue();
            internalEmployee.JobLevel.Should().Be(2);
        }

        [Fact]
        public async Task Promotion_service_should_throw_exception_when_httpClient_is_unreachable()
        {
            //Arrange
            var employeegementRepository_Mock = new Mock<IEmployeeRepository>();
            var httpClient = new HttpClient();

            var sut = new PromotionService(httpClient, employeegementRepository_Mock.Object);

            //Act
            Func<Task<Result>> service = () => sut.PromoteInternalEmployeeAsync(new InternalEmployee());

            //Assert
            await service.Should().ThrowAsync<Exception>();
            employeegementRepository_Mock.Verify(x => x.SaveChangesAsync(), Times.Never);
        }
    }
}