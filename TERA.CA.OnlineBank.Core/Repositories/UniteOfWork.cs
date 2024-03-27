using Microsoft.AspNetCore.Identity;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class UniteOfWork : AbstractRepository, IUniteOfWork
    {
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly SignInManager<User> _SignInManager;
        public UniteOfWork(WalletDb db, UserManager<User> manageusers, SignInManager<User> managesign, RoleManager<IdentityRole> rolemanager) : base(db)
        {
            this._SignInManager = managesign;
            this._RoleManager = rolemanager;
            this._UserManager = manageusers;
        }
        public ICurencyRepository CurencyRepository => new CurencyRepository(Context);

        public ITransactionRepository TransactionRepository => new TransactionRepository(Context);

        public IUserRepository UserRepository => new UserRepository(Context,_UserManager,_SignInManager,_RoleManager);

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
