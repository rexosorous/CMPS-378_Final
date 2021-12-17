using System;
using System.Collections.Generic;

/*
Author: J-Zach Loke
Class: CMPS-378
Due Date: 12/16/2021
Description:
    Mimics a POS system that can handle purchases, return, add inventory, and view reports.
*/

namespace Final
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            driver.run();
            Console.ReadKey();
        }
    }



    public class Driver
    {
        public Inventory inv = new Inventory();

        public void run()
        {
            int customers = 0;

            while (true)
            {
                Console.WriteLine("Welcome to Target! Choose the following options:");
                Console.WriteLine("1) Make a Purchase");
                Console.WriteLine("2) Make a Return");
                Console.WriteLine("3) Manage Inventory");
                Console.WriteLine("4) View Report");
                Console.Write("Choose: ");

                int choice = Int32.Parse(Console.ReadLine());
                Console.Write("\n");

                POS merchant;
                switch (choice)
                {
                    case 1:
                        merchant = new Sell();
                        merchant.transaction(inv);
                        customers += 1;
                        break;
                    case 2:
                        merchant = new Return();
                        merchant.transaction(inv);
                        break;
                    case 3:
                        Manage admin = new Manage();
                        admin.run(inv);
                        break;
                    case 4:
                        Console.WriteLine("Reports:");
                        Console.WriteLine("\tTotal Customers: " + customers.ToString());
                        Console.WriteLine("\tTotal Profit: " + inv.getProfit());
                        break;
                }

                Console.Write("Continue? ");
                string cont = Console.ReadLine();
                if (cont == "N") break;
                Console.Write("\n-----------------------------------------------------------------------------------\n\n");
            }
        }
    }



    public struct Item
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public Item(string name, float price) : this()
        {
            this.Name = name;
            this.Price = price;
        }

        public override string ToString()
        {
            return Name.PadRight(20) + "$" + Price.ToString();
        }
    }


    public class Inventory
    {
        public List<Item> stock = new List<Item>();
        public List<Item> sold = new List<Item>();

        public void printStock()
        {
            Console.WriteLine("Item Name".PadRight(20) + "Price");
            foreach (Item i in stock)
            {
                Console.WriteLine(i.ToString());
            }
            Console.Write('\n');
        }

        public void addStock(Item i)
        {
            stock.Add(i);
        }

        public Item takeStock(string itemName)
        {
            for (int i = 0; i < stock.Count; ++i)
            {
                if (stock[i].Name == itemName)
                {
                    Item temp = stock[i];
                    stock.RemoveAt(i);
                    return temp;
                }
            }
            return new Item("null", 0);
        }

        public Item getStock(string itemName)
        {
            for (int i = 0; i < stock.Count; ++i)
            {
                if (stock[i].Name == itemName)
                {
                    return stock[i];
                }
            }
            return new Item("null", 0);
        }

        public void printSold()
        {
            Console.WriteLine("Item Name".PadRight(20) + "Price");
            foreach (Item i in sold)
            {
                Console.WriteLine(i.ToString());
            }
            Console.Write('\n');
        }

        public void addSold(Item i)
        {
            sold.Add(i);
        }

        public Item takeSold(string itemName)
        {
            for (int i = 0; i < sold.Count; ++i)
            {
                if (sold[i].Name == itemName)
                {
                    Item temp = sold[i];
                    sold.RemoveAt(i);
                    return temp;
                }
            }
            return new Item("null", 0);
        }

        public float getProfit()
        {
            float profit = 0;
            foreach (Item i in sold)
            {
                profit += i.Price;
            }
            return profit;
        }
    }



    public abstract class POS
    {
        public string greetingMessage = "Which product would you like to purchase?";
        public string choiceMessage = "Which item would you like to buy? ";
        public string totalMessage = "Your Total is $";
        public string byeMessage = "Thank you for shopping at Target!";

        public void transaction(Inventory inv)
        {
            List<Item> cart = new List<Item>();
            while (true)
            {
                Console.WriteLine(greetingMessage);
                printMenu(inv);
                Console.Write(choiceMessage);
                string itemName = Console.ReadLine();
                cart.Add(getItem(itemName, inv));
                Console.Write("Anything else? ");
                string choice = Console.ReadLine();
                if (choice == "N") break;
                Console.Write("\n");
            }

            float total = 0;
            foreach (Item i in cart)
            {
                total += i.Price;
            }

            placeItems(cart, inv);
            Console.WriteLine(totalMessage + total.ToString());
            Console.WriteLine(byeMessage);
        }

        public abstract void printMenu(Inventory inv);
        public abstract Item getItem(string itemName, Inventory inv);
        public abstract void placeItems(List<Item> cart, Inventory inv);
    }



    public class Sell : POS
    {
        public override void printMenu(Inventory inv)
        {
            inv.printStock();
        }

        public override Item getItem(string itemName, Inventory inv)
        {
            return inv.getStock(itemName);
        }

        public override void placeItems(List<Item> cart, Inventory inv)
        {
            foreach (Item i in cart)
            {
                inv.addSold(i);
            }
        }
    }



    public class Return : POS
    {
        public Return()
        {
            greetingMessage = "Which product would you like to return?";
            totalMessage = "Your Refund total is $";
            choiceMessage = "Which item would you like to return? ";
        }

        public override void printMenu(Inventory inv)
        {
            inv.printSold();
        }

        public override Item getItem(string itemName, Inventory inv)
        {
            return inv.takeSold(itemName);
        }

        public override void placeItems(List<Item> cart, Inventory inv)
        {
            return;
        }
    }


    public class Manage
    {
        public void run(Inventory inv)
        {
            Console.WriteLine("The following items are currently stored in the system:");
            inv.printStock();
            Console.WriteLine("1) Add New Item");
            Console.WriteLine("2) Remove Item");
            Console.WriteLine("3) Main Menu");
            Console.Write("Choose: ");
            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Add Item:");
                    Console.Write("\tItem Name: ");
                    string name = Console.ReadLine();
                    Console.Write("\tItem Price: ");
                    float price = float.Parse(Console.ReadLine());
                    inv.addStock(new Item(name, price));
                    Console.WriteLine("Added Successfully!!");
                    break;
                case 2:
                    Console.WriteLine("Remove Item:");
                    Console.Write("\tItem Name: ");
                    string name2 = Console.ReadLine();
                    inv.takeStock(name2);
                    break;
                case 3:
                    break;
            }
        }
    }
}