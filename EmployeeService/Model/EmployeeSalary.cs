using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Model
{
    public class EmployeeSalary
    {
        public int SalaryId { get; set; }

        public int EmployeeId { get; set; }

        public double GrossSalary { get; set; }
    }
}
