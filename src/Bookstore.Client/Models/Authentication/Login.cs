using System.ComponentModel.DataAnnotations;

namespace Bookstore.Client.Models.Authentication
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
