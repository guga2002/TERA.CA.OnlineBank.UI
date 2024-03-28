using TERA.Ca.OnlineBank.Domain.Models;
using TERA.CA.OnlineBank.Core.Entities;

namespace TERA.Ca.OnlineBank.Domain.Interfaces
{
    public interface IUserServices:ICrudService<UserModel>
    {
        Task<bool> SignIn(SignInModel model);
        Task<bool> Register(UserModel user);
    }
}
