using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class WalletRepository : AbstractRepository, IWalletRepository
    {
        private readonly DbSet<Wallet> wallet;
        private readonly ILogger<WalletRepository> _Logger;
        public WalletRepository(WalletDb db,ILogger<WalletRepository>rep) : base(db)
        {
            wallet = Context.Set<Wallet>();
            this._Logger = rep;
        }

        public async Task<bool> Create(Wallet entity)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                if (!wallet.Any(io => io.UserId == entity.UserId && io.CurrencyId == entity.CurrencyId))
                {
                    await wallet.AddAsync(entity);
                    await Context.SaveChangesAsync();
                    await transact.CommitAsync();
                    Context.ChangeTracker.DetectChanges();
                    _Logger.LogInformation(Context.ChangeTracker.DebugView.ShortView);
                    return true;
                }
                await transact.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> Delete(Wallet entoty)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                var firs = wallet.Where(io => io.UserId == entoty.UserId && io.CurrencyId == entoty.CurrencyId).FirstOrDefault();
                if (firs != null)
                {
                    wallet.Remove(firs);
                    await Context.SaveChangesAsync();
                    await transact.CommitAsync();
                    Context.ChangeTracker.DetectChanges();
                    _Logger.LogInformation(Context.ChangeTracker.DebugView.ShortView);
                    return true;
                }
                await transact.RollbackAsync();
                return false;
            }
        }

        public async Task<IEnumerable<Wallet>> GetAll()
        {
            return await wallet.ToListAsync();
        }

        public async Task<IEnumerable<Wallet>> GetAllWithDetails()
        {
            return await wallet.Include(io => io.Transactions).Include(io => io.Currency)
                .ToListAsync();
        }

        public async Task<Wallet> GetById(string Id)
        {
            return await wallet.FindAsync(Id)??new Wallet();
        }

        public async Task<Wallet> GetByIdWithDetails(Guid Id)
        {
            return await wallet.Include(io=>io.Transactions).Include(io=>io.Currency).FirstOrDefaultAsync(I=>I.Id==Id) ?? new Wallet();
        }

        public async Task<bool> Update(Wallet entity)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                var firs = await wallet.Where(io => io.UserId == entity.UserId).FirstOrDefaultAsync();
                if (firs != null)
                {
                    firs.CurrencyId = entity.CurrencyId;
                    firs.Amount = entity.Amount;

                    wallet.Update(firs);
                    await Context.SaveChangesAsync();
                    await transact.CommitAsync();
                    Context.ChangeTracker.DetectChanges();
                    _Logger.LogInformation(Context.ChangeTracker.DebugView.ShortView);
                    return true;
                }
                await transact.RollbackAsync();
                return false;
            }
        }
    }
}
