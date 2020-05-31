using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace POS_Terminal
{
    public class Product
    {
        // Needs a constructor that pulls the info from menu.txt
        // to define the values of the below variables.
        // Possibly need a Drink subclass so the user can say
        // what size drink they want when checking out.
        // Name
        public string Name
        { get; set; }

        // Category : Food, Drink
        public string Category
        { get; set; }

        // Description
        public string Description
        { get; set; }

        // Price
        public decimal Price
        { get; set; }

        // Quantity
        public int Quantity
        { get; set; }
    }
}