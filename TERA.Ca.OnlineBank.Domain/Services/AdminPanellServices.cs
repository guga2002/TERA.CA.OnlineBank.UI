using AutoMapper;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.Ca.OnlineBank.Domain.Services
{
    public class AdminPanellServices : AbstractService, IAdminPanell
    {
        public AdminPanellServices(IUniteOfWork work, IMapper map) : base(work, map)
        {
        }

        public Task<bool> AddRole(string role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AsignToRole(AssignRoleModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(CurencyModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid entoty)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRole(string role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CurencyModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CurencyModel> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModifyUser(string PersonalNumber, UserModel NewInfo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPassword(ResetPasswordModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(CurencyModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
