using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POS_Terminal
{
   public class Menu
   {
        private List<Product> _menu;
        private List<Product> _receipt; // running total of items the user wants

        public Menu()
        {
            _menu = new List<Product>();
            _receipt = new List<Product>();
            FillMenu();
        }

        public void Display()
        {
             var counter = 1;
             foreach (var item in _menu)
             {
                 Console.WriteLine($"{counter}. {item.Name} \t${item.Price}");
                 Console.WriteLine($"{item.Description}\n");
                 counter++;
             }
        }

        private void FillMenu()
        {
           var currentDirectory = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp3.1", "");
           var path = Path.Combine(currentDirectory, "menu.txt"); // Path is done!
            using (StreamReader sr = new StreamReader(path))
           {
               var counter = 0;
              
               while (!sr.EndOfStream)
               {
                   var line = sr.ReadLine().Split('!');
                   if (line[1] == "Drink")
                   {
                       _menu.Add(new Drink());
                   }
                   else
                   {
                       _menu.Add(new Product());
                   }

                   _menu[counter].Name = line[0];
                   _menu[counter].Category = line[1];
                   _menu[counter].Description = line[2];
                   _menu[counter].Price = (decimal.Parse(line[3]));
                   _menu[counter].Quantity = (int.Parse(line[4]));
                   counter++;
               }
           }
        }

        public string GetItemName(int index)
        {
            index--;
            return _menu[index].Name;
        }

        public string GetItemCategory(int index)
        {
            index--;
            return _menu[index].Category;
        }

        public decimal GetItemPrice(int index)
        {
            index--;
            return _menu[index].Price;
        }

        public int GetItemQuantity(int index)
        {
            index--;
            return _menu[index].Quantity;
        }

        public int GetCount()
        {
            return _menu.Count;
        }

        // Add items to a receipt
        public void AddProduct(int index)
        {
            index--;
            if (_menu[index].Category != "Drink")
            {
                _receipt.Add(new Product());
                _receipt[_receipt.Count - 1].Name = _menu[index].Name;
                _receipt[_receipt.Count - 1].Price = _menu[index].Price;
            }
            else
            {
                _receipt.Add(new Drink(_menu[index].Name, _menu[index].Price));
            }
            AskQuantity(index);
            
        }

        public void AskQuantity(int index)
        {
            var recentItem = _receipt.Count - 1;
            Console.Write($"How many {_receipt[recentItem].Name} would you like? ");
            var response = Validate.PositiveNumber(Console.ReadLine(), _menu[index].Quantity);
            _receipt[recentItem].Quantity = response;
            _menu[index].Quantity -= response;
        }

        public void DisplayReceipt(List<string> payment)   // remember to add payment method
        {
            var total = ReceiptTotal();
            if (payment.Count == 1)
            {
                payment.Add($"{total}");
            }
            var dashedLine = "---------------------------------------------------";
            var counter = 1;
            decimal subtotal = 0;
            decimal itemSubtotal;
            Console.WriteLine($"\n{dashedLine}");
            Console.WriteLine(" ITEM NAME                     QTY           AMOUNT");
            Console.WriteLine(dashedLine);
            foreach (var item in _receipt)
            {
                itemSubtotal = Calculate.Subtotal(item.Price, item.Quantity);
                subtotal += itemSubtotal;
                Console.WriteLine($" {counter}. {item.Name}   {item.Quantity} x {item.Price:C}       {itemSubtotal:C}");
                counter++;
            }
            Console.WriteLine(dashedLine);

            // Calculate subtotal, display tax, and total.
            Console.WriteLine($" Subtotal:                                  {subtotal:C}");
            Console.WriteLine($" Total Tax:                                 {Calculate.SubtotalTax(subtotal):C}");
            Console.WriteLine($" Total:                                     {Calculate.Total(subtotal):C}");
            Console.WriteLine($"{payment[0]}:                               {Calculate.Change(payment[1], total):C}");
            Console.WriteLine(dashedLine);

        }

        public void EmptyReceipt()
        {
            _receipt = new List<Product>();
        }

        public decimal ReceiptTotal()
        {
            var subtotal = 0m;

            foreach (var item in _receipt)
            {
                
                subtotal += Calculate.Subtotal(item.Price, item.Quantity);
                
            }

            return Calculate.Total(subtotal);
        }



    }
}
