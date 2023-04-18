using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeServiceTests
{
    public class StateBasedTest
    {
        [Fact]
        public void WhenCreateEmployeeIsCalled_ItShouldVerifyTheLatestAddedFirstName()
        {
            //Question: Create a state based test
            //Arrange
            var employee = new Employee
            {
                Id = 2,
                FirstName = "Ed",
                LastName = "Bayns",
                Email = "ed.bayns@softvision.com",
                Salary = 25000.00
            };

            var employeeRepository = new EmployeeRepository();

            //Act
            employeeRepository.CreateEmployee(employee);
            var createdEmployee = employeeRepository.GetEmployees();

            //Assert
            createdEmployee.Count().Should().Be(2);
            createdEmployee[1].Id.Should().Be(2);
        }


        public class EmployeeRepository
        {
            public Employee? GetEmployee(int employeeId)
            {
                return Db.Employees.FirstOrDefault(x => x.Id == employeeId);
            }

            public List<Employee> GetEmployees()
            {
                return Db.Employees.ToList();
            }

            public void CreateEmployee(Employee employee)
            {
                Db.CreateEmployee(employee);
            }

        }

        public class Db
        {
            public static List<Employee> Employees = new List<Employee> {
            new Employee()
            {
                Id = 1,
                FirstName = "Juan",
                LastName = "Dela Cruz",
                Email = "juan.delacruz@softvision.com",
                Salary = 25000.00
            } };

            public static void CreateEmployee(Employee employee)
            {
                Db.Employees.Add(employee);
            }
        }

        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public double Salary { get; set; }
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
}

