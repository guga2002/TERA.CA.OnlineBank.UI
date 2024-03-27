using AutoMapper;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.CA.OnlineBank.Core.Entities;
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

        public Task<bool> DeleteCurency(CurencyModel entoty)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertCurency(CurencyModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCurency(CurencyModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
