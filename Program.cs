class Program
{
    static void Main()
    {
        List<string> menuItems = new List<string>();
        List<decimal> menuPrices = new List<decimal>();
        List<string> orderedItems = new List<string>();
        List<decimal> orderedPrices = new List<decimal>();

       

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1 - Add Menu Item");
            Console.WriteLine("2 - View Menu");
            Console.WriteLine("3 - Place Order");
            Console.WriteLine("4 - View Order");
            Console.WriteLine("5 - Calculate Total");
            Console.WriteLine("6 - Exit");
            Console.Write("Enter a command: ");
            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Enter new menu item: ");
                    string newItem = Console.ReadLine();
                    Console.Write("Enter price of the item: ");
                    decimal newPrice;
                    while (!decimal.TryParse(Console.ReadLine(), out newPrice) || newPrice < 0)
                    {
                        Console.Write("Invalid price. Please enter a valid price: ");
                    }
                    menuItems.Add(newItem);
                    menuPrices.Add(newPrice);
                    Console.WriteLine($"{newItem} has been added to the menu at {newPrice}peso(s)");
                    Console.WriteLine(" ");
                    Console.Write("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    if (menuItems.Count > 0)
                    {
                        Console.WriteLine("Menu:");
                        for (int i = 0; i < menuItems.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {menuItems[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The menu is empty.");
                    }
                    Console.WriteLine(" ");
                    Console.Write("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "3":
                    if (menuItems.Count > 0)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the number of the item you want to order (or type 'done' to finish):");
                            for (int i = 0; i < menuItems.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}: {menuItems[i]} - {menuPrices[i]}");
                            }

                            string input = Console.ReadLine();

                            if (input.ToLower() == "done")
                            {
                                break;
                            }

                            int itemNumber;
                            if (int.TryParse(input, out itemNumber) && itemNumber > 0 && itemNumber <= menuItems.Count)
                            {
                                orderedItems.Add(menuItems[itemNumber - 1]);
                                orderedPrices.Add(menuPrices[itemNumber - 1]);
                                Console.WriteLine($"{menuItems[itemNumber - 1]} has been added to your order.");
                                Console.WriteLine(" ");
                                Console.Write("Press enter to continue...");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Invalid item number.");
                                Console.WriteLine(" ");
                                Console.Write("Press enter to continue...");
                                Console.ReadLine();
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The menu is empty. Add items to the menu first.");
                        Console.WriteLine(" ");
                        Console.Write("Press enter to continue...");
                        Console.ReadLine();
                    }
                    break;

                case "4":
                    Console.Clear();
                    if (orderedItems.Count > 0)
                    {
                        Console.WriteLine("Your Order:");
                        for (int i = 0; i < orderedItems.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {orderedItems[i]} - {orderedPrices[i]} peso(s)");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You haven't ordered anything yet.");
                    }
                    Console.WriteLine(" ");
                    Console.Write("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "5":
                    Console.Clear();
                    if (orderedPrices.Count > 0)
                    {
                        decimal total = 0;
                        Console.WriteLine("Order Summary:");
                        for (int i = 0; i < orderedItems.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {orderedItems[i]} - {orderedPrices[i]} peso(s)");
                            total += orderedPrices[i];
                        }
                        Console.WriteLine($"Total amount due: {total} peso(s)");

                        // Handling payment
                        Console.Write("Enter payment amount: ");
                        decimal amountPaid;
                        while (!decimal.TryParse(Console.ReadLine(), out amountPaid) || amountPaid < total)
                        {
                            Console.WriteLine($"The amount entered is insufficient. The total amount due is {total} peso(s). \nPlease enter a valid amount: ");
                        }

                        decimal change = amountPaid - total;
                        Console.WriteLine($"Payment successful! Your change is {change} peso(s).");

                        // Clear the orders after payment
                        orderedItems.Clear();
                        orderedPrices.Clear();
                        Console.WriteLine("All orders have been cleared.");
                    }
                    else
                    {
                        Console.WriteLine("No items ordered.");
                    }
                    Console.WriteLine(" ");
                    Console.Write("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "6":
                    Console.WriteLine("Exiting the application.");
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid command. Please try again.");
                    Console.WriteLine(" ");
                    Console.Write("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
