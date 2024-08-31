using System.ComponentModel.DataAnnotations;

namespace iFXManager.DAL.Models
{
    public class EntityType
    {
        [Key]
        public int Id { get; set; }

        public string? Description { get; set; }

        public bool Status { get; set; }
    }
}
