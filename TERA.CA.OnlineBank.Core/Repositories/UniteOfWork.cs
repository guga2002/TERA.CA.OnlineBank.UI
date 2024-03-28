using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserRepository> _Logger;
        private readonly ILogger<WalletRepository> Walletlog;
        public UniteOfWork(WalletDb db, UserManager<User> manageusers, SignInManager<User> managesign, RoleManager<IdentityRole> rolemanager, ILogger<UserRepository> _Logger, ILogger<WalletRepository> Walletlog) : base(db)
        {
            this._SignInManager = managesign;
            this._RoleManager = rolemanager;
            this._UserManager = manageusers;
            this._Logger = _Logger;
            this.Walletlog = Walletlog;
        }
        public ICurencyRepository CurencyRepository => new CurencyRepository(Context);

        public ITransactionRepository TransactionRepository => new TransactionRepository(Context);

        public IUserRepository UserRepository => new UserRepository(Context,_UserManager,_SignInManager,_RoleManager,_Logger);

        public IWalletRepository WalletRepository => new WalletRepository(Context,Walletlog);

        public ITransactionType TransactionType => new TransactionTypeRepository(Context);

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
