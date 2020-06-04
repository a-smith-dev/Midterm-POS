using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace POS_Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Business Name: Sharpbucks

            // Text file with all items and fields/properties delimited.
            var menu = new Menu();
            var payment = new List<string>();


            menu.Display();

            Console.Write("Please choose from the menu items above. Enter 1-12: ");
            var choice = Validate.PositiveNumber(Console.ReadLine(), menu.GetCount());
            menu.AddProduct(choice);


            Console.WriteLine("How would you like to pay? (Cash, Credit or Check?)");
            switch (Console.ReadLine())
            {
                case "cash":
                    payment = PaymentCash(menu);
                    break;
                case "credit":
                    payment = PaymentCredit();
                    break;
                case "check":
                    payment = PaymentCheck();
                    break;

            }


            menu.DisplayReceipt(payment);



           

            // Allow the user to re-display the menu and to complete the purchase.


            // Collect payment by three types: cash, credit, and check.
            // Cash: ask for amount tendered and provide change.
            // Check: ask for the check number.
            // Credit: ask for card number, expiration, and CVV.

            // Display a receipt with all the items ordered, subtotal, grand total, and appropriate payment info.

            // Return to the menu for a new order (Hint states: you'll want an array or ArrayList to keep track of what's been ordered).


        }
        public static List<string> PaymentCash(Menu menu)
        {
            var payment = new List<string>() { "Cash" };
            Console.WriteLine($"Please enter the cash amount provided: ");
            payment.Add($"{Validate.EnoughCash(menu.ReceiptTotal(), Console.ReadLine())}");
            return payment;
        }
        public static List<string> PaymentCredit()
        {
            var payment = new List<string>();
            Console.WriteLine($"Please enter the credit card number: ");
            payment.Add($"credit \n{Validate.CardNumber(Console.ReadLine())}");
            Console.WriteLine("Please enter the expiration date in MMYY format: ");
            Validate.CardExp(Console.ReadLine());
            Console.WriteLine("Please enter the CVV: ");
            Validate.CardCVV(Console.ReadLine());
            return payment;
        }

        public static List<string> PaymentCheck()
        {
            var payment = new List<string>() { "Check" };
            Console.WriteLine($"Please enter the check number (3 - 4 digits): ");
            Validate.CheckNo(Console.ReadLine());
            return payment;
        }



    }
}
