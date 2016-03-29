using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _isDisposed;

        public UnitOfWork(DbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }
        
        ~UnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _context.Dispose();
                _isDisposed = true;
                if (disposing)
                {
                    GC.SuppressFinalize(this);
                }
            }
        }
    }
}
