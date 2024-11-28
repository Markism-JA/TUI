using System.Xml;

namespace LabExe2;

/// <summary>
/// An updated implementation of adding a product, that usess the <see cref="TUIManager"/>
/// and the <see cref="Navigator"/>
/// </summary>
class UpdatedAddProduct
{
    /// <summary>
    /// A user interface manager for displaying and interacting with the UI.
    /// </summary>
    private readonly TUIManager tuiManager = new TUIManager();

    /// <summary>
    /// A navigation handler for traversing menus and forms.
    /// </summary>
    private readonly Navigator navigator = new Navigator();

    /// <summary>
    /// Stores user input during form completion for each field.
    /// </summary>
    private static Dictionary<string, string> inputData = new Dictionary<string, string>();

        /// <summary>
    /// List of predefined product categories available for selection.
    /// </summary>
    private string[] ListOfProductCategory = 
    { 
        "Beverages", "Bread/Bakery", "Canned/Jarred Goods", 
        "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other" 
    };

    /// <summary>
    /// List of fields required to create a product.
    /// </summary>
    private static List<string> Fields = new List<string>
    {
        "Product", "Category", "Mfg. Date", "Exp. Date", "Qty.", "Sell Price", "Description"
    };

    /// <summary>
    /// Displays a menu for the user to select a product category.
    /// </summary>
    /// <returns>The selected category as a string, or null if no selection was made.</returns>
    public string SelectCategory()
    {
        // Navigates through the category list and displays the options
        int selectedIndex = navigator.NavigateMenu(ListOfProductCategory, 
            index => tuiManager.DisplayCategory(ListOfProductCategory, index));
        return selectedIndex >= 0 ? ListOfProductCategory[selectedIndex] : null;
    }

    /// <summary>
    /// Displays a form for the user to fill in product details.
    /// </summary>
    /// <param name="product">The product object to populate with user-entered data.</param>
    /// <returns>True if the product data is successfully entered and validated; otherwise, false.</returns>
    public bool FillForm(Product product)
    {
        // Reset input data for each field
        foreach (var field in Fields)
            inputData[field] = null;

        int selectedIndex;
        do
        {
            // Navigate through the form fields
            selectedIndex = navigator.NavigateForm(Fields, inputData, 
                index => tuiManager.DisplayForm(Fields, inputData, index));

            if (selectedIndex >= 0)
            {
                if (Fields[selectedIndex] == "Category")
                {
                    inputData[Fields[selectedIndex]] = SelectCategory();
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
                    
                } else 
                {
                    Console.CursorVisible = true;
                    Console.SetCursorPosition(Fields[selectedIndex].Length + 4, selectedIndex + 3);
                    inputData[Fields[selectedIndex]] = Console.ReadLine() ?? "";
                    Console.CursorVisible = false;
                }
            }
        } while (selectedIndex >= 0);

        // Validate and map data to the product object
        return ValidateAndSave(product);
    }

    /// <summary>
    /// Validates and saves the input data into the given product object.
    /// </summary>
    /// <param name="product">The product object to populate.</param>
    /// <returns>True if validation and mapping are successful; otherwise, false.</returns>
    private bool ValidateAndSave(Product product)
    {
        try
        {
            // Map input data to product fields
            product.productName = inputData["Product"];
            product.category = inputData["Category"];
            product.manufacturingDate = inputData["Mfg. Date"];
            product.expirationDate = inputData["Exp. Date"];
            product.quantity = int.Parse(inputData["Qty."]);
            product.sellingPrice = double.Parse(inputData["Sell Price"]);
            product.description = inputData["Description"];
            //Map your data to the database using this method 

            // Additional validation rules could be implemented here
            return true;
        }
        catch
        {
            //You can use similar method structure like this for exception handling
            return false;
        }
    }
}
