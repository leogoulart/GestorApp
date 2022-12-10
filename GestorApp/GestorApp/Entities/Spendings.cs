using System;

namespace GestorApp.Entities
{
    public class Spendings
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public double TotalPrice
        {
            get
            {
                return Quantity * Product.PPrice;
            }
        }
    }
}