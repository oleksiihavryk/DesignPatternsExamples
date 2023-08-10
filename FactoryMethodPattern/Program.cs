using System.Net.Http.Json;
using FactoryMethodPattern;

/*
 * Factory method - pattern for creating object not from constructor, but from static methods.
 * Biggest advantage of this pattern - ability of async creating objects,
 * because constructors cannot handle thread safe awaiting of async methods.
 */

var apiService = new ExternalApiService(
    url: "https://jsonplaceholder.typicode.com/posts", 
    client: new HttpClient());

/*
 * In this example, factory method using in method ExternalApiService.MakeRequestAsync,
 * there is asynchronously creating a ExternalApiRequest object.
 */
var request = await apiService.MakeRequestAsync();

if (request.ResponseMessage.IsSuccessStatusCode)
{
    var users = await request.ResponseMessage.Content.ReadFromJsonAsync<Post[]>();
    Console.WriteLine($"Request is passed successfully. Users count: {users.Length}.");
}
else
{
    Console.WriteLine("Request is failed.");
}