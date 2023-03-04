using EmployeeService.Interface;
using EmployeeService.Model;
using EmployeeService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Services
{
    public class EmployeeService: IEmployeeService
    {
        private EmployeeRepository repository;

        public EmployeeService()
        {
            repository = new EmployeeRepository();
        }

        public int CreateEmployee(Employee employee)
        {

          return  repository.CreateEmployee(employee);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return repository.GetEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            return repository.GetEmployeeById(id);
        }

        public bool EmployeeExist(int id)
        {
            return repository.GetEmployeeById(id) != null ;
        }
    }
}
