namespace FacadePattern;
internal class Product
{
    public User Owner { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Cost { get; set; }

    public override string ToString()
        => $"{Name}, {(Description is null ? "" : $"({Description})")} by cost: {Cost} and belong to {Owner.Username}";
}