using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class UniteOfWork : AbstractRepository, IUniteOfWork
    {

        public UniteOfWork(WalletDb wallet):base(wallet)
        {
                
        }
        public ICurencyRepository CurencyRepository => new CurencyRepository(Context);

        public ITransactionRepository TransactionRepository => new TransactionRepository(Context);

        public IUserRepository UserRepository => new UserRepository(Context);

        public IWalletRepository WalletRepository => new WalletRepository(Context);

        public void Dispose()
        {
            Context.Dispose();
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }
    }
}
