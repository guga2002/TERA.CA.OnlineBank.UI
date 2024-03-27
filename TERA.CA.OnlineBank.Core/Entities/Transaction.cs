using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TERA.CA.OnlineBank.Core.Entities
{
    [Table("Transactions")]
    [Index(nameof(Date))]
    [Index(nameof(ReceiverWalletId),IsUnique =true)]
    public class Transaction : AbstractEntity
    {
        [Column("Amount_Transfered")]
        public decimal Amount { get; set; }

        [Column("Date_Of_Transaction")]
        public DateTime Date { get; set; }

        [ForeignKey("Wallet")]
        public Guid SenderId{ get; set; }

        [Column("Reciever_ID")]
        public Guid ReceiverWalletId { get; set; }//shevamowmebt  vis vuricxavt

        public Wallet Wallet { get; set; }
    }
}
