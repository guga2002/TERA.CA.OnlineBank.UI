using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TERA.CA.OnlineBank.Core.Entities
{
    [Table("Users")]
    [Index(nameof(PersonalNumber),IsUnique =true)]
    public class User:IdentityUser
    {
        [Required]
        [Column("Name_Of_User")]
        public string Name { get; set; }

        [Required]
        [Column("Surname_Of_User")]
        public string Surname { get; set; }

        [Required]
        [Column("Personal_Number")]
        public string PersonalNumber { get; set; }

        public virtual IEnumerable<Wallet> Wallets { get; set; }
    }
}
