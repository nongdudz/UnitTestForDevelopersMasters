using EmployeeService.DataAccess.Entities;
using FluentAssertions;
using Xunit;
using static EmployeeService.Services.NamingUnitTestAndApplyingAAATest;

namespace EmployeeServiceTests
{
    public class EmployeeFactoryTests
    {
        [Fact]
        public void Create_internal_employee_should_return_employee_details_with_default_values()
        {
            //Arrange
            var firstName = "Edu";
            var lastName = "Bayns";

            var sut = new  EmployeeFactory();

            //Act
            InternalEmployee result = (InternalEmployee) sut.CreateEmployee(firstName, lastName);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<InternalEmployee>();
            result.FirstName.Should().Be(firstName);
            result.LastName.Should().Be(lastName);
            result.YearsInService.Should().Be(0);
            result.Salary.Should().Be(2500);
            result.MinimumRaiseGiven.Should().BeFalse();
            result.JobLevel.Should().Be(1);
        }

        [Fact]
        public void Create_external_employee_with_valid_information_should_return_null_company_information()
        {
            //Arrange
            var firstName = "Edu";
            var lastName = "Bayns";
            var company = "CSV";

            var sut = new EmployeeFactory();

            //Act
            ExternalEmployee result = (ExternalEmployee)sut.CreateEmployee(firstName, lastName, company , true);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ExternalEmployee>();
            result.FirstName.Should().Be(firstName);
            result.LastName.Should().Be(lastName);
            result.Company.Should().BeNull();
        }
    }
}