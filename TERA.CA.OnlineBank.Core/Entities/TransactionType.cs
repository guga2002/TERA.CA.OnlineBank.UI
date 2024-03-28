using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERA.CA.OnlineBank.Core.Entities
{
    [Table("TransactionTypes")]
    [Index(nameof(TransactionName))]
    public class TransactionType:AbstractEntity
    {
        [Column("Transaction_Type_Name")]
        public string? TransactionName { get; set; }

        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
