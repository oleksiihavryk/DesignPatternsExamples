using System.Reflection.Metadata.Ecma335;

namespace BuilderPattern;
internal class ReceiptPaymentBuilder
{
    private ProductsBodyBuilder? _productsBodyBuilder;
    
    protected ReceiptPayment ReceiptPayment { get; set; }

    public ReceiptPaymentBuilder()
        : this(new ReceiptPayment())
    {
    }
    public ReceiptPaymentBuilder(ReceiptPayment receiptPayment)
    {
        ReceiptPayment = receiptPayment;
    }

    public ReceiptPaymentBuilder AddTitle(string title)
    {
        ReceiptPayment.Title = title;
        return this;
    }
    public ReceiptPaymentBuilder AddBottomText(string bottomText)
    {
        ReceiptPayment.BottomText = bottomText;
        return this;
    }
    public ReceiptPaymentBuilder AddWish(string wish)
    {
        ReceiptPayment.Wish = wish;
        return this;
    }

    public ProductsBodyBuilder CreateBody()
    {
        _productsBodyBuilder = new ProductsBodyBuilder(ReceiptPayment);
        return _productsBodyBuilder;
    }
    public ProductsBodyBuilder ChangeBody() => _productsBodyBuilder ?? CreateBody();
    

    public ReceiptPayment Create()
    {
        return ReceiptPayment;
    }
    
    public static implicit operator ReceiptPayment(ReceiptPaymentBuilder builder)
        => builder.Create();
}

internal class ProductsBodyBuilder : ReceiptPaymentBuilder
{
    public ProductsBodyBuilder(ReceiptPayment receiptPayment)
    {
        ReceiptPayment = receiptPayment;
    }

    public ProductsBodyBuilder AddProduct(string name, int count, decimal price)
    {
        var p = new Product()
        {
            Name = name,
            Count = count,
            Price = price
        };
        ReceiptPayment.Body.Products.Add(p);
        return this;
    }
    public ProductsBodyBuilder ChangeTax(double tax)
    {
        ReceiptPayment.Body.Tax = tax;
        return this;
    }
}