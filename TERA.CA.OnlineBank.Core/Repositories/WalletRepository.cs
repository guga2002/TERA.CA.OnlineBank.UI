using Microsoft.Extensions.Logging;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class WalletRepository : AbstractRepository<WalletRepository>, IWalletRepository
    {
        public WalletRepository(WalletDb db, ILogger<WalletRepository> log) : base(db, log)
        {
        }

        public Task<bool> Create(Wallet entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Wallet entoty)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Wallet>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Wallet>> GetAllWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<Wallet> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Wallet> GetByIdWithDetails(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Wallet entity)
        {
            throw new NotImplementedException();
        }
    }
}
