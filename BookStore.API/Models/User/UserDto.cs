using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models.User
{
    public class UserDto : LoginUserDto
    {
        [Required]
        [EmailAddress]
        public new string? Email { get; set; }
        [Required]
        public new string? Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}
