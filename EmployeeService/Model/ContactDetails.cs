using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Model
{
    public class ContactDetails
    {
        public int ContactId { get; set; }

        public string? CellphoneNumber { get; set; }

        public string? HomePhoneNumber { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
