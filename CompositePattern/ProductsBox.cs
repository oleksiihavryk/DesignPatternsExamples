namespace CompositePattern;
internal class ProductsBox : IProduct
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public decimal Price => Products.Sum(p => p.Price);
    public ICollection<IProduct> Products { get; set; } = new List<IProduct>();
}