using AutoMapper;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.Ca.OnlineBank.Domain.Validations;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.Ca.OnlineBank.Domain.Services
{
    public class UserService : AbstractService, IUserServices
    {
        public UserService(IUniteOfWork work, IMapper map) : base(work, map)
        {
        }

        public async Task<bool> Create(UserModel entity)
        {
           if(entity==null)
            {
                throw new OnlineWalletException("Error while add entity in Users");
            }
            var mapped = mapper.Map<User>(entity);
            var res=await work.UserRepository.Create(mapped);
            await work.SaveChanges();
            return res;
        }

        public async Task<bool> Delete(Guid entoty)//delete User
        {
            var user = await work.UserRepository.GetById(entoty.ToString());
            if (user != null)
            {
                var maped = mapper.Map<User>(user);
                var res = await work.UserRepository.Delete(maped);
                await work.SaveChanges();
                return res;
            }
            return false;
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            var user = await work.UserRepository.GetAll();
            if (user is null)
            {
                throw new OnlineWalletException($"No Users Exist");
            }
            var mapped = mapper.Map<IEnumerable<UserModel>>(user);
            return mapped;
        }

        public async Task<UserModel> GetById(Guid Id)
        {
            var user = await work.UserRepository.GetById(Id.ToString());
            if(user is null)
            {
                throw new OnlineWalletException($"No user exist on this Id {Id}");
            }
            var mapped = mapper.Map<UserModel>(user);
            return mapped;
        }

        public async Task<bool> Register(UserModel user)
        {
            if(user is null)
            {
                throw new OnlineWalletException("User cann not be null while add");
            }
            var mapped = mapper.Map<User>(user);
            var res=await work.UserRepository.Register(mapped, user.Password);
            await work.SaveChanges();
            return res;
        }

        public async Task<bool> SignIn(SignInModel model)
        {
            if (model == null || model.Username is  null || model.Password is  null)
            {
                throw new OnlineWalletException("Password and Username can not be null");
            }
            else
            {
                var res = await work.UserRepository.SignIn(model.Username, model.Password);
                return res;
            }
        }

        public async Task<bool> Signout()
        {
           var res= await work.UserRepository.Signout();
            await work.SaveChanges();
            return res;
        }

        public async Task<bool> Update(UserModel entity)
        {
            if(entity==null)
            {
                throw new OnlineWalletException(" Argument can not be null");
            }
            var mapped = mapper.Map<User>(entity);
            var res=await work.UserRepository.Update(mapped);
            await work.SaveChanges();
            return res;
        }
    }
}
