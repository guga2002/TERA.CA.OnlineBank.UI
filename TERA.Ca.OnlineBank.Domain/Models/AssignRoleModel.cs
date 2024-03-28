using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class AssignRoleModel
    {
        [Required]
        public string UserID { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
