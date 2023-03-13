using EmployeeService.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Repository
{
    public class EmployeeAttendanceRepo : IEmployeeAttendanceRepo
    {
        public EmployeeAttendanceRepo()
        {
            
        }

        public bool SaveInOut(int employeeId)
        {
            return true;
        }
    }
}
