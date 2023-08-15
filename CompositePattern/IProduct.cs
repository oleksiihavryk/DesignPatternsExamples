namespace CompositePattern;
internal interface IProduct
{
    public Guid Id { get; }
    public string Name { get; set; }
    public decimal Price { get; }
}
