using System.ComponentModel.DataAnnotations;

namespace iFXManager.API.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public string? IdNumber { get; set; }
        public int IdentificationTypeId { get; set; }

        public int EntityTypeId { get; set; }

        public string? EntityName { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
            
    }
}
