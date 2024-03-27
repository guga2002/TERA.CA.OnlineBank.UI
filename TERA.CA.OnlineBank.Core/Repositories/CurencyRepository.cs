﻿using Microsoft.Extensions.Logging;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class CurencyRepository : AbstractRepository<CurencyRepository>, ICurencyRepository
    {
        public CurencyRepository(WalletDb db, ILogger<CurencyRepository> log) : base(db, log)
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

        public Task<Curency> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Curency entity)
        {
            throw new NotImplementedException();
        }
    }
}
