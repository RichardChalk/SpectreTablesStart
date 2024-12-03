using Spectre.Console;
using SpectreTablesStart.Services;
using SpectreTablesToRefactor.Models;
using SpectreTablesToRefactor.UI;

// Lägger man till ett ; på slutet så slipper man {} runt namepsace!
namespace SpectreTablesStart.Controllers;

internal class ProductController
{
    public ProductService MyProperty { get; set; }
    internal static void InsertProduct()
    {
        var product = new Product();
        product.ProductId = AnsiConsole.Ask<int>("Produktens Id:");
        product.Name = AnsiConsole.Ask<string>("Produktens namn:");
        product.Price = AnsiConsole.Ask<decimal>("Produtens pris:");

        var productService = ProductService.GetInstance();
        productService.AddProduct(product);
    }

    internal static void GetProducts()
    {
        var productService = ProductService.GetInstance();
        var products = productService.GetProducts();
        DisplayItems.ShowProductTable(products);
    }

    internal static void GetProduct()
    {
        var product = GetProductOptionInput();
        DisplayItems.ShowProduct(product);
    }

    internal static void UpdateProduct()
    {
        var product = GetProductOptionInput();

        if (AnsiConsole.Confirm("Uppdatera namn?"))
            product.Name = AnsiConsole.Ask<string>("Produktens nya namn:");

        if (AnsiConsole.Confirm("Uppdatera pris?"))
            product.Price = AnsiConsole.Ask<decimal>("Produktens nya pris:");

        var productService = ProductService.GetInstance();
        productService.UpdateProduct(product);
    }

    internal static void DeleteProduct()
    {
        var product = GetProductOptionInput();
        var productService = ProductService.GetInstance();
        productService.DeleteProduct(product);
    }


    internal static Product GetProductOptionInput()
    {
        // Get productService
        var productService = ProductService.GetInstance();
        var products = productService.GetProducts();

        // Display produkter för användaren att välja bland
        var productsArrayForDisplay = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Välj Produkt")
            .AddChoices(productsArrayForDisplay));

        // Hitta vald produkt
        var id = products.Single(x => x.Name == option).ProductId;
        var product = productService.GetProductById(id);

        return product;
    }

}
