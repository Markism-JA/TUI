using System.Reflection;

namespace LabExe2
{
    class Table
    {
        public void AddRow(List<Product> products)
        {
            Console.WriteLine();
            // Creating a list to store the single input product

            // Retrieve properties of the Product type
            Type type = typeof(Product);
            PropertyInfo[] properties = type.GetProperties();

            // Print header row with 2-char indent
            foreach (PropertyInfo property in properties)
            {
                Console.Write($"  {property.Name,-20}");
            }

            Console.WriteLine();
            Console.WriteLine("  " + new string('-', properties.Length * 20 + 5));

            // Print each product's property values with alignment
            foreach (var product in products)
            {
                foreach (PropertyInfo property in properties)
                {
                    var value = property.GetValue(product) ?? "N/A";
                    Console.Write($"  {value,-20}");
                }
                Console.WriteLine();
            }
        }
    }
}