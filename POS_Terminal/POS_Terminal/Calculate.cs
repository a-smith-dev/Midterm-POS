using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Terminal
{
    public abstract class Calculate
    {
        // Where the calculation methods will be defined.
        private const double _TAX = 0.06;

        public static double Subtotal(double price, int quantity)
        {
            return price * quantity;
        }

        public static string Total(double subtotal)
        {
            return (subtotal * _TAX).ToString("#.##");
        }
    }
}
