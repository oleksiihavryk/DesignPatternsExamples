using AdapterPattern;

Console.WriteLine("Enter your user identifier");
var id = 0;
while (true)
{
    try
    {
        id = Convert.ToInt32(Console.ReadLine());
        break;
    }
    catch (FormatException) { }
}
Console.WriteLine("Enter your user password");
var password = Console.ReadLine() ?? string.Empty;

//class with interface which cannot be changed
var authenticationHttpClient = new AuthenticationHttpClient("https://dummyjson.com");

/*  ||  interface that need an information which you cannot           ||
    \/  easily get from AuthenticationHttpClient object interface.    \/ */
bool CheckUserPassword(string userPassword, string enteredPassword)
    => userPassword.Equals(enteredPassword, StringComparison.Ordinal);

/* interfaces of AuthenticationHttpClient and bool CheckUserPassword(
 * string userPassword, string enteredPassword)
 * is obviously not compatible, for that kind of situations you surely need an Adapter!
 */
var adapter = new UserDataAdapter(authenticationHttpClient);
var user = await adapter.GetUserDataAsync(id);

Console.WriteLine($"This entered password for user id: {id} is " +
                  (CheckUserPassword(user.Password, password) ? "correct" : "incorrect"));
