using System.ComponentModel.DataAnnotations;

namespace iFXManager.DAL.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int IdentificationType { get; set; }

        public int PositionId { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public bool Status { get; set; }

    }
}
