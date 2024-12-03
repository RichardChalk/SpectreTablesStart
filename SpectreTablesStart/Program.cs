using Spectre.Console;
using SpectreTablesStart.Controllers;
using SpectreTablesToRefactor.Enums;

// Lägger man till ett ; på slutet så slipper man {} runt namepsace!
namespace SpectreTablesToRefactor;
internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            // Sprectre menyval!
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOptions>()
                .Title("Vad vill du göra?")
                .UseConverter(option => option.GetDescription()) // Visa beskrivningar istället för enum-namn
                .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (option)
            {
                case MenuOptions.AddProduct:
                    ProductController.InsertProduct();
                    break;
                case MenuOptions.ViewAllProducts:
                    ProductController.GetProducts();
                    break;

                case MenuOptions.ViewProduct:
                    ProductController.GetProduct();
                    break;
                case MenuOptions.UpdateProduct:
                    ProductController.UpdateProduct();
                    break;
                case MenuOptions.DeleteProduct:
                    ProductController.DeleteProduct();
                    break;
                case MenuOptions.Exit:
                    return;
                default:
                    break;
            }
        }
    }

  


}
