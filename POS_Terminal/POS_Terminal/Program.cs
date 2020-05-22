using System;
using System.IO;

namespace POS_Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Business Name:

            // Text file with all items and fields/properties delimited.
            File.Create("menu.txt");
            
            // Create a menu and ask the user to choose an item by name or number.
                // choose quantity
                // give line total

            // Allow the user to re-display the menu and to complete the purchase.

            // Display subtotal, sales tax, and grand total.

            // Collect payment by three types: cash, credit, and check.
                // Cash: ask for amount tendered and provide change.
                // Check: ask for the check number.
                // Credit: ask for card number, expiration, and CVV.

            // Display a receipt with all the items ordered, subtotal, grand total, and appropriate payment info.

            // Return to the menu for a new order (Hint states: you'll want an array or ArrayList to keep track of what's been ordered).


        }
    }
}
