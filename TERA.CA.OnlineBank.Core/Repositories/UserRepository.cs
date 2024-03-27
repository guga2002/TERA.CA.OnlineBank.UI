using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly SignInManager<User> _SignInManager;
        public UserRepository(WalletDb db,UserManager<User>manageusers,SignInManager<User>managesign,RoleManager<IdentityRole>rolemanager) : base(db)
        {
            this._SignInManager = managesign;
            this._RoleManager = rolemanager;
            this._UserManager = manageusers;
        }

        public Task<bool> AddRole(string role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AsignToRole(string Id, string Role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(User entoty)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(User user, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignIn(string UserName, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
