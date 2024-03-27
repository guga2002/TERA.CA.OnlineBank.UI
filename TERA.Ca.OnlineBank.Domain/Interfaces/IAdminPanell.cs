using TERA.CA.OnlineBank.Core.Entities;

namespace TERA.Ca.OnlineBank.Domain.Interfaces
{
    public interface IAdminPanell
    {
        Task<bool> AddRole(string role);
        Task<bool> AsignToRole(string Id, string Role);
        Task<bool> InsertCurency(Curency entity);
        Task<bool> UpdateCurency(Curency entity);
        Task<bool> DeleteCurency(Curency entoty);
    }
}
