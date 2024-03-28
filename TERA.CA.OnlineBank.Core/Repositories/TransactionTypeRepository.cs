using Microsoft.EntityFrameworkCore;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class TransactionTypeRepository : AbstractRepository, ITransactionType
    {
        private readonly DbSet<TransactionType> _trans;
        public TransactionTypeRepository(WalletDb db) : base(db)
        {
            _trans=Context.Set<TransactionType>();
        }

        public async Task<bool> Create(TransactionType entity)
        {
            if(!_trans.Any(io=>io.TransactionName==entity.TransactionName))
            {
               await _trans.AddAsync(entity);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(TransactionType entoty)
        {
            var res = await _trans.FirstOrDefaultAsync(io => io.TransactionName == entoty.TransactionName);
            if(res!=null)
            {
                _trans.Remove(res);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TransactionType>> GetAll()
        {
            return await _trans.ToListAsync();
        }

        public async Task<TransactionType> GetById(string Id)
        {
            var res = await _trans.Where(io => io.Id == Guid.Parse(Id)).FirstOrDefaultAsync();
            return res??new TransactionType();
        }

        public async Task<bool> Update(TransactionType entity)
        {
           if(await _trans.AnyAsync(io=>io.TransactionName==entity.TransactionName))
            {
                _trans.Update(entity);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
