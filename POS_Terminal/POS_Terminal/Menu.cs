using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POS_Terminal
{
   public class Menu
   {
       private List<Product> _menu;

       //var menu = new Menu();
       //menu.FillMenu();
       //menu.Display();


       public Menu()
       {
            _menu = new List<Product>();
       }

       public Product Item(int index)
       {
           return _menu[index];
       }

       public void Display()
       {
           foreach (var item in _menu)
           {
               Console.WriteLine(item.Name);
               Console.WriteLine(item.Description);
               Console.WriteLine(item.Price);
           }
       }

        public void FillMenu()
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

    }
}
