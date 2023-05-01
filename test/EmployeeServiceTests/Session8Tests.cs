using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EmployeeServiceTests
{
    public class Session8Tests
    {
        [Fact]
        public void AddEmployee_ShouldInsertEmployeeAndSendEmail()
        {
            //make sure you mock the emailService and use concrete for employee repository
            // Arrange
            Employee employee = new() { Name = "Edu Bayno", Email = "edub@example.com" };
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            var emailServiceMock = new Mock<IEmailService>();

            employeeRepositoryMock.Setup(x => x.AddEmployee(It.IsAny<Employee>()));
            emailServiceMock.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            var employeeService = new EmployeeService(employeeRepositoryMock.Object, emailServiceMock.Object);

            //Act
            employeeService.AddEmployee(employee);

            //Assert
            employeeRepositoryMock.Verify(x => x.AddEmployee(employee), Times.Once);
            emailServiceMock.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        public class Employee
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        // EmployeeRepository.cs
        public interface IEmployeeRepository
        {
            void AddEmployee(Employee employee);
        }

        public class EmployeeRepository : IEmployeeRepository
        {
            private List<Employee> _employees;

            public EmployeeRepository()
            {
                _employees = new List<Employee>();
            }

            public void AddEmployee(Employee employee)
            {
                _employees.Add(employee);
            }

            public Employee GetByEmail(string email)
            {
                return _employees.FirstOrDefault(e => e.Email == email);
            }
        }

        // EmailService.cs
        public interface IEmailService
        {
            void SendEmail(string to, string subject, string body);
        }

        public class EmailService : IEmailService
        {
            public void SendEmail(string to, string subject, string body)
            {
                // Send email
                // ...
            }
        }

        // EmployeeService.cs
        public class EmployeeService
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IEmailService _emailService;

            public EmployeeService(IEmployeeRepository employeeRepository, IEmailService emailService)
            {
                _employeeRepository = employeeRepository;
                _emailService = emailService;
            }

            public void AddEmployee(Employee employee)
            {
                _employeeRepository.AddEmployee(employee);

                // Send email notification
                string subject = "New Employee Added";
                string body = $"Dear {employee.Name}, a new employee record has been added for you.";
                _emailService.SendEmail(employee.Email, subject, body);
            }
        }
    }
}