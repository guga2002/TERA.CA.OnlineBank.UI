using AutoMapper;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.Ca.OnlineBank.Domain.Validations;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.Ca.OnlineBank.Domain.Services
{
    public class AdminPanellServices : AbstractService, IAdminPanell
    {
        public AdminPanellServices(IUniteOfWork work, IMapper map) : base(work, map)
        {
        }

        public async Task<bool> AddRole(string role)
        {
            if(role == null)
            {
                throw new OnlineWalletException(" Roli  ar sheidzleba iyos nali");
            }
            var res=await work.UserRepository.AddRole(role);
            await work.SaveChanges();
            return res;
        }

        public async Task<bool> AsignToRole(AssignRoleModel model)
        {
            if(model.UserID == null||model.Role is null)
            {
                throw new OnlineWalletException("Role or User Id is invalid");
            }
            var res = await work.UserRepository.AsignToRole(model.UserID, model.Role);
            await work.SaveChanges();
            return res;
        }

        public async Task<bool> Create(CurencyModel entity)
        {
            if(entity==null)
            {
                throw new OnlineWalletException(" it can not be null while adding curency");
            }
            var mapped = mapper.Map<Curency>(entity);
            var res = await work.CurencyRepository.Create(mapped);
            await work.SaveChanges();
            return res;
        }

        public async Task<bool> CreateTransactionType(TransactionTypeModel entity)
        {
            if (entity is null)
            {
                throw new OnlineWalletException("Entity can not be null");
            }
            var mapped=mapper.Map<TransactionType>(entity);
            var res= await work.TransactionType.Create(mapped);
            return res;
        }

        public async Task<bool> Delete(Guid entoty)//deletes curency
        {
            var curenc = await work.CurencyRepository.GetById(entoty.ToString());
            if(curenc!=null)
            {
                var res=await work.CurencyRepository.Delete(curenc);
                if(res)
                {
                   await work.SaveChanges();
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> DeleteTransactionType(TransactionTypeModel entoty)
        {
            if(entoty==null)
            {
                throw new OnlineWalletException("error while deleting , argument is null");
            }
            var mapped = mapper.Map<TransactionType>(entoty);
            var res=await work.TransactionType.Delete(mapped);
            return res;
        }

        public async Task<bool> DeleteUser(Guid Id)
        {
           var user =await work.UserRepository.GetById(Id.ToString());
            if (user != null)
            {
                var res = work.UserRepository.Delete(user);
                await work.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CurencyModel>> GetAll()
        {
            var res = await work.CurencyRepository.GetAll();
            if(res!=null)
            {
                var mapped=mapper.Map<IEnumerable<CurencyModel>>(res);
                return mapped;
            }
            return new List<CurencyModel>();
        }

        public async Task<CurencyModel> GetById(Guid Id)
        {
            var curency = await work.CurencyRepository.GetById(Id.ToString());
            if ((curency!=null))
            {
                var mapped = mapper.Map<CurencyModel>(curency);
                return mapped;
            }
            return new CurencyModel();
        }

        public async Task<TransactionTypeModel> GetByIdTransactionType(string Id)
        {
            var res = await work.TransactionType.GetById(Id);
            if(res!=null)
            {
                var mapped = mapper.Map<TransactionTypeModel>(res);
                return mapped;
            }
            return new TransactionTypeModel();
        }

        public async Task<bool> ModifyUser(string PersonalNumber, UserModel NewInfo)
        {
            if(PersonalNumber is null&&NewInfo!=null)
            {
                throw new OnlineWalletException(" it can not be null");
            }
            var mapped = mapper.Map<User>(NewInfo);
            var res = await work.UserRepository.Update(mapped);
            if(res)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ResetPassword(ResetPasswordModel model)
        {
            if(model.OldPassword is null ||model.NewPassword is null)
            {
                throw new OnlineWalletException(" passwords  can be null");
            }
            if(!model.NewPassword.Equals(model.OldPassword))
            {
                throw new OnlineWalletException("Passwords do not math");
            }
            var res=await work.UserRepository.ResetPasword(model.UserId, model.OldPassword, model.NewPassword);
            return res;
        }

        public async Task<bool> Update(CurencyModel entity)
        {
            if(entity==null)
            {
                throw new OnlineWalletException("entity is null while  updating");
            }
            var mapped = mapper.Map<Curency>(entity);
            var res=await work.CurencyRepository.Update(mapped);
            return res;
        }
    }
}
