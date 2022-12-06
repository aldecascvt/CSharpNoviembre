using Adventureworks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repository
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        void Update(Currency obj);
        IEnumerable<Currency> GetById(string id );
        void Delete(Currency obj);
        Currency GetCurrency(string id);
    }
}
