using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TERA.CA.OnlineBank.Core.Entities
{
    [Table("Transactions")]
    [Index(nameof(Date))]
    public class Transaction:AbstractEntity
    {
        [Column("Amount_Transfered")]
        public decimal Amount { get; set; }

        [Column("Date_Of_Transaction")]
        public DateTime Date { get; set; }

        [ForeignKey("WalletSender")]
        public Guid SenderId { get; set; }

        [ForeignKey("WalletReciever")]
        public Guid RecieverId { get; set; }
        [ForeignKey("Curency")]
        public Guid CurencyId { get; set; }

        public Wallet WalletSender { get; set; }

        public Wallet WalletReciever { get; set; }

        public  Curency Curency { get; set; }

    }
}
