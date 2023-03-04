using EmployeeService.Model;
using EmployeeService.Repository.Interface;
using EmployeeService.Repository.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Repository
{
    public class EmployeeRepository: IEmployeeRepo
    {
        private EmployeeRepoData _employeeRepoData;

        public EmployeeRepository()
        {
            _employeeRepoData = new EmployeeRepoData();
 
        }
        public int CreateEmployee(Employee employee)
        {
            Random rnd = new Random();
            return  rnd.Next(1, 10);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepoData._EmployeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepoData._EmployeeList.First();
        }

    }
}
