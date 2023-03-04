using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Interface
{
    public interface IEmployeeAttendanceService
    {
       bool SaveAttendance(int employeeId);

        bool SaveInOut(int employeeId);
    }
}
