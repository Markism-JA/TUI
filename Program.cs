namespace LabExe2;

class Program
{
    static void Main()
    {
        bool flag = true;
        while (flag)
        {
            Product product = new Product();
            AddProduct addProduct = new AddProduct(); 
            flag = addProduct.Form(product);
        }
    }
}