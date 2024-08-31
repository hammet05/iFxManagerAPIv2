using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFXManager.DAL.DTOs
{
    public class EntityDto
    {   
        public string? IdNumber { get; set; }
        public int IdentificationTypeId { get; set; }

        public int EntityTypeId { get; set; }

        public string? EntityName { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
