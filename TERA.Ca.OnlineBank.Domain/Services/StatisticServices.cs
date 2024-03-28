using AutoMapper;
using MongoDB.Driver.Linq;
using System.Linq;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.CA.OnlineBank.Core.Entities;
using TERA.CA.OnlineBank.Core.Interfaces;

namespace TERA.Ca.OnlineBank.Domain.Services
{
    public class StatisticServices : AbstractService, IStatisticServices
    {
        public StatisticServices(IUniteOfWork work, IMapper map) : base(work, map)
        {
        }

        public async Task<IEnumerable<string>> GetMostPopulatTransactionsTypes(int count)
        {
            var tran = await work.TransactionType.GetAll();
            var res= tran.OrderByDescending(io => io.Transactions.Count());
            var populars = res.Take(count).Select(io => io.TransactionName);
            if (populars != null)
            {
                return populars;
            }
            return new List<string>();
        }

        public async Task<IEnumerable<TransactionModel>> GetTransactionsByTransactionType(string type)
        {
            var typ =await work.TransactionType.GetAll();
            if(typ!=null)
            {
                var res=typ.Where(io => io.TransactionName == type).ToList();
                if (res != null)
                {
                    var mapped = mapper.Map<IEnumerable<TransactionModel>>(res);
                    return mapped;
                }

            }
            return new List<TransactionModel>();
        }

        public async  Task<IEnumerable<TransactionModel>> GetTransactonsByPeriod(DateTime start, DateTime end)
        {
            var res = await work.TransactionRepository.GetAllWithDetails();
            if (res != null)
            {
                var such=res.Where(io => io.Date <= end && io.Date >= start).ToList();
                if(such!=null)
                {
                    var mapped = mapper.Map<IEnumerable<TransactionModel>>(such);
                    return mapped;
                }
            }
            return new List<TransactionModel>();
        }
    }
}
