// Lägger man till ett ; på slutet så slipper man {} runt namepsace!
namespace SpectreTablesToRefactor.Models;

internal class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }
}
