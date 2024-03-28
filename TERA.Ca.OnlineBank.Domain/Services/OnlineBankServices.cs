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

        public Task<BalanceModel> CheckBalance(Guid Userid)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> CheckProfile(Guid Userid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TransferMoney(TransactionModel mod)
        {
            throw new NotImplementedException();
        }
    }
}
