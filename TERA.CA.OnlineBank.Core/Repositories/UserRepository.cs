using Microsoft.Extensions.Logging;
using TERA.CA.OnlineBank.Core.Data;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        public UserRepository(WalletDb db) : base(db)
        {
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
