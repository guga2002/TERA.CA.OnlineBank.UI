using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name  is not valid")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname  is not valid")]
        public string Surname { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "Personal Number mMust be 11 digit", MinimumLength = 11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Only 11 digit ar allowed")]
        public string PersonalNumber { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email  { get; set; }

        public override string ToString()
        {
            return $"Name: {Name};Surname:{Surname}; PersonalNumber: {PersonalNumber};UserName:{Username}; Email:{Email}";
        }
    }
}
