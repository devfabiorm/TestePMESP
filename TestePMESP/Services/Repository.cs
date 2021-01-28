using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePMESP.Services
{
    public class Repository
    {
        public void Create<T>(IRepository repoBase)
        {
            repoBase.Create<T>();
        }

        public static List<T> FindAll<T>(IRepository repoBase)
        {
            return repoBase.FindAll<T>();
        }
    }
}
