namespace FacadePattern;

internal class Slot
{
    public Product Product { get; set; }
    public bool IsSold { get; set; }

    public override string ToString()
        => $"{Product.Name} by {Product.Cost} price with owner {Product.Owner.Username} " +
           $"is {(IsSold ? "" : "not ")}sold";
}
