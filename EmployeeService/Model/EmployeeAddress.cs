using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Model
{
    public class EmployeeAddress
    {
        public int AddressId { get; set; }
        public int EmployeeId { get; set; }
        public int ContactId { get; set; }
        public string HomeAddress { get; set; }
        public string OfficeAddress { get; set; }

        public ContactDetails ContactDetails { get; set; }

    }
}
