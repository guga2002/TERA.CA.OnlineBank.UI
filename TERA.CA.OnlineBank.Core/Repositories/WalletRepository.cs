using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;
using TERA.CA.OnlineBank.Infrastructure.EmailServices;
using TERA.CA.OnlineBank.Infrastructure.Interface;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class WalletRepository : AbstractRepository, IWalletRepository
    {
        private readonly DbSet<Wallet> wallet;
        private readonly ILogger<WalletRepository> _Logger;
        private readonly Ismtp sendNow;
        public WalletRepository(WalletDb db,ILogger<WalletRepository>rep) : base(db)
        {
            wallet = Context.Set<Wallet>();
            this._Logger = rep;
            sendNow = new SmtpService();
        }

        public async Task<bool> Create(Wallet entity)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                try
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
                catch (Exception exp)
                {
                    _Logger.LogCritical(exp.Message);
                    await transact.RollbackAsync();
                    throw;
                }

            }
        }

        public async Task<bool> Delete(Wallet entoty)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                try
                {
                    var firs = wallet.Where(io => io.UserId == entoty.UserId && io.CurrencyId == entoty.CurrencyId).FirstOrDefault();
                    if (firs != null)
                    {
                        wallet.Remove(firs);
                        await Context.SaveChangesAsync();
                        await transact.CommitAsync();
                        Context.ChangeTracker.DetectChanges();
                        _Logger.LogInformation(Context.ChangeTracker.DebugView.ShortView);
                        if (firs.User.Email is not null)
                        {
                            sendNow.SendMesaage(firs.User.Email ?? "aapkhazava22@gmail.com", $"საფულე წაიალა", $"შშენი საფულე წაიშალა{firs.Id}");
                        }
                        return true;
                    }
                    return false;
                }
                catch (Exception exp)
                {
                    _Logger.LogCritical(exp.Message);
                    await transact.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<IEnumerable<Wallet>> GetAll()
        {
            return await wallet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Wallet>> GetAllWithDetails()
        {
            return await wallet.AsNoTracking().Include(io => io.Transactions).Include(io => io.Currency)
                .ToListAsync();
        }

        public async Task<Wallet> GetById(string Id)
        {
            return await wallet.FirstOrDefaultAsync(io=>io.Id==Guid.Parse(Id))??new Wallet();
        }

        public async Task<Wallet> GetByIdWithDetails(Guid Id)
        {
            return await wallet.Include(io=>io.Transactions).Include(io=>io.Currency).FirstOrDefaultAsync(I=>I.Id==Id) ?? new Wallet();
        }

        public async Task<bool> Update(Wallet entity)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                try
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
                        if(firs.User.Email is not null)
                        {
                            sendNow.SendMesaage(firs.User.Email ?? "aapkhazava22@gmail.com", "საფულე განახლდა", $"შშენი საფულე წარმატებით განახლდა");
                        }
                        return true;
                    }
                    return false;
                }
                catch (Exception exp)
                {
                    _Logger.LogCritical(exp.Message);
                    await transact.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
