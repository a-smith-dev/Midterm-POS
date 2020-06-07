using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace POS_Terminal
{
    public abstract class Validate
    {
        public static int NumberInRange(string input, int max)
        {
            var number = 0;
            while (!int.TryParse(input, out number) || number < 1 || number > max)
            {
                Console.Write($"Please enter a number between 1 and {max}: ");
                input = Console.ReadLine();
            }
            return number;
        }

        public static string Size(string response)
        {
            response = response.ToLower();
            while (response != "small" && response != "medium" && response != "large")
            {
                Console.Write("Please enter small, medium, or large: ");
                response = Console.ReadLine().ToLower();
            }

            return response;
        }

        public static string YesNo(string response)
        {
            response = response.ToLower();
            while (!Regex.IsMatch(response, "^[yn]$"))
            {
                Console.Write("Please enter y or n: ");
                response = Console.ReadLine().ToLower();
            }

            return response;
        }

        public static string PaymentType(string response)
        {
            response = response.ToLower();
            while (response != "cash" && response != "credit" && response != "check")
            {
                Console.Write("Please answer Cash, Credit, or Check: ");
                response = Console.ReadLine().ToLower();
            }

            return response;
        }

        public static decimal EnoughCash(decimal minimum, string amountTendered)
        {
            var number = 0m;
            while (!decimal.TryParse(amountTendered, out number) || number < minimum)
            {
                Console.Write($"The total due is {minimum} please reenter the amount: ");
                amountTendered = Console.ReadLine();
            }

            return number;
        }

        public static string CardNumber(string response)
        {
            while (!Regex.IsMatch(response, @"^\d{16}$"))
            {
                Console.Write("Please enter a 16 digit card number without dashes: ");
                response = Console.ReadLine();
            }

            return Regex.Replace(response, "[0-9](?=[0-9]{4})", "X");
        }

        public static void CardExpiration(string response)
        {
            while (!Regex.IsMatch(response, @"^([1][1-2][2]\d)$|^([0][6-9][2][0])$|^([0]\d[2][1-9])$"))
            {
                Console.Write("Please enter the expiration date in MMYY format: ");
                response = Console.ReadLine();
            }
        }

        public static void CardCVV(string response)
        {
            while (!Regex.IsMatch(response, @"^\d{3}$"))
            {
                Console.Write("Please enter the 3 digit CVV: ");
                response = Console.ReadLine();
            }
        }

        public static void CheckNumber(string response)
        {
            while (!Regex.IsMatch(response, @"^\d{3}$|^\d{4}$"))
            {
                Console.Write("Please enter the 3 - 4 digit check number: ");
                response = Console.ReadLine();
            }
        }
    }
}
