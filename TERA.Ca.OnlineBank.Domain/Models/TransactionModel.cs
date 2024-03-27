using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class TransactionModel
    {
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public Guid SenderId { get; set; }

        public Guid RecieverId { get; set; }

        public Guid CurencyId { get; set; }
    }
}
