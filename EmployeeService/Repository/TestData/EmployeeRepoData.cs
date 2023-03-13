using EmployeeService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Repository.TestData
{
    public class EmployeeRepoData
    {
        public IEnumerable<Employee> _EmployeeList;

        public EmployeeRepoData()
        {
            SetEmployees();
        }

        private void SetEmployees()
        {
            var employees = new List<Employee>();

            employees.Add(new Employee
            {
                EmployeeId = 1,
                EmployeeTypeId = 1,
                FirstName = "TestFirst",
                LastName = "TestLast",
                MiddleName = "TestMiddle",
                DateOfBirth = new DateTime(1990, 1, 1),
                CreateDate = DateTime.Now,

                EmployeeAddress = new EmployeeAddress
                {
                    AddressId = 1,
                    EmployeeId = 1,
                    ContactId = 1,
                    HomeAddress = "Add1",
                    OfficeAddress = "Office1"
                },

                EmployeeType = new EmployeeType
                {

                    EmployeeTypeId = 1,
                    EmployeeTypeName = "Staff"
                },

                EmployeeSalary = new EmployeeSalary
                {
                    SalaryId = 1,
                    EmployeeId = 1,
                    GrossSalary = 10000
                }

            });

            employees.Add(new Employee
            {
                EmployeeId = 2,
                EmployeeTypeId = 1,
                FirstName = "TestFirst2",
                LastName = "TestLast2",
                MiddleName = "TestMiddle2",
                DateOfBirth = new DateTime(1990, 1, 1),
                CreateDate = DateTime.Now,

                EmployeeAddress = new EmployeeAddress
                {
                    AddressId = 2,
                    EmployeeId = 2,
                    ContactId = 2,
                    HomeAddress = "Add2",
                    OfficeAddress = "Office2"
                },

                EmployeeType = new EmployeeType
                {
                    EmployeeTypeId = 1,
                    EmployeeTypeName = "Staff"
                },

                EmployeeSalary = new EmployeeSalary
                {
                    SalaryId = 2,
                    EmployeeId = 2,
                    GrossSalary = 20000
                }

            });

            employees.Add(new Employee
            {
                EmployeeId = 3,
                EmployeeTypeId = 2,
                FirstName = "Manager1",
                LastName = "Manager1",
                MiddleName = "Manager1",
                DateOfBirth = new DateTime(1990, 1, 1),
                CreateDate = DateTime.Now,

                EmployeeAddress = new EmployeeAddress
                {
                    AddressId = 3,
                    EmployeeId = 3,
                    ContactId = 3,
                    HomeAddress = "Add3",
                    OfficeAddress = "Office3"
                },

                EmployeeType = new EmployeeType
                {
                    EmployeeTypeId = 2,
                    EmployeeTypeName = "Manager"
                },

                EmployeeSalary = new EmployeeSalary
                {
                    SalaryId = 3,
                    EmployeeId = 3,
                    GrossSalary = 50000
                }

            });

            _EmployeeList = employees.AsEnumerable();
        }

    }
}
