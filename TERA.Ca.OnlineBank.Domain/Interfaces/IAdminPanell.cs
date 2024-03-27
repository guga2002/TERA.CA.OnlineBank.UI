using TERA.Ca.OnlineBank.Domain.Models;
using TERA.CA.OnlineBank.Core.Entities;

namespace TERA.Ca.OnlineBank.Domain.Interfaces
{
    public interface IAdminPanell
    {
        Task<bool> AddRole(string role);
        Task<bool> AsignToRole(AssignRoleModel model);
        Task<bool> InsertCurency(CurencyModel entity);
        Task<bool> UpdateCurency(CurencyModel entity);
        Task<bool> DeleteCurency(CurencyModel entoty);
    }
}
