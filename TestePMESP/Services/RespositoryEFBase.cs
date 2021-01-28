using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePMESP.Services
{
    public class RespositoryEFBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> All => throw new NotImplementedException();

        public void Delete(params TEntity[] obj)
        {
            throw new NotImplementedException();
        }

        public void Edit(params TEntity[] obj)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(params TEntity[] obj)
        {
            throw new NotImplementedException();
        }
    }
}
