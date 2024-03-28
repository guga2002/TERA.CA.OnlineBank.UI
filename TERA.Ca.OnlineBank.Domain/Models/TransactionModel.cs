using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class TransactionModel
    {
        [Required]
        [Range(0,100000000)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid SenderId { get; set; }
        [Required]
        public Guid RecieverId { get; set; }

        [Required]
        public Guid CurencyId { get; set; }

        [Required]
        public Guid TypeId { get; set; }

        public override string ToString()
        {
            return $"Amount: {Amount} ,Date{Date}";
        }
    }
}
