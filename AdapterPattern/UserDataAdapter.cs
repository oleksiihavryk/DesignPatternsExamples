using System.Net.Http.Json;

namespace AdapterPattern;
internal class UserDataAdapter : IUserDataAdapter
{
    private readonly IAuthenticationHttpClient _authHttpClient;

    public UserDataAdapter(IAuthenticationHttpClient authHttpClient)
    {
        _authHttpClient = authHttpClient;
    }

    public async Task<User> GetUserDataAsync(int userId)
    {
        var response = await _authHttpClient.GetUserByIdAsync(userId);
        var user = await response.Content.ReadFromJsonAsync<User>();

        if (response.IsSuccessStatusCode == false || user is null)
            throw new ApplicationException();

        return user;
    }
}
internal interface IUserDataAdapter
{
    public Task<User> GetUserDataAsync(int userId);
}