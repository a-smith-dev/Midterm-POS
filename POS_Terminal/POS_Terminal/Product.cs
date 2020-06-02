using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace POS_Terminal
{
    public class Product
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}