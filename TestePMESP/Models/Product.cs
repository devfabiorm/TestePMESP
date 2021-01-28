using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePMESP.Exceptions;

namespace TestePMESP.Models
{
    public class Product
    {
        public DateTime DeliveryDate { get; private set; }
        public string ProductDescription { get; private set; }
        public int ProductQuantity { get; private set; }
        public double UnitaryPrice { get; private set; }

        public Product(DateTime deliveryDate, string productDescription, int productQuantity, double unitaryPrice)
        {

            if(deliveryDate < DateTime.Now)
            {
                throw new ArgumentException("A data deve ser maior ou igual a data atual", nameof(deliveryDate));
            }

            if(productQuantity <= 0)
            {
                throw new ArgumentException("A quantidade do produto deve ser maior que zero.", nameof(productQuantity));
            }

            if(UnitaryPrice <= 0)
            {
                throw new ArgumentException("O preço não poder ser menor ou igual a zero.", nameof(unitaryPrice));
            }

            if(productDescription.Length > 50)
            {
                throw new ArgumentException("A descrição do produto pode conter no máximo 50 caracteres", nameof(productDescription));
            }

            DeliveryDate = deliveryDate;
            ProductDescription = productDescription;
            ProductQuantity = productQuantity;
            UnitaryPrice = Math.Round(unitaryPrice, 2);
        }
    }
}
