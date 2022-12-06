using Adventureworks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repository
{
    public interface ICurrencyRatesRepository : IRepository<CurrencyRate>
    {
        void Update(CurrencyRate obj);
        IEnumerable<CurrencyRate> GetById(int id );
        void Delete(CurrencyRate obj);
        CurrencyRate GetCurrencyRate(int id);
    }
}
