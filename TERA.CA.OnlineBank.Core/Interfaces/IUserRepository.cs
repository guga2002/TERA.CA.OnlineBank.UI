using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERA.CA.OnlineBank.Core.Entities;

namespace TERA.CA.OnlineBank.Core.Interfaces
{
    public interface IUserRepository:ICrudRepository<User>
    {
        Task<bool> AddRole(string role);
        Task<bool> AsignToRole(string Id, string Role);
        Task<bool> SignIn(string UserName, string Password);
        Task<bool> Register(User user, string Password);
        Task<bool> ResetPasword(string id, string old, string newpasswo)
    }
}
