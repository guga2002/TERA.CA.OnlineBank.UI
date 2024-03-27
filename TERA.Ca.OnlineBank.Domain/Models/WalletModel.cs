using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class WalletModel
    {
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }

        public Guid CurencyId { get; set; }

        public List<int> TransactionIds { get; set; }
    }
}
