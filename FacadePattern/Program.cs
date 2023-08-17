using FacadePattern;

//without facade
var user1 = new User
{
    Email = "some.interesting.email@gmail.com",
    Money = 200,
    Username = "Pavlo"
};
var user2 = new User { Money = 300, Username = "Paras" };
var product = new Product { Cost = 100, Name = "3 bananas", Owner = user1 };
var slot1 = new Slot { IsSold = false, Product = product };

Console.WriteLine("Before buying...");
Console.WriteLine($"First user - {user1}" + Environment.NewLine +
                  $"Second user - {user2}" + Environment.NewLine + 
                  $"Slot - {slot1}" + Environment.NewLine);
Console.WriteLine("\n\n\n\n");

var transaction1 = user2.Buy(slot1);

Console.WriteLine("After buying...");
Console.WriteLine($"First user - {user1}" + Environment.NewLine +
                  $"Second user - {user2}" + Environment.NewLine +
                  $"Slot - {slot1}" + Environment.NewLine +
                  $"Buy transaction - {transaction1}");
Console.WriteLine("\n\n\n\n");

//with facade
var shop = new Shop(); // <- facade
var user3 = shop.RegisterUser("Pavlo (facade)", "some.interesting.email@gmail.com");
var user4 = shop.RegisterUser("Paras (facade)");
var slot2 = shop.RegisterSlot(user3, "3 bananas", 200);

user3.Money = 500;
user4.Money = 400;

Console.WriteLine("Before buying (with facade)....");
Console.WriteLine($"First user - {user3}" + Environment.NewLine +
                  $"Second user - {user4}" + Environment.NewLine +
                  $"Slot - {slot2}" + Environment.NewLine);
Console.WriteLine("\n\n\n\n");

var transaction2 = shop.Buy(user4, slot2);

Console.WriteLine("After buying (with facade)...");
Console.WriteLine($"First user - {user3}" + Environment.NewLine +
                  $"Second user - {user4}" + Environment.NewLine +
                  $"Slot - {slot2}" + Environment.NewLine +
                  $"Buy transaction - {transaction2}");
Console.WriteLine("\n\n\n\n");

/*
 So, as you see, facade is simply represent a one interface for some system.
 In that case class Shop is now give a unify interface for creating users, slots 
 and create buying transactions,
*/