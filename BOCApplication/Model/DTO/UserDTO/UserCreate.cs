using System.ComponentModel.DataAnnotations;

namespace BOCApplication.Model.DTO.UserDTO
{
    public class UserCreate
    {
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Must be between 2 and 255 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
