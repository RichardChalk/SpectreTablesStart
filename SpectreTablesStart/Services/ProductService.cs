using SpectreTablesToRefactor.Data;
using SpectreTablesToRefactor.Models;

// Lägger man till ett ; på slutet så slipper man {} runt namepsace!
namespace SpectreTablesStart.Services;

// SINGLETON!
// Vi vill hela tiden hämta samma instance så att vår data är korrekt!
// Om vi tog bort Singleton och skapade en ny instance varje gång...
// skulle endast vår 10 seedade poster finnas kvar! 
internal class ProductService
{
    // Statisk variabel för att hålla singleton-instansen
    private static ProductService _instance;

    // Låsmekanism för trådsäkerhet
    private static readonly object _lock = new object();

    // Privat konstruktor för att förhindra externa instanser
    private ProductService()
    {
        Db = new Database();
    }

    // Statisk metod för att hämta singleton-instansen
    public static ProductService GetInstance()
    {
        // Dubbelkollad låsning för att säkerställa trådsäkerhet
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ProductService();
                }
            }
        }
        return _instance;
    }

    public Database Db { get; private set; }


    internal void AddProduct(Product product)
    {
        Db.Products.Add(product);
    }
    internal List<Product> GetProducts()
    {
        return Db.Products;
    }

    internal Product GetProductById(int id)
    {
        // returnera null om Id inte hittas!
        return Db.Products.SingleOrDefault(x => x.ProductId == id);
    }

    internal void UpdateProduct(Product product)
    {
        // returnera null om Id inte hittas!
        var productToUpdate = Db.Products
            .SingleOrDefault(x => x.ProductId == product.ProductId);

        productToUpdate.Name = product.Name;
        productToUpdate.Price = product.Price;
    }

    internal void DeleteProduct(Product product)
    {
        Db.Products.Remove(product);
    }
}
