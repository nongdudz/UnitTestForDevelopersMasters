using EmployeeService.Interface;
using EmployeeService.Repository.Interface;
using EmployeeService.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeServiceTests.Services
{
    public class EmployeeAttendanceTests
    {
        [Fact]
        public void SaveAttendanceShouldReturnTrue()
        {
            //Arrange
            var employeeAttendanceRepoMock = new Mock<IEmployeeAttendanceRepo>();
            var employeeServiceMock = new Mock<IEmployeeService>();

            employeeAttendanceRepoMock.Setup(x => x.SaveInOut(It.IsAny<int>())).Returns(true);

            employeeServiceMock.Setup(x => x.EmployeeExist(It.IsAny<int>())).Returns(true);

            var service = new EmployeeAttendanceService(employeeAttendanceRepoMock.Object, employeeServiceMock.Object);

            //Act
            var result = service.SaveAttendance(1);

            //Assert
            Assert.True(result);
            employeeAttendanceRepoMock.Verify(x => x.SaveInOut(It.IsAny<int>()), Times.Once);

        }

        [Fact]
        public void SaveAttendanceShouldReturnFalse()
        {
            //Arrange
            var employeeAttendanceRepoMock = new Mock<IEmployeeAttendanceRepo>();
            var employeeServiceMock = new Mock<IEmployeeService>();

            employeeServiceMock.Setup(x => x.EmployeeExist(It.IsAny<int>())).Returns(false);

            var service = new EmployeeAttendanceService(employeeAttendanceRepoMock.Object, employeeServiceMock.Object);

            //Act
            var result = service.SaveAttendance(1);

            //Assert
            Assert.False(result);
            employeeAttendanceRepoMock.Verify(x => x.SaveInOut(It.IsAny<int>()), Times.Never);
        }
    }
}
