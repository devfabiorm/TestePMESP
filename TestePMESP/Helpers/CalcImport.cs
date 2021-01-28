using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePMESP.Models;

namespace TestePMESP.Helpers
{
    public class CalcImport
    {

        public DateTime GetCloserDate(List<Product> products)
        {
            DateTime minDate = DateTime.Now;

            for (int prod = 0; prod < products.Count() -1; prod++)
            {
                minDate = products[0].DeliveryDate;

                if (minDate > products[prod + 1].DeliveryDate)
                {
                     minDate = products[prod].DeliveryDate;
                }
            }

            return minDate;
        }

        public double GetTotalImport(List<Product> products)
        {
            double total = 0;

            foreach (var product in products)
            {
                total += product.ProductQuantity * product.UnitaryPrice;
            }

            return Math.Round(total, 2);
        }
    }
}
