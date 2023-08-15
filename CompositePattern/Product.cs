namespace CompositePattern;
internal class Product : IProduct
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public decimal Price { get; init; }
}