using BuilderPattern;

var receiptBuilder = new ReceiptPaymentBuilder()
    .AddTitle("Receipt payment of TTT store")
        .CreateBody()
        .AddProduct(name: "Coca-Cola 0.5l", count: 1, price: 15.5m)
        .AddProduct(name: "Snickers small", count: 2, price: 22.9m)
        .AddProduct(name: "Bear \"Parsh\" 0.5l", count: 1, price: 21.9m).ChangeTax(0.2)
    .AddWish("Wish you luck!")
    .AddBottomText("Comeback later!");

ReceiptPayment receipt = receiptBuilder;

Console.WriteLine("Check with tax 20%:");
Console.WriteLine(receipt);

receiptBuilder.ChangeBody().ChangeTax(0.3);

Console.WriteLine("Change check tax to 30%:");
Console.WriteLine(receipt);