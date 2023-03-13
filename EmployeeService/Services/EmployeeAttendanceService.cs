using EmployeeService.Interface;
using EmployeeService.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Services
{
    public class EmployeeAttendanceService : IEmployeeAttendanceService
    {
        IEmployeeAttendanceRepo _employeeAttendanceRepo;
        IEmployeeService _employeeService;

        public EmployeeAttendanceService(IEmployeeAttendanceRepo employeeAttendanceRepo, IEmployeeService employeeService)
        {
            _employeeAttendanceRepo = employeeAttendanceRepo;
            _employeeService = employeeService;
        }


        public bool SaveAttendance(int employeeId)
        {
            var employeeExist = _employeeService.EmployeeExist(employeeId);

            if (employeeExist)
            {
               return SaveInOut(employeeId);
            }
            else
            {
                return false;
            }
        }

        public bool SaveInOut(int employeeId)
        {
           var result = _employeeAttendanceRepo.SaveInOut(employeeId);
            return result;
        }
      
    }
}
