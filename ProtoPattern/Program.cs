using ProtoPattern;

//Prototype - pattern for cloning objects by declaring special interface for this object.

var facebookUsersDataStorage = new FacebookUsersDataStorage();

/*
 In this application this pattern using in FacebookUsersDataStorage for adding users.
 Users is creating inside of AddUser by single prototype which cloning and creating 
 other User object with modified specific user data.
*/
facebookUsersDataStorage.AddUser("Pavel pavel", 5, "pavel.pavel1@gmail.com");
facebookUsersDataStorage.AddUser("cmer", 22, "askas.astro@gmail.com");
facebookUsersDataStorage.AddUser("Burger", 125, "very.profitable.man@gmail.com");

AllUsers(facebookUsersDataStorage);

Console.WriteLine("Try to change first user identifier to empty guid.");

/*
 Also Prototype using when 
 UsersInformation is called for getting information about users, this property returns cloned 
 users objects from system.
*/
facebookUsersDataStorage.UsersInformation.First().Id = Guid.Empty;

AllUsers(facebookUsersDataStorage);

void AllUsers(FacebookUsersDataStorage dataStorage)
{
    Console.WriteLine("All users:");
    foreach (var u in dataStorage.UsersInformation)
        Console.WriteLine($"{{{u.Id}}} {u.Name}. Age: {u.Age}, " +
                          $"Contacts: {u.Contacts}. Platform: {u.Platform}");
}
