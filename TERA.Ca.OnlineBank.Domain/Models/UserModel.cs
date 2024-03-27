using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        [StringLength(11)]
        public string PersonalNumber { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email  { get; set; }
    }
}
