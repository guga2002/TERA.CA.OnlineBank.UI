using TERA.Ca.OnlineBank.Domain.Models;
using TERA.CA.OnlineBank.Core.Entities;

namespace TERA.Ca.OnlineBank.Domain.Interfaces
{
    public interface IUserServices:ICrudService<UserModel>
    {
        Task<bool> SignIn(string UserName, string Password);
        Task<bool> Register(UserModel user, string Password);
    }
}
