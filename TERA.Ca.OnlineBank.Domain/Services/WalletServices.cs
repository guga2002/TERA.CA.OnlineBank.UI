using AutoMapper;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.Ca.OnlineBank.Domain.Services
{
    public class WalletServices : AbstractService, IWalletServices
    {
        public WalletServices(IUniteOfWork work, IMapper map) : base(work, map)
        {
        }

        public Task<bool> Create(WalletModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid entoty)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WalletModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WalletModel>> GetAllWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<WalletModel> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<WalletModel> GetByIdWithDetails(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(WalletModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
