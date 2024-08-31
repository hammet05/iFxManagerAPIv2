using System.ComponentModel.DataAnnotations;

namespace iFXManager.DAL.DTOs
{
    public class CredentialsUsersDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required] 
        public string? Password { get; set; }

        public string? UserName { get; set; }

    }
}
