using System.Text.RegularExpressions;

namespace LabExe2
{
    class AddProduct
    {
        private static Dictionary<string, string> inputData = new Dictionary<string, string>();
        private string[] ListOfProductCategory = { "Beverages", "Bread/Bakery", "Canned/Jarred Goods", "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other" };
        private static Table dataTable = new Table();
        private static List<Product> prodcutList = new List<Product>();

        private static List<string> Fields = new List<string>
        {
            "Product", "Category", "Mfg. Date", "Exp. Date", "Qty.", "Sell Price", "Description"
        };

        public void ShowCategory()
        {
            foreach (string item in ListOfProductCategory)
            {
                Console.WriteLine(item);
            }
        }

        public string Index(string[] input)
        {
            int selectedIndex = 0;
            DisplayCategory(input, selectedIndex);
            string? output = null;

            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex == 0) ? ListOfProductCategory.Length - 1 : selectedIndex - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex == ListOfProductCategory.Length - 1) ? 0 : selectedIndex + 1;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        output = ListOfProductCategory[selectedIndex];
                        break;
                }
                DisplayCategory(input, selectedIndex);
            }
            while (key != ConsoleKey.Escape && output == null);
            return output;
        }

        public bool Form(Product product)
        {
            bool continueFlag = false;
            foreach (var field in Fields)
            {
                inputData[field] = null;
            }

            int selectedIndex = 0;
            Console.CursorVisible = false;
            
            product = new Product();
            DisplayForm(Fields, inputData, selectedIndex);
            bool flag;
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex == 0) ? Fields.Count - 1 : selectedIndex - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex == Fields.Count - 1) ? 0 : selectedIndex + 1;
                        break;

                    case ConsoleKey.Enter:
                        if (Fields[selectedIndex] == "Category")
                        {
                            inputData[Fields[selectedIndex]] = Index(ListOfProductCategory);
                            product.category = inputData[Fields[selectedIndex]];
                        }
                        else if (Fields[selectedIndex] == "Mfg. Date" || Fields[selectedIndex] == "Exp. Date")
                        { 
                            
                            Time time = new Time();
                            inputData[Fields[selectedIndex]] = time.Date();
                            switch (Fields[selectedIndex])
                            {
                                case "Mfg. Date":
                                    product.manufacturingDate = inputData[Fields[selectedIndex]];
                                    break;
                                case "Exp. Date":
                                    product.expirationDate = inputData[Fields[selectedIndex]];
                                    break;
                            }
                        }
                        else
                        {
                            Console.CursorVisible = true;
                            Console.SetCursorPosition(Fields[selectedIndex].Length + 4, selectedIndex + 3);
                            Console.Write("".PadRight(Console.WindowWidth - Fields[selectedIndex].Length - 10));
                            Console.SetCursorPosition(Fields[selectedIndex].Length + 4, selectedIndex + 3);
                            string input = Console.ReadLine()!;

                            switch (Fields[selectedIndex])
                            {
                                case "Product":
                                    product.productName = input;
                                    break;
                                case "Qty.":
                                    product.quantity = int.Parse(input);
                                    break;
                                case "Sell Price":
                                    product.sellingPrice = int.Parse(input);
                                    break;
                                case "Description":
                                    product.description = input;
                                    break;
                            }
                            inputData[Fields[selectedIndex]] = input ?? "";
                            Console.CursorVisible = false;
                        }
                        break;
                }

                DisplayForm(Fields, inputData, selectedIndex);
                AddProduct.dataTable.AddRow(AddProduct.prodcutList);
                flag = AddProduct.NullFlag(product);
                if (flag)
                {
                    break;
                }
            }
            while (key != ConsoleKey.Escape);
            
            YesNo yesNo = new YesNo();
            bool submit = yesNo.Submit("Submit");
            if (submit)
            {
                prodcutList.Add(product);
            }
            YesNo continueAdd = new YesNo();
            bool submitAdd = continueAdd.Submit("Continue");
            if (submitAdd)
            {
                continueFlag = true;
            }

            return continueFlag;
        }

        static bool NullFlag(Product product)
        {
            // Check that all fields have valid, non-empty, non-zero values and valid date formats for date fields
            bool flag = !string.IsNullOrEmpty(product.productName) && 
                        !string.IsNullOrEmpty(product.category) && 
                        !string.IsNullOrEmpty(product.manufacturingDate) &&
                        !string.IsNullOrEmpty(product.expirationDate) && 
                        !string.IsNullOrEmpty(product.description) && 
                        product.quantity > 0 && 
                        product.sellingPrice > 0 && 
                        IsValidDate(product.manufacturingDate) && 
                        IsValidDate(product.expirationDate);

            return flag;
        }

        
        
        static bool IsValidDate(string date)
        {
            // Try parsing the date to ensure it's a valid date
            DateTime parsedDate;
            return DateTime.TryParse(date, out parsedDate);
        }

        static void DisplayCategory(string[] options, int selectedIndex)
        {
            Console.Clear();
            Console.WriteLine("\nUse Up/Down arrows to navigate and Enter to select:\n");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"  {options[i]} ");
            }

            Console.ResetColor();
        }

        static void DisplayForm(List<string> fields, Dictionary<string, string> inputData, int selectedIndex)
        {
            Console.Clear();
            Console.WriteLine("\nAdd Product (Use Up/Down arrows to navigate, Enter to edit field):\n");

            for (int i = 0; i < fields.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ResetColor();
                }

                AddProduct.inputData = inputData;

                Console.Write($"  {fields[i]}: ");
                string output = CatchTheInput(fields[i], inputData[fields[i]]);
                Console.WriteLine(output);
            }

            Console.ResetColor();
        }

        private static string CatchTheInput(string field, string inputData)
        {
            AddProduct addProduct = new AddProduct();
            try
            {
                if (string.IsNullOrEmpty(inputData))
                {
                    return "";
                }

                if (field == "Product")
                {
                    return addProduct.Product_Name(inputData);
                }
                else if (field == "Qty.")
                {
                    return addProduct.Quantity(inputData).ToString();
                }
                else if (field == "Sell Price")
                {
                    return addProduct.SellingPrice(inputData).ToString("0.00");
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return inputData;
        }

        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name.ToString(), @"^[a-zA-Z]+$")) throw new StringFormatException();
            return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty.ToString(), @"^[0-9]+$")) throw new NumberFormatException();
            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$")) throw new CurrencyFormatException();
            return Convert.ToDouble(price);
        }
    }
}