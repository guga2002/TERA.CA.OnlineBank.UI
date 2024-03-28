using AutoMapper;
using System.Transactions;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.Ca.OnlineBank.Domain.Validations;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.Ca.OnlineBank.Domain.Services
{
    public class OnlineBankServices : AbstractService, IOnlineBankServices
    {
        public OnlineBankServices(IUniteOfWork work, IMapper map) : base(work, map)
        {
        }

        public async Task<WalletModel> CheckBalance(Guid Userid)
        {
            var Walet = await work.WalletRepository.GetAllWithDetails();
            if (Walet != null) {
                var specify = Walet.FirstOrDefault(io => io.UserId == Userid.ToString());
                if (specify != null)
                {
                    var mapped = mapper.Map<WalletModel>(specify);
                    return mapped;
                }
            }
            return new WalletModel();
        }

        public async Task<UserModel> CheckProfile(Guid Userid)
        {
            var res = await work.UserRepository.GetById(Userid.ToString());
            if (res != null)
            {
                var mapped = mapper.Map<UserModel>(res);
                return mapped;
            }
            return new UserModel();
        }

        public async Task<bool> TransferMoney(TransactionModel mod)
        {
            if(mod==null||mod.Amount<=0)
            {
                throw new OnlineWalletException("Amount can not be null");
            }
            var sender = await work.WalletRepository.GetById(mod.SenderId.ToString());
            var reciever = await work.WalletRepository.GetById(mod.RecieverId.ToString());
            if(sender.Amount<=mod.Amount)
            {
                throw new OnlineWalletException("no enought balance");
            }
            sender.Amount -= mod.Amount;
            reciever.Amount += mod.Amount;
            await work.SaveChanges();
            var mapped = mapper.Map<TERA.CA.OnlineBank.Core.Entities.Transaction>(mod);
            var result= await work.TransactionRepository.Create(mapped);
            return result;
        }
    }
}
