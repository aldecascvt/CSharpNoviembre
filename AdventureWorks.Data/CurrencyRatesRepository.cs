using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventureworks.Data;

namespace AdventureWorks.Data.Repository
{
    public class CurrencyRatesRatesRepository: Repository<CurrencyRate>,ICurrencyRatesRepository
    {
        private AdventureWorksDbContext _db;

        public CurrencyRatesRatesRepository(AdventureWorksDbContext db):base(db)
        {
            _db = db;
        }
        public void Delete(CurrencyRate obj) 
        {
            _db.CurrencyRates.Remove(obj);
        }
        public IEnumerable<CurrencyRate> GetById(int id)
        {
            var result= _db.CurrencyRates.Find(id);
            yield return result;
        }
        public void Update (CurrencyRate obj)
        {
            _db.CurrencyRates.Update(obj);
        }
        public CurrencyRate GetCurrencyRate(int id)
        {
            var result =  _db.CurrencyRates.Find(id);
            return result;
        }

    }
}
