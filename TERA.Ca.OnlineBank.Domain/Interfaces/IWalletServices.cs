using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.Ca.OnlineBank.Domain.Interfaces
{
    public interface IWalletServices:ICrudService<WalletModel>
    {
        Task<WalletModel> GetByIdWithDetails(Guid Id);
        Task<IEnumerable<WalletModel>> GetAllWithDetails();
    }
}
