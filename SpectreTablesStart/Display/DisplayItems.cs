using Spectre.Console;
using SpectreTablesToRefactor.Models;

// Lägger man till ett ; på slutet så slipper man {} runt namepsace!
namespace SpectreTablesToRefactor.UI;

internal class DisplayItems
{
    static internal void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Namn");
        table.AddColumn("Pris");

        foreach (Product product in products)
        {
            table.AddRow(
                product.ProductId.ToString(),
                product.Name,
                product.Price.ToString()
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Valfri tangent för att återgå till huvudmeny");
        Console.ReadLine();
        Console.Clear();
    }

    static internal void ShowProduct(Product product)
    {
        var panel = new Panel($@"Id: {product.ProductId}
Namn: {product.Name}
Pris: {product.Price}");
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Valfri tangent för att återgå till huvudmeny");
        Console.ReadLine();
        Console.Clear();
    }
}
