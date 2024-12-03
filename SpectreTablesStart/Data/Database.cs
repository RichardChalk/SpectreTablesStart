using SpectreTablesToRefactor.Models;

// Lägger man till ett ; på slutet så slipper man {} runt namepsace!
namespace SpectreTablesToRefactor.Data;

internal class Database
{
    public List<Product> Products { get; set; }
    public Database()
    {
        Products = new List<Product>
        {
            new Product { ProductId = 1, Name = "Electric Kettle", Price = 299.00m },
            new Product { ProductId = 2, Name = "Toaster", Price = 199.00m },
            new Product { ProductId = 3, Name = "Microwave Oven", Price = 1299.00m },
            new Product { ProductId = 4, Name = "Refrigerator", Price = 7999.00m },
            new Product { ProductId = 5, Name = "Washing Machine", Price = 4999.00m },
            new Product { ProductId = 6, Name = "Electric Fan", Price = 399.00m },
            new Product { ProductId = 7, Name = "Hair Dryer", Price = 249.00m },
            new Product { ProductId = 8, Name = "Vacuum Cleaner", Price = 1799.00m },
            new Product { ProductId = 9, Name = "Air Conditioner", Price = 9999.00m },
            new Product { ProductId = 10, Name = "Electric Heater", Price = 699.00m }
        };
    }

}
