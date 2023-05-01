using EmployeeManagement.Controllers;
using EmployeeManagement.Model;
using EmployeeManagement.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeManagementTests.Controllers
{
    public class PromotionsControllerTests
    {
        [Fact]
        public async Task External_employee_promotion_should_return_badrequest()
        {
            //Arrange
            var employeeService_Mock = new Mock<IEmployeeService>();
            var promotionService_Mock = new Mock<IPromotionService>();

            var sut = new PromotionsController(employeeService_Mock.Object, promotionService_Mock.Object);

            //Act
            var result = await sut.CreatePromotion(new PromotionForCreationDto());

            //Assert
            result.Should().BeOfType<BadRequestResult>();
            employeeService_Mock.Verify(x => x.FetchInternalEmployeeAsync(It.IsAny<int>()), Times.Once);
            promotionService_Mock.Verify(x => x.PromoteInternalEmployeeAsync(It.IsAny<InternalEmployee>()), Times.Never);
        }

        [Fact]
        public async Task Internal_employee_promotion_should_return_Ok()
        {
            //Arrange
            var internalEmployee = new InternalEmployee()
            {
                EmployeeId = 1,
                JobLevel = 1
            };

            var employeeService_Stub = new Mock<IEmployeeService>();
            var promotionService_Stub = new Mock<IPromotionService>();

            employeeService_Stub.Setup(x => x.FetchInternalEmployeeAsync(It.IsAny<int>())).ReturnsAsync(internalEmployee);

            promotionService_Stub.Setup(x => x.PromoteInternalEmployeeAsync(It.IsAny<InternalEmployee>())).ReturnsAsync(true);

            var sut = new PromotionsController(employeeService_Stub.Object, promotionService_Stub.Object);

            //Act
            var result = await sut.CreatePromotion(new PromotionForCreationDto() { EmployeeId = 1 });

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            employeeService_Stub.Verify(x => x.FetchInternalEmployeeAsync(It.IsAny<int>()), Times.Once);
            promotionService_Stub.Verify(x => x.PromoteInternalEmployeeAsync(It.IsAny<InternalEmployee>()), Times.Once);
        }
    }
}