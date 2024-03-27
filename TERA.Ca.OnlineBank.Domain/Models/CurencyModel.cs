using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class CurencyModel
    {
        public string Name { get; set; }

        public decimal Equvalent { get; set; }

        public virtual List<Guid> TransactionIds { get; set; }

        public virtual List<Guid> WalletIds { get; set; }
    }
}
