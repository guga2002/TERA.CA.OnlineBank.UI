using Microsoft.Extensions.Logging;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class CurencyRepository : AbstractRepository, ICurencyRepository
    {
        public CurencyRepository(WalletDb db) : base(db)
        {
        }

        public Task<bool> Create(Curency entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Curency entoty)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Curency>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Curency> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Curency entity)
        {
            throw new NotImplementedException();
        }
    }
}
