using System.Net.Http.Json;
using FactoryMethodPattern;

var apiService = new ExternalApiService(
    url: "https://jsonplaceholder.typicode.com/posts", 
    client: new HttpClient());

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