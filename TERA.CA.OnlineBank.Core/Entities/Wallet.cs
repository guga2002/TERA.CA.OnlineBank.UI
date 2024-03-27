using System.ComponentModel.DataAnnotations.Schema;

namespace TERA.CA.OnlineBank.Core.Entities
{
    [Table("Wallets")]
    public class Wallet:AbstractEntity
    {
        [Column("Balance")]
        public decimal Amount { get; set; }


        [ForeignKey("User")]
        public Guid UserId { get; set; }


        [ForeignKey("Curency")]
        public Guid CurencyId { get; set; }

        public Curency Curency { get; set; }

        public User User { get; set; }

        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
