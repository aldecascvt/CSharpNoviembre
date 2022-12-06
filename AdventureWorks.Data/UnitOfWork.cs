using Adventureworks.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AdventureWorksDbContext _context;

        public UnitOfWork(AdventureWorksDbContext context)
        {
            _context = context;
            Customer = new CustomerRepository(_context);
            Currency = new CurrencyRepository(_context);
            CurrencyRate = new CurrencyRatesRatesRepository(_context);
        }
        public ICustomerRepository Customer { get; set; }
        public ICurrencyRepository Currency { get; set; }
        public ICurrencyRatesRepository CurrencyRate { get; set; }


        #region Metodos Unidad de Trabajo
        public virtual int ExecuteSQLCommand(string sql, params object[] parameters)
        {
            return _context.Database.ExecuteSqlRaw(sql, parameters);
        }

        public Task<int> ExecuteSQLCommandAsync(CancellationToken cancellation, string sql, params object[] parameters)
        {
           return  _context.Database.ExecuteSqlRawAsync(sql, cancellation,  parameters);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            return _context.SaveChangesAsync(cancellation);
        }

        #endregion

    }
}
