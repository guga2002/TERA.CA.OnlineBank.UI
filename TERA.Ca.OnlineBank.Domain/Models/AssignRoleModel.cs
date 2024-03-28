using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class AssignRoleModel
    {
        [Required]
        public string UserID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name Is not valid")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Role Is not Valid")]
        public string Role { get; set; }

        public override string ToString()
        {
            return $"UserID: {UserID} , Role: {Role};";
        }
    }
}
