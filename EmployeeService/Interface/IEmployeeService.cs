using EmployeeService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Interface
{
    public interface IEmployeeService
    {
        int CreateEmployee(Employee employee);

        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeeById(int id);

        bool EmployeeExist(int id);


    }
}
