using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class BalanceModel
    {
        [Required]
        [Range(0, 1000000000)]
        public decimal Balance { get; set; }

        [Required]
        public string Curency { get; set; }

        [Required]
        public Guid WalletId { get; set; }
    }
}
