using System;
using System.Collections.Generic;

namespace GestorApp.Entities
{
    public class Client
    {
        public string Id { get; set; }
        public string ClientName { get; set; }
        public List<Spendings> Spendings { get; set; } = new List<Spendings>();

        public double TotalSpendings
        {
            get
            {
                double total = 0;
                foreach(Spendings spend in Spendings)
                {
                    total += spend.TotalPrice;
                }
                return total;
            }
        }
    }
}