using EmployeeService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Repository.Interface
{
    public interface IEmployeeRepo
    {
        int CreateEmployee(Employee employee);

        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeeById(int id);

    }
}
