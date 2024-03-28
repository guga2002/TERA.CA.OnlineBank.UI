using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string NewPassword { get; set; }
        [Required]
        [MaxLength(50)]
        public string OldPassword { get; set; }
    }
}
