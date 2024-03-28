using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class BalanceModel
    {
        public decimal Balance { get; set; }

        public string Curency { get; set; }

        public Guid WalletId { get; set; }
    }
}
