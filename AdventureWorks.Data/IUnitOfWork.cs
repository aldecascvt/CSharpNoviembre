using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellation=default(CancellationToken));
        void Save();
        int ExecuteSQLCommand(string sql, params object[] parameters);

        Task<int> ExecuteSQLCommandAsync(CancellationToken cancellation,string sql, params object[] parameters);
    }
}
