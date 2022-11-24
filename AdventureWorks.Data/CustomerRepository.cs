using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventureworks.Data;

namespace AdventureWorks.Data.Repository
{
    public class CustomerRepository: Repository<Customer>,ICustomerRepository
    {
        private AdventureWorksDbContext _db;

        public CustomerRepository(AdventureWorksDbContext db):base(db)
        {
            _db = db;
        }
        public void Delete(Customer obj) 
        {
            _db.Customers.Remove(obj);
        }
        public IEnumerable<Customer> GetById(int id)
        {
            var result= _db.Customers.Find(id);
            yield return result;
        }
        public void Update (Customer obj)
        {
            _db.Customers.Update(obj);
        }

    }
}
