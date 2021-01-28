using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePMESP.Contexts;

namespace TestePMESP.Services
{
    public class RepositoryEFBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;

        public RepositoryEFBase(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> All => _context.Set<TEntity>().AsQueryable();

        public void Delete(params TEntity[] obj)
        {
            _context.Set<TEntity>().RemoveRange(obj);
            _context.SaveChanges();
        }

        public void Edit(params TEntity[] obj)
        {
            _context.Set<TEntity>().UpdateRange(obj);
        }

        public TEntity Find(int id)
        {
            return _context.Find<TEntity>(id);
        }

        public void Insert(params TEntity[] obj)
        {
            _context.Set<TEntity>().AddRange(obj);
            _context.SaveChanges();
        }
    }
}
