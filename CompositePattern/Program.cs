using CompositePattern;

/*
 Pattern "Composite" is allowed to communicate with many classes which 
 have one common interface through one class.
 There is one simple and explanatory example of this pattern.
 ProductsBox and Product classes have one interface - IProduct which contains property of price.
 ProductsBox and Product have different implementations of this Price property, 
 when Product is return actual price of product, ProductsBox returns a sum of multiple products 
 which contains in this box.
*/
var p = new ProductsBox
{
    Name = "Box of products #1",
    Products =
    {
        new Product { Name = "Product #1", Price = 3},
        new Product { Name = "Product #2", Price = 12.5m},
        new Product { Name = "Product #3", Price = 12  },
        new ProductsBox
        {
            Name = "Box of products #2",
            Products =
            {
                new Product { Name = "Product #4", Price = 32},
                new Product { Name = "Product #5", Price = 64},
                new ProductsBox()
                {
                    Name = "Box of products #3"
                }
            }
        }
    }
};

Console.WriteLine($"Total price for product - \"{p.Name}\" is {p.Price:C}");