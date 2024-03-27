using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERA.Ca.OnlineBank.Domain.Interfaces;
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

        public Task<bool> AsignToRole(string Id, string Role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCurency(Curency entoty)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertCurency(Curency entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCurency(Curency entity)
        {
            throw new NotImplementedException();
        }
    }
}
