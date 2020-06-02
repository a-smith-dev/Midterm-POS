using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace POS_Terminal
{
    public abstract class Validate
    {
        // Define methods to validate user input based on context.

        public static int PositiveNumber(string input, int max)
        {
            var number = 0;
            while (!int.TryParse(input, out number) || number < 1 || number > max)
            {
                Console.Write($"Please enter a number between 1 and {max}: ");
                input = Console.ReadLine();
            }
            return number;
        }

        public static string ValidChoice(List<Product> items, string choice)
        {
            bool valid = false;
            while (true)
            {
                foreach (var item in items)
                {
                    if (item.Name == choice)
                    {
                        valid = true;
                        break;
                    }
                }
                if (valid)
                {
                    return choice;
                }
                Console.Write("Please enter a valid item from the menu.");
                choice = Console.ReadLine();
            }
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
    }
}
