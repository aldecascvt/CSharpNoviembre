using Adventureworks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer obj);
        IEnumerable<Customer> GetById(int id );
        void Delete(Customer obj);

    }
}
