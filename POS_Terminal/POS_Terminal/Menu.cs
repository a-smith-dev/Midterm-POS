using System;
using System.Collections.Generic;
using System.IO;

namespace POS_Terminal
{
   public class Menu
   {
        private List<Product> _menu;
        private List<Product> _receipt;
        private string _path = Path.Combine(Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp3.1", ""), "menu.txt");

        public Menu()
        {
            _menu = new List<Product>();
            _receipt = new List<Product>();
            FillMenu();
        }

        private void FillMenu()
        {
            using (var sr = new StreamReader(_path))
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

        public void DisplayMenu()
        {
            var counter = 1;
            foreach (var item in _menu)
            {
                Console.WriteLine($"{counter}. {item.Name} \t${item.Price}");
                Console.WriteLine($"{item.Description}\n");
                counter++;
            }
        }

        public void EmptyMenu()
        {
            using (var sw = new StreamWriter(_path, append: false))
            {
                var itemLine = string.Empty;
                foreach (var product in _menu)
                {
                    itemLine = $"{product.Name}!{product.Category}!{product.Description}!{product.Price}!{product.Quantity}!";
                    sw.WriteLine(itemLine);
                }
            }
        }

        public int GetCount()
        {
            return _menu.Count;
        }

        // Add items to a receipt
        public bool AddProduct(int index)
        {
            index--;

            if (_menu[index].Quantity == 0)
            {
                Console.WriteLine($"I'm sorry, we're out of {_menu[index].Name}s. Please choose another item.");
                return false;
            }

            if (_menu[index].Category != "Drink")
            {
                _receipt.Add(new Product(_menu[index].Name, _menu[index].Price));
            }
            else
            {
                _receipt.Add(new Drink(_menu[index].Name, _menu[index].Price));
            }

            AskQuantity(index);
            return true;
        }

        public void AskQuantity(int index)
        {
            var recentItem = _receipt.Count - 1;

            Console.Write($"How many {_receipt[recentItem].Name}s would you like? There are {_menu[index].Quantity} available. ");
            var response = Validate.NumberInRange(Console.ReadLine(), _menu[index].Quantity);

            _receipt[recentItem].Quantity = response;
            _menu[index].Quantity -= response;
        }

        public void DisplayReceipt(List<string> payment)
        {
            if (payment.Count == 1)
            {
                payment.Add($"{ReceiptTotal()}");
            }

            var dashedLine = "-------------------------------------------------------";
            var counter = 1;
            decimal subtotal = 0;
            
            Console.WriteLine($"\n{dashedLine}");
            Console.WriteLine(" ITEM NAME\t\t\tQTY\t\tAMOUNT");
            Console.WriteLine(dashedLine);

            foreach (var item in _receipt)
            {
                var itemSubtotal = Calculate.Subtotal(item.Price, item.Quantity);
                subtotal += itemSubtotal;
                Console.WriteLine($" {counter}. {item.Name}   \t\t{item.Quantity} x {item.Price:C}\t{itemSubtotal:C}");
                counter++;
            }

            Console.WriteLine(dashedLine);
            Console.WriteLine($" Subtotal:\t\t\t\t\t{subtotal:C}");
            Console.WriteLine($" Tax {Calculate.ShowTax() * 100}%:\t\t\t\t\t{Calculate.SubtotalTax(subtotal):C}");
            Console.WriteLine($" Total:\t\t\t\t\t\t{Calculate.Total(subtotal):C}");
            Console.WriteLine($" {payment[0]}  \t\t\t\t{decimal.Parse(payment[1]):C}");
            Console.WriteLine($" Change:\t\t\t\t\t{Calculate.Change(payment[1], ReceiptTotal()):C}");
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