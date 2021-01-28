using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePMESP.Exceptions;

namespace TestePMESP.Views
{
    public class ProductApi
    {
        public DateTime DeliveryDate { get;  set; }
        public string ProductDescription { get;  set; }
        public int ProductQuantity { get;  set; }
        public double UnitaryPrice { get;  set; }
        public double Total { get; set; }
    }
}
