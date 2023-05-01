using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeServiceTests
{
    public class CommunicationBasedTests
    {
        [Fact]
        public void WhenSendEmailIsCalled__ItShouldVerifyOnce()
        {
            var to = "me@softvision.com";
            var subject = "Unit test Subject";
            var body = "Unit test body";
            var emailService = new Mock<IEmailService>();

            // Act
            emailService.Object.SendEmail(to, subject, body);

            // Assert
            emailService.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
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
                Email = "juan.delacruz@softvision.com",
                Salary = 25000.00
            } };
        }

        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public double Salary { get; set; }
        }


        public interface IEmailService
        {
            bool SendEmail(string to, string subject, string body);
        }
        public class EmailService : IEmailService
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
}
