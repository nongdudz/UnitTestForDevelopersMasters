using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int EmployeeTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreateDate { get; set; }

        public EmployeeAddress EmployeeAddress { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public EmployeeSalary EmployeeSalary { get; set; }

    }
}
