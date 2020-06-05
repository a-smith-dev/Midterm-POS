using System;

namespace POS_Terminal
{
    public class Drink : Product
    {
        public Drink()
        {

        }
        public Drink(string name, decimal price)
        {
            Name = name;
            Price = price;
            Console.Write("What size would you like? (enter small, medium, or large) ");
            switch (Validate.Size(Console.ReadLine()))
            {
                case "small":
                    Name += " (S)";
                    break;
                case "medium":
                    MakeSizeMedium();
                    break;
                case "large":
                    MakeSizeLarge();
                    break;
            }
        }

        public void MakeSizeMedium()
        {
            Price *= (decimal)1.10;
            Name += " (M)";
        }       

        public void MakeSizeLarge()
        {
            Price *= (decimal)1.20;
            Name += " (L)";
        }
    }
}