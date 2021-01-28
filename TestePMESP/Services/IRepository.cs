using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePMESP.Services
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All { get; }
        TEntity Find(int id);
        void Insert(params TEntity[] obj);
        void Edit(params TEntity[] obj);
        void Delete(params TEntity[] obj);
    }
}
