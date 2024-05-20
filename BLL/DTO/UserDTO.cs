using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int? UserId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; } = string.Empty;
        [Required]
        public string Tel { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }

        // Convention to use pascal case in DTO

        //properties start with uppercase

    }
}
