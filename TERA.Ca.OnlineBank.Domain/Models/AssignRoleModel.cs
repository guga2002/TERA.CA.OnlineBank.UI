using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class AssignRoleModel
    {
        [Required]
        public string UserID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Role Is not Valid")]
        public string Role { get; set; }

        public override string ToString()
        {
            return $"UserID: {UserID} , Role: {Role};";
        }
    }
}
