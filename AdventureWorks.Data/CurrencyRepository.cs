using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventureworks.Data;

namespace AdventureWorks.Data.Repository
{
    public class CurrencyRepository: Repository<Currency>,ICurrencyRepository
    {
        private AdventureWorksDbContext _db;

        public CurrencyRepository(AdventureWorksDbContext db):base(db)
        {
            _db = db;
        }
        public void Delete(Currency obj) 
        {
            _db.Currencies.Remove(obj);
        }
        public IEnumerable<Currency> GetById(string id)
        {
            var result= _db.Currencies.Find(id);
            yield return result;
        }
        public void Update (Currency obj)
        {
            _db.Currencies.Update(obj);
        }
        public Currency GetCurrency(string id)
        {
            var result =  _db.Currencies.Find(id);
            return result;
        }
    }
}
