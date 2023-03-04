using EmployeeService.Model;
using EmployeeService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Services
{
    public class EmployeeAddressService
    {
        private EmployeeAddressRepository repository;

        public EmployeeAddressService()
        {
            repository = new EmployeeAddressRepository();
        }

        public bool CreateEmployeeAddress(EmployeeAddress address)
        {

            return repository.CreateEmployeeAddress(address);
        }


        public EmployeeAddress GetEmployeeAddressById(int employeeId)
        {
            return repository.GetEmployeeAddressById(employeeId);
        }
    }
}
