using System.ComponentModel.DataAnnotations.Schema;

namespace TERA.CA.OnlineBank.Core.Entities
{
    [Table("Wallets")]
    public class Wallet : AbstractEntity
    {
        [Column("Balance")]
        public decimal Amount { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Currency")]
        public Guid CurrencyId { get; set; }

        public Curency Currency { get; set; }

        public User User { get; set; }

        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
