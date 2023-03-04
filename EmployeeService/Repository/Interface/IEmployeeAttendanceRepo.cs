using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Repository.Interface
{
    public interface IEmployeeAttendanceRepo
    {
        bool SaveInOut(int employeeId);
    }
}
