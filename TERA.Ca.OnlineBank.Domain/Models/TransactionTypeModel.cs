using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class TransactionTypeModel
    {
        [Required]
        [MaxLength(50)]
        public string TransactionName { get; set; }
    }
}
