using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Terminal
{
    public abstract class Calculate
    {
        private const decimal _TAX = 0.06m;

        public static decimal ShowTax()
        {
            return _TAX;
        }

        public static decimal Subtotal(decimal price, int quantity)
        {
            return price * quantity;
        }

        public static decimal SubtotalTax(decimal subtotal)
        {
            return subtotal * _TAX;
        }

        public static decimal Total(decimal subtotal)
        {
            return SubtotalTax(subtotal) + subtotal;
        }

        public static decimal Change(string payment, decimal total)
        {
            return (decimal.Parse(payment)- total);
        }
    }
}
