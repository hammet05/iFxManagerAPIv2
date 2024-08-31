using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFXManager.DAL.DTOs
{
    public class EmployeesDto
    {
        public int IdentificationType { get; set; }

        public int PositionId { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public bool Status { get; set; }
    }
}
