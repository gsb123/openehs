using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Domain
{
    public class Products
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Catagory { get; set; }
        public decimal ProductCost { get; set; }
        public int QuantityOnHand { get; set; }
    }
}
