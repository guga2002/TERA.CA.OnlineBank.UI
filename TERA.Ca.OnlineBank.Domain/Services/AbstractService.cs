using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.Ca.OnlineBank.Domain.Services
{
    public  abstract class AbstractService
    {
        protected readonly IUniteOfWork work;
        protected readonly IMapper mapper;

        protected AbstractService(IUniteOfWork work,IMapper map)
        {
            this.work = work;
            this.mapper = map;
        }


    }
}
