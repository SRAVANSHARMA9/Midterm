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
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        Price = newPrice;
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        if (additionalQuantity < 0)
        {
            Console.WriteLine($"\nError: Restocking quantity for {ItemName} cannot be negative.");
            return;

        }

        QuantityInStock += additionalQuantity;
    }

    // Sell an item
    public void SellItem(int quantitySold)
    {
        
        if (quantitySold > QuantityInStock)
        {
            Console.WriteLine($"\nError: Not enough {ItemName}s in stock.");
            return;
        }

        QuantityInStock -= quantitySold;
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        return QuantityInStock > 0;
    }

    // Print item details
    public void PrintDetails()
    {
        Console.WriteLine($"Item : {ItemName}, ID: {ItemId}, Price: ${Price}, Stock Quantity: {QuantityInStock}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of InventoryItem
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);

        // Example tasks:
        // 1. Print details of all items.
        Console.WriteLine("Given details of the items. \n");
        item1.PrintDetails();
        item2.PrintDetails();

        // 2. Sell some items and then print the updated details.
        item1.SellItem(6);
        item2.SellItem(9);

        Console.WriteLine("\nAfter selling items: \n");
        item1.PrintDetails();
        item2.PrintDetails();

        // 3. Restock an item and print the updated details.
        item1.RestockItem(10);
        item2.RestockItem(10);

        Console.WriteLine("\nAfter restocking both the items: \n");
        item1.PrintDetails();
        item2.PrintDetails();

        // 4. Check if an item is in stock and print a message accordingly.
        Console.WriteLine("\nStock Status for both items.\n");

        Console.WriteLine($"Item 1 (Laptop) is in stock : {item1.IsInStock()}");
        Console.WriteLine($"Item 2 (Smartphone) is in stock : {item2.IsInStock()}");
    }
}
