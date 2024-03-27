using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TERA.CA.OnlineBank.Core.Entities
{
    [Table("Curencies")]
    [Index(nameof(Name))]
    public class Curency:AbstractEntity
    {
        [Column("Curency_Name")]
        public string Name { get; set; }

        [Column("Course_In_Gel")]
        public decimal Equvalent { get; set; }

        public virtual IEnumerable<Wallet> wallets { get; set; }
    }
}
