using System;

public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        // Initialize the properties with the values passed to the constructor.
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        // Update the item's price with the new price.
        Price = newPrice;
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        // Increase the item's stock quantity by the additional quantity.
        QuantityInStock += additionalQuantity;
    }

    // Sell an item
    public void SellItem(int quantitySold)
    {
        // Decrease the item's stock quantity by the quantity sold.
        // Make sure the stock doesn't go negative.
        if (quantitySold <= QuantityInStock)
        {
            QuantityInStock -= quantitySold;
            Console.WriteLine($"{quantitySold} {ItemName}(s) sold successfully.");
        }
        else
        {
            Console.WriteLine($"Not enough stock available to sell {quantitySold} {ItemName}(s).");
        }
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        // Return true if the item is in stock (quantity > 0), otherwise false.
        return QuantityInStock > 0;
    }

    // Print item details
    public void PrintDetails()
    {
        // Print the details of the item (name, id, price, and stock quantity).
        Console.WriteLine($"Name: {ItemName}");
        Console.WriteLine($"ID: {ItemId}");
        Console.WriteLine($"Price: {Price:C}");
        Console.WriteLine($"Quantity in Stock: {QuantityInStock}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of InventoryItem
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);

        // Print details of all items
        Console.WriteLine("Details of Item 1:");
        item1.PrintDetails();
        Console.WriteLine("Details of Item 2:");
        item2.PrintDetails();

        bool endProgram = false;
        while (!endProgram)
        {
            // Prompt user to choose a function
            Console.WriteLine("Choose a function to invoke:");
            Console.WriteLine("1. Sell an item");
            Console.WriteLine("2. Restock an item");
            Console.WriteLine("3. Check if an item is in stock");
            Console.WriteLine("4. Update the price of an item");
            Console.WriteLine("5. Print item details");
            Console.WriteLine("6. End program");

            // Read user input
            int choice = int.Parse(Console.ReadLine());

            // Perform action based on user choice
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the quantity of laptops to sell:");
                    int laptopsToSell = int.Parse(Console.ReadLine());
                    item1.SellItem(laptopsToSell);
                    Console.WriteLine("Enter the quantity of smartphones to sell:");
                    int smartphonesToSell = int.Parse(Console.ReadLine());
                    item1.SellItem(laptopsToSell);
                    item2.SellItem(smartphonesToSell);
                    break;
                case 2:
                    Console.WriteLine("Enter the quantity of laptops to restock:");
                    int laptopsToRestock = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the quantity of smartphones to restock:");
                    int smartphonesToRestock = int.Parse(Console.ReadLine());
                    item1.RestockItem(laptopsToRestock);
                    item2.RestockItem(smartphonesToRestock);
                    break;
                case 3:
                    Console.WriteLine("Enter the item ID to check if it's in stock:");
                    int itemIdToCheck = int.Parse(Console.ReadLine());
                    if (itemIdToCheck == item1.ItemId)
                    {
                        Console.WriteLine($"Is {item1.ItemName} in stock? {item1.IsInStock()}");
                    }
                    else if (itemIdToCheck == item2.ItemId)
                    {
                        Console.WriteLine($"Is {item2.ItemName} in stock? {item2.IsInStock()}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid item ID.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the new price for the item:");
                    double newPrice = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the item ID to update its price:");
                    int itemIdToUpdatePrice = int.Parse(Console.ReadLine());
                    if (itemIdToUpdatePrice == item1.ItemId)
                    {
                        item1.UpdatePrice(newPrice);
                        Console.WriteLine($"{item1.ItemName}'s price has been updated to {newPrice:C}");
                    }
                    else if (itemIdToUpdatePrice == item2.ItemId)
                    {
                        item2.UpdatePrice(newPrice);
                        Console.WriteLine($"{item2.ItemName}'s price has been updated to {newPrice:C}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid item ID.");
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter the item ID to print its details:");
                    int itemIdToPrintDetails = int.Parse(Console.ReadLine());
                    if (itemIdToPrintDetails == item1.ItemId)
                    {
                        Console.WriteLine("Details of Item 1:");
                        item1.PrintDetails();
                    }
                    else if (itemIdToPrintDetails == item2.ItemId)
                    {
                        Console.WriteLine("Details of Item 2:");
                        item2.PrintDetails();
                    }
                    else
                    {
                        Console.WriteLine("Invalid item ID.");
                    }
                    break;
                case 6:
                    endProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
