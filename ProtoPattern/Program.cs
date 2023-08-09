using ProtoPattern;

var facebookUsersDataStorage = new FacebookUsersDataStorage();

facebookUsersDataStorage.AddUser("Pavel pavel", 5, "pavel.pavel1@gmail.com");
facebookUsersDataStorage.AddUser("cmer", 22, "askas.astro@gmail.com");
facebookUsersDataStorage.AddUser("Burger", 125, "very.profitable.man@gmail.com");

AllUsers(facebookUsersDataStorage);

Console.WriteLine("Try to change first user identifier to empty guid.");

facebookUsersDataStorage.UsersInformation.First().Id = Guid.Empty;

AllUsers(facebookUsersDataStorage);

void AllUsers(FacebookUsersDataStorage dataStorage)
{
    Console.WriteLine("All users:");
    foreach (var u in dataStorage.UsersInformation)
        Console.WriteLine($"{{{u.Id}}} {u.Name}. Age: {u.Age}, " +
                          $"Contacts: {u.Contacts}. Platform: {u.Platform}");
}
