using MongoDB.Driver;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.CA.OnlineBank.Core.Entities;

namespace TERA.Ca.OnlineBank.Domain.Interfaces
{
    public interface IAdminPanell:ICrudService<CurencyModel>
    {
        Task<bool> AddRole(string role);
        Task<bool> AsignToRole(AssignRoleModel model);
        Task<bool> ResetPassword(ResetPasswordModel model);
        Task<bool> ModifyUser(string PersonalNumber, UserModel NewInfo);
        Task<bool> DeleteUser(Guid Id);
        Task<bool> CreateTransactionType(TransactionTypeModel entity);
        Task<bool> DeleteTransactionType(TransactionTypeModel entoty);
        Task<TransactionTypeModel> GetByIdTransactionType(string Id);
    }
}
