using EmployeeService.Model;
using System.Collections.Generic;
using Xunit;
using EmployeeSrv = EmployeeService.Services;

namespace EmployeeServiceTests.Services
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void CreateEmployeeShouldBeSuccessful()
        {
            //Arrange
            EmployeeSrv.EmployeeService employeeService = new EmployeeSrv.EmployeeService();

            //Act
            var result = employeeService.CreateEmployee(new Employee { EmployeeId = 1, FirstName = "Edu", LastName = "Bayns" });

            //Assert
            Assert.True(result > 0);
        }

        [Fact]
        public void GetEmployeeByIdShouldBeSuccessful()
        {
            //Arrange
            EmployeeSrv.EmployeeService employeeService = new EmployeeSrv.EmployeeService();

            //Act
            var result = employeeService.GetEmployeeById(1);

            //Assert
            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result.FirstName));
            Assert.True(!string.IsNullOrEmpty(result.MiddleName));
            Assert.True(!string.IsNullOrEmpty(result.LastName));
        }

        [Fact]
        public void GetEmployeesShouldBeSuccessful()
        {
            //Arrange
            EmployeeSrv.EmployeeService employeeService = new EmployeeSrv.EmployeeService();

            //Act
            var results = (List<Employee>)employeeService.GetEmployees();

            //Assert
            Assert.NotNull(results);
            var result = results[0];
            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result.FirstName));
            Assert.True(!string.IsNullOrEmpty(result.MiddleName));
            Assert.True(!string.IsNullOrEmpty(result.LastName));
        }
    }
}