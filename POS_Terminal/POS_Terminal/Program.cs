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

            Console.WriteLine("Welcome to Sharpbucks! Please take a look at our menu below for options available:\n");
            do
            {
                menu.Display();

                do
                {
                    Console.Write("\nPlease enter 1-12: ");
                    var choice = Validate.PositiveNumber(Console.ReadLine(), menu.GetCount());
                    menu.AddProduct(choice);
                    Console.Write("Would you like anything else? (y/n) ");
                } while (Validate.YesNo(Console.ReadLine()) == "y");

                Console.Write($"\nYour total comes to {menu.ReceiptTotal():C}. How would you like to pay? (Cash, Credit or Check?) ");
                switch (Validate.PaymentType(Console.ReadLine()))
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
                menu.EmptyReceipt();

                Console.Write("\nWould you like to place another order? (y/n) ");
            } while (Validate.YesNo(Console.ReadLine()) == "y");

            menu.EmptyMenu();

            Console.WriteLine("\n\nThank you for visiting Sharpbucks! Have a great day!");
        }

        public static List<string> PaymentCash(Menu menu)
        {
            var payment = new List<string>() { "Cash:\t\t" };
            Console.WriteLine($"Please enter the cash amount provided: ");
            payment.Add($"{Validate.EnoughCash(menu.ReceiptTotal(), Console.ReadLine())}");
            return payment;
        }

        public static List<string> PaymentCredit()
        {
            var payment = new List<string>();
            Console.Write($"Please enter the credit card number: ");
            payment.Add($"Credit:\n {Validate.CardNumber(Console.ReadLine())}");
            Console.Write("Please enter the expiration date in MMYY format: ");
            Validate.CardExp(Console.ReadLine());
            Console.Write("Please enter the CVV: ");
            Validate.CardCVV(Console.ReadLine());
            return payment;
        }

        public static List<string> PaymentCheck()
        {
            var payment = new List<string>() { "Check:\t\t" };
            Console.WriteLine($"Please enter the check number (3 - 4 digits): ");
            Validate.CheckNo(Console.ReadLine());
            return payment;
        }
    }
}
