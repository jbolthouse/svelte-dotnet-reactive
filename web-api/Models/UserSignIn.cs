using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models {
    [NotMapped]
    public class UserSignIn {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required.")]
        [DataType(DataType.Text, ErrorMessage = "Username must be text.")]
        [MinLength(3, ErrorMessage = "Username must be at least three characters long.")]
        [MaxLength(32, ErrorMessage = "Username must be less than 32 characters long.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        [DataType(DataType.Text, ErrorMessage = "Password must be text.")]
        [MinLength(8, ErrorMessage = "Password must be at least eight characters long.")]
        [MaxLength(32, ErrorMessage = "Password must be less than 32 characters long.")]
        public string Password { get; set; }
    }
}
