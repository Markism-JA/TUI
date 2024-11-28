namespace LabExe2;

/// <summary>
/// Main program class containing methods to demonstrate product addition functionality.
/// </summary>
class Program
{
    /// <summary>
    /// Runs the old implementation of adding a product using the <see cref="AddProduct"/> class.
    /// </summary>
    static void RunOldAddProduct()
    {
        bool flag = true;
        while (flag)
        {
            Product product = new Product();
            AddProduct addProduct = new AddProduct(); 
            flag = addProduct.Form(product);
        }
    }

    /// <summary>
    /// Runs the new implementation of adding a product using the <see cref="UpdatedAddProduct"/> class.
    /// </summary>
    /// <remarks>
    /// This method demonstrates:
    /// <list type="bullet">
    /// <item>
    /// <description>Interactive navigation through product fields.</description>
    /// </item>
    /// <item>
    /// <description>Validation of product data before saving.</description>
    /// </item>
    /// <item>
    /// <description>Display of entered product details after successful entry.</description>
    /// </item>
    /// </list>
    /// </remarks>
    static void RunUpdatedAddProduct()
    {
        bool flag = true;
        UpdatedAddProduct updatedAddProduct = new UpdatedAddProduct();

        while (flag)
        {
            Product product = new Product();
            flag = updatedAddProduct.FillForm(product);

            if (flag)
            {
                Console.WriteLine("\nProduct Details Added:");
                Console.WriteLine($"Product Name: {product.productName}");
                Console.WriteLine($"Category: {product.category}");
                Console.WriteLine($"Manufacturing Date: {product.manufacturingDate}");
                Console.WriteLine($"Expiration Date: {product.expirationDate}");
                Console.WriteLine($"Quantity: {product.quantity}");
                Console.WriteLine($"Selling Price: {product.sellingPrice:C}");
                Console.WriteLine($"Description: {product.description}");
            }
            else
            {
                Console.WriteLine("\nProduct entry canceled or invalid input.");
            }

            // Ask the user if they want to continue
            Console.WriteLine("\nDo you want to add another product? (Y/N)");
            var response = Console.ReadKey(true).Key;
            flag = response == ConsoleKey.Y;
        }
    }

    /// <summary>
    ///  Select and run either the old or updated product addition methods. See which of which you want to implement
    /// </summary>
    /// <param name="args">Command-line arguments (not used).</param>
    static void Main(string[] args)
    {
        Console.WriteLine("Choose Mode:");
        Console.WriteLine("1. Old AddProduct");
        Console.WriteLine("2. Updated AddProduct");
        Console.WriteLine("Press the corresponding number to select:");

        ConsoleKey choice = Console.ReadKey(true).Key;
        Console.Clear();

        switch (choice)
        {
            case ConsoleKey.D1:
                RunOldAddProduct();
                break;
            case ConsoleKey.D2:
                RunUpdatedAddProduct();
                break;
            default:
                Console.WriteLine("Invalid selection. Exiting program.");
                break;
        }
    }
}
