using AutoMapper;
using Microsoft.Extensions.Logging;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.Ca.OnlineBank.Domain.Validations;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.Ca.OnlineBank.Domain.Services
{
    public class OnlineBankServices : AbstractService, IOnlineBankServices
    {
        private readonly ILogger<OnlineBankServices> logger;
        public OnlineBankServices(IUniteOfWork work, IMapper map, ILogger<OnlineBankServices> logger) : base(work, map)
        {
            this.logger=logger;
        }

        public async Task<WalletModel> CheckBalance(Guid Userid)
        {
            try
            {
                var Walet = await work.WalletRepository.GetAllWithDetails();
                if (Walet != null)
                {
                    var specify = Walet.FirstOrDefault(io => io.UserId == Userid.ToString());
                    if (specify != null)
                    {
                        var mapped = mapper.Map<WalletModel>(specify);
                        logger.LogInformation($"User {Userid} have cheked Balance");
                        return mapped;
                    }
                }
                return new WalletModel();
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                throw;
            }
        }

        public async Task<UserModel> CheckProfile(Guid Userid)
        {
            try
            {

                var res = await work.UserRepository.GetById(Userid.ToString());
                if (res != null)
                {
                    var mapped = mapper.Map<UserModel>(res);
                    return mapped;
                }
                logger.LogInformation($"User {Userid} have cheked profile");
                return new UserModel();
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                throw;
            }
        }

        public async Task<bool> TransferMoney(TransactionModel mod)
        {
            try
            {
                if (mod == null || mod.Amount <= 0)
                {
                    throw new OnlineWalletException("Amount can not be null");
                }
                var sender = await work.WalletRepository.GetById(mod.SenderId.ToString());
                var reciever = await work.WalletRepository.GetById(mod.RecieverId.ToString());
                if (sender.Amount <= mod.Amount)
                {
                    logger.LogError("no enought balance");
                    throw new OnlineWalletException("no enought balance");
                }
                sender.Amount -= mod.Amount;
                reciever.Amount += mod.Amount;
                await work.SaveChanges();
                var mapped = mapper.Map<TERA.CA.OnlineBank.Core.Entities.Transaction>(mod);
                var result = await work.TransactionRepository.Create(mapped);
                logger.LogInformation("succesfully transfered money");
                await work.SaveChanges();
                return result;
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                throw;
            }
        }
    }
}
