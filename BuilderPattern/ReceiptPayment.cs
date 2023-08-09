using System.Text;

namespace BuilderPattern;
internal class ReceiptPayment
{
    public string Title { get; set; } = string.Empty;
    public ProductsBody Body { get; set; } = new ProductsBody();
    public string? Wish { get; set; }
    public string? BottomText { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("-------------------------------------------");
        sb.AppendLine($"--{Title}--{Environment.NewLine}{Body}");
        if (Wish is not null) sb.AppendLine($"*{Wish}*");
        if (BottomText is not null) sb.AppendLine(BottomText);
        sb.AppendLine("-------------------------------------------");

        return sb.ToString();
    }
}
public class ProductsBody
{
    private double _tax = 0;

    public List<Product> Products { get; set; } = new List<Product>();
    public double Tax
    {
        get => _tax; 
        set
        {
            if (value < 0 || value > 1) 
                throw new ArgumentOutOfRangeException(nameof(Tax), value, null);

            _tax = value;
        }
    }
    public decimal TotalPrice 
    {
        get
        {
            var price = Products.Sum(p => p.Price * p.Count);
            var tax = price * (decimal)Tax;

            return price - tax;
        }
    }

    public override string ToString()
    {
        if (Products.Count == 0)
            return "There is no products in this payment receipt.";

        var sb = new StringBuilder();
    
        foreach (var p in Products)
            sb.AppendLine(p.ToString());

        sb.AppendLine($"Tax: {Tax * 100}%");
        sb.AppendLine($"Overall: {TotalPrice}");

        return sb.ToString();
    }
}
public class Product
{
    private int _count = 1;

    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Count
    {
        get => _count;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(Count), value, null);

            _count = value;
        }
    }

    public override string ToString()
        => $"{Count} {Name} by {Price}: {Price * Count}";
}