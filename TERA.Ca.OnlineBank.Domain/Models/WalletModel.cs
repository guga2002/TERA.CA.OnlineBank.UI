namespace TERA.Ca.OnlineBank.Domain.Models
{
    public class WalletModel
    {
        
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }

        public Guid CurencyId { get; set; }

        public List<Guid>? TransactionIds { get; set; }
    }
}
