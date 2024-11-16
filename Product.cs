namespace LabExe2;

class Product
{
    private int _Quantity;
    private double _SellingPrice;
    private string _ProductName;
    private string _Category;
    private string _ManufacturingDate;
    private string _ExpirationDate;
    private string _Description;

    public Product()
    {
    }

    public Product(string ProductName, string Category, string MfgDate, string ExpDate,
        double Price, int Quantity, string Description)
    {
        this._Quantity = Quantity;
        this._SellingPrice = Price;
        this._ProductName = ProductName;
        this._Category = Category;
        this._ManufacturingDate = MfgDate;
        this._ExpirationDate = ExpDate;
        this._Description = Description;
    }
    
    public string productName
    {
        get => this._ProductName;
        set => this._ProductName = value;
    }

    public string category
    {
        get => this._Category;
        set => this._Category = value;
    }

    public string manufacturingDate
    {
        get => this._ManufacturingDate;
        set => this._ManufacturingDate = value;
    }

    public string expirationDate
    {
        set => this._ExpirationDate = value;
        get => this._ExpirationDate;
    }

    public string description
    {
        get => this._Description;
        set => this._Description = value;
    }

    public int quantity
    {
        get => this._Quantity;
        set => this._Quantity = value;
    }

    public double sellingPrice
    {
        set => this._SellingPrice = value;
        get => this._SellingPrice;
    }
}