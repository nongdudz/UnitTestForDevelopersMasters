using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace EmployeeServiceTests
{
    public class ResistanceToRefactoringTests
    {
        [Fact]
        public void GetUserEmployeeTest()
        {
            // Arrange
            var repository = new EmployeeRepository();
            var employeeId = 1;

            // Act
            var result = repository.GetEmployee(employeeId);

            // Assert - Answer Here
            Assert.NotNull(result);
            Assert.Equal(employeeId, result.Id);
            result.LastName.Should().NotBeNullOrEmpty();
            result.FirstName.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void EmailServiceTest()
        {
            //QUESTION
            // Arrange
            var emailService = new EmailService();
            var to = "test@example.com";
            var subject = "Test Email";
            var body = "This is a test email.";

            // Act
           bool emailSent = emailService.SendEmail(to, subject, body);

            // Assert - Answer Here
            Assert.True(emailSent);
        }
    }

    public class EmployeeRepository
    {
        public Employee? GetEmployee(int employeeId)
        {
            return Db.Employees.FirstOrDefault(x => x.Id == employeeId);
        }
    }

    public class Db
    {
        public static Employee[] Employees = new Employee[] {
            new Employee()
            {
                Id = 1,
                FirstName = "Juan",
                LastName = "Dela Cruz",
                Email = "juan.delacruz@softvision.com"
            } };
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class EmailService
    {
        public bool SendEmail(string to, string subject, string body)
        {
            var mailserver = new MailServer();
            var sent = mailserver.Send(to, subject, body);
            return sent;
        }
    }

    public class MailServer
    {
        internal bool Send(string to, string subject, string body)
        {
            if (subject == "Test Email" && !string.IsNullOrEmpty(to) && !string.IsNullOrEmpty(body))
            {
                return true;
            }

            throw new Exception("Something is wrong");
        }
    }
}