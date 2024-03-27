using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.Ca.OnlineBank.Domain.Services
{
    public class UserService : AbstractService, IUserServices
    {
        public UserService(IUniteOfWork work, IMapper map) : base(work, map)
        {
        }

        public Task<bool> Create(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(UserModel entoty)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(UserModel user, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignIn(string UserName, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UserModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
