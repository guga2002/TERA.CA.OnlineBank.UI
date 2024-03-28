using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class TransactionModel
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid SenderId { get; set; }
        [Required]
        public Guid RecieverId { get; set; }
        [Required]
        public Guid CurencyId { get; set; }
    }
}
