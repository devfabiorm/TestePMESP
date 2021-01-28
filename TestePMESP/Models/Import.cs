using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePMESP.Services;

namespace TestePMESP.Models
{
    public class Import
    {  
        public int Id { get; private set; }
        public DateTime ImportDate { get; }
        public List<Product> Products { get; set; }

        public Import()
        {
            ImportDate = DateTime.Now;
        }
    }
}
