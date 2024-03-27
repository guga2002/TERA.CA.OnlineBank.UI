using AutoMapper;
using System.Transactions;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.Ca.OnlineBank.Domain.Services
{
    public class OnlineBankServices : AbstractService, IOnlineBankServices
    {
        public OnlineBankServices(IUniteOfWork work, IMapper map) : base(work, map)
        {
        }

        public Task<bool> Create(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Transaction entoty)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CurencyModel>> GetAllValute()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<CurencyModel> GetValuteById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
