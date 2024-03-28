using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Password Is not valid")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Password  is not valid")]
        public string NewPassword { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Password Is not valid")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Password  is not valid")]
        public string OldPassword { get; set; }

        public override string ToString()
        {
            return string.Format("UserId {0},NewPassword:{1}, OldPassword:{2}",UserId,NewPassword, OldPassword);
        }
    }
}
