using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class CurencyRepository : AbstractRepository, ICurencyRepository
    {
        private readonly DbSet<Curency> Curency;
        public CurencyRepository(WalletDb db) : base(db)
        {
            Curency = Context.Set<Curency>();
        }

        public async Task<bool> Create(Curency entity)//only allowed EURO , USD, GBP
        {
            using (var Transact = await Context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (entity.Name.ToUpper() == "EURO" || entity.Name.ToUpper() == "USD" || entity.Name.ToUpper() == "GBP")
                    {
                        var res = await Curency.FirstOrDefaultAsync(io => io.Name == entity.Name);
                        if (res==null)
                        {
                            await Curency.AddAsync(entity);
                            await Context.SaveChangesAsync();
                            await Transact.CommitAsync();
                            return true;
                        }
                        else
                        {
                            res.Equvalent = entity.Equvalent;
                            await Context.SaveChangesAsync();
                            await Transact.CommitAsync();
                            return true;
                        }    
                    }
                    return false;
                }
                catch (Exception)
                {
                    await Transact.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<bool> Delete(Curency entoty)
        {
            using (var Transact = await Context.Database.BeginTransactionAsync())
            {
                try
                {
                    var frs = Curency.FirstOrDefaultAsync(io => io.Name == entoty.Name);
                    if (frs != null)
                    {
                        Curency.Remove(entoty);
                        await Context.SaveChangesAsync();
                        await Transact.CommitAsync();
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    await Transact.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<IEnumerable<Curency>> GetAll()
        {
            return await Curency.AsNoTracking().ToListAsync();
        }

        public async Task<Curency> GetById(string Id)
        {
            return await Curency.AsNoTracking().FirstOrDefaultAsync(io => io.Id == Guid.Parse(Id)) ?? new Curency() ;
        }

        public async Task<bool> Update(Curency entity)
        {
            using (var Transact = await Context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (await Curency.AsNoTracking().AnyAsync(io => io.Name == entity.Name))
                    {
                        Curency.Update(entity);
                        await Context.SaveChangesAsync();
                        await Transact.CommitAsync();
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    await Transact.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
