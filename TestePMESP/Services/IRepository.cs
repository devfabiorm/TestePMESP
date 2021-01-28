using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePMESP.Services
{
    public interface IRepository
    {
        void Create<T>();
        void Remove<T>();
        List<T> FindAll<T>();
        T FindById<T>(int id);
    }
}
