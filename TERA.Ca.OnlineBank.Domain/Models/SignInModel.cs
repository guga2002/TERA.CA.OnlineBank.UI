using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class SignInModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username  is not valid")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Password  is not valid")]
        public string Password { get; set; }

        public override string ToString()
        {
            return $"UserName: {Username} ,Password: {Password};";
        }
    }
}
