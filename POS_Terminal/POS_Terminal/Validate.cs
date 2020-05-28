using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Terminal
{
    public abstract class Validate
    {
        // Define methods to validate user input based on context.

        public static int PositiveNumber(string input)
        {
            var number = 0;
            while (int.TryParse(input, out number) || number < 1)
            {
                Console.Write("Please enter a positive number");
                input = Console.ReadLine();
            }
            return number;
        }

        public static int ValidQuantity(Product item, int amount)
        {
            while (amount > item.Quantity)
            {
                Console.Write($"{item.Name} has {item.Quantity} available. Please enter a smaller number.");
                amount = PositiveNumber(Console.ReadLine());
            }
            return amount;
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
    }
}
