using EmployeeService.Model;
using EmployeeService.Repository.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Repository
{
    public class EmployeeAddressRepository
    {
        private EmployeeRepoData _employeeRepoData;

        public EmployeeAddressRepository()
        {
            _employeeRepoData = new EmployeeRepoData();
 
        }
        public bool CreateEmployeeAddress(EmployeeAddress address)
        {
            return true;
        }

        public EmployeeAddress GetEmployeeAddressById(int id)
        {
            return _employeeRepoData._EmployeeList.First().EmployeeAddress;
        }

    }
}
