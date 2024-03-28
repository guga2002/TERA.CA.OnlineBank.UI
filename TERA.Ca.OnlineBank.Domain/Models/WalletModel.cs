using System.ComponentModel.DataAnnotations;

namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class WalletModel
    {
        [Required]
        [Range(0,1000000000)]
        public decimal Amount { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid CurencyId { get; set; }

    }
}
