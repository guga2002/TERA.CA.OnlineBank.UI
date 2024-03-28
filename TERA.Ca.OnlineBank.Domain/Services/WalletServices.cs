using AutoMapper;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.Ca.OnlineBank.Domain.Validations;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.Ca.OnlineBank.Domain.Services
{
    public class WalletServices : AbstractService, IWalletServices
    {
        public WalletServices(IUniteOfWork work, IMapper map) : base(work, map)
        {
        }

        public async Task<bool> Create(WalletModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var mapped = mapper.Map<Wallet>(entity);
                    var res = await work.WalletRepository.Create(mapped);
                    await work.SaveChanges();
                    return res;
                }
                throw new OnlineWalletException("Entity can not be null");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(Guid entoty)
        {
            try
            {
                var res = await work.WalletRepository.GetById(entoty.ToString());
                if (res != null)
                {
                    var mapped = mapper.Map<Wallet>(res);
                    var response = await work.WalletRepository.Delete(mapped);
                    await work.SaveChanges();
                    return response;
                }
                throw new OnlineWalletException(" somethings unusual while deleting");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<WalletModel>> GetAll()
        {
            var res = await work.WalletRepository.GetAll();
            if(res!=null)
            {
                var mapped = mapper.Map<IEnumerable<WalletModel>>(res);
                return mapped;
            }
            throw new OnlineWalletException("no wallets exist");
        }

        public async Task<IEnumerable<WalletModel>> GetAllWithDetails()
        {
            var res = await work.WalletRepository.GetAllWithDetails();
            if (res != null)
            {
                var mapped = mapper.Map<IEnumerable<WalletModel>>(res);
                return mapped;
            }
            throw new OnlineWalletException("no wallets exist");
        }

        public async Task<WalletModel> GetById(Guid Id)
        {
            var res = await work.WalletRepository.GetById(Id.ToString());
            if (res != null)
            {
                var mapped = mapper.Map<WalletModel>(res);
                return mapped;
            }
            throw new OnlineWalletException("no wallets exist");
        }

        public async Task<WalletModel> GetByIdWithDetails(Guid Id)
        {
            var res = await work.WalletRepository.GetByIdWithDetails(Id);
            if (res != null)
            {
                var mapped = mapper.Map<WalletModel>(res);
                return mapped;
            }
            throw new OnlineWalletException("no wallets exist");
        }

        public async Task<bool> Update(WalletModel entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new OnlineWalletException("somethings  bad happened   while updating wallet");
                }
                var mapped = mapper.Map<Wallet>(entity);
                var res = await work.WalletRepository.Update(mapped);
                await work.SaveChanges();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
