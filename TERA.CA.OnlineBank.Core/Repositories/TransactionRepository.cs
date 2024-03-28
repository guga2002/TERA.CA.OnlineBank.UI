using Microsoft.EntityFrameworkCore;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Interfaces;
using MongoDB.Driver;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class TransactionRepository : AbstractRepository, ITransactionRepository
    {
        private readonly DbSet<TERA.CA.OnlineBank.Core.Entities.Transaction> _transactions;
        public TransactionRepository(WalletDb db) : base(db)
        {
            _transactions=Context.Set<TERA.CA.OnlineBank.Core.Entities.Transaction>();
        }

        public async Task<bool> Create(TERA.CA.OnlineBank.Core.Entities.Transaction entity)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                if (!_transactions.Any(io => io.SenderId == entity.SenderId && io.ReceiverWalletId == entity.ReceiverWalletId))
                {
                    await _transactions.AddAsync(entity);
                    await Context.SaveChangesAsync();
                    await transact.CommitAsync();
                    return true;
                }
                await transact.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> Delete(TERA.CA.OnlineBank.Core.Entities.Transaction entity)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                var res = await _transactions.FirstOrDefaultAsync(io => io.SenderId == entity.SenderId && io.ReceiverWalletId == entity.ReceiverWalletId);
                if (res != null)
                {
                    _transactions.Remove(res);
                    await Context.SaveChangesAsync();
                    await transact.CommitAsync();
                    return true;
                }
                await transact.RollbackAsync();
                return false;
            }
        }

        public async Task<IEnumerable<TERA.CA.OnlineBank.Core.Entities.Transaction>> GetAll()
        {
            return await _transactions.ToListAsync();
        }

        public async Task<IEnumerable<TERA.CA.OnlineBank.Core.Entities.Transaction>> GetAllWithDetails()
        {
            return await _transactions.Include(io=>io.Wallet).ToListAsync();
        }

        public async Task<TERA.CA.OnlineBank.Core.Entities.Transaction> GetById(string Id)
        {
            return await _transactions.FirstOrDefaultAsync(io => io.Id == Guid.Parse(Id))?? new TERA.CA.OnlineBank.Core.Entities.Transaction();
        }

        public async Task<TERA.CA.OnlineBank.Core.Entities.Transaction> GetByIdWithDetails(Guid Id)
        {
            return await _transactions.Include(io=>io.Wallet).FirstOrDefaultAsync(io => io.Id == Id) ?? new TERA.CA.OnlineBank.Core.Entities.Transaction();
        }

        public async Task<bool> Update(TERA.CA.OnlineBank.Core.Entities.Transaction entity)
        {
            using (var transact = await Context.Database.BeginTransactionAsync())
            {
                if (await _transactions.AnyAsync(io => io.SenderId == entity.SenderId))
                {
                    _transactions.Update(entity);
                    await Context.SaveChangesAsync();
                   await transact.CommitAsync();
                    return true;
                }
                await transact.CommitAsync();
                return false;
            }
        }
    }
}
