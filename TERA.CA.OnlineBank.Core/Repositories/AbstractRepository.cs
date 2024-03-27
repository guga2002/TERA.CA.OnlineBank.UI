using Microsoft.Extensions.Logging;
using TERA.CA.OnlineBank.Core.Data;

namespace TERA.CA.OnlineBank.Core.Repositories
{
    public abstract class AbstractRepository<T>where T:class
    {
        protected  readonly WalletDb Context;
        protected readonly ILogger<T> logger;
        protected AbstractRepository(WalletDb db, ILogger<T> log)
        {
            this.Context = db;
            this.logger = log;
        }

    }
}
