namespace AdapterPattern;
internal sealed class AuthenticationHttpClient : HttpClient, IAuthenticationHttpClient
{
    public Uri BaseUri { get; set; }

    public AuthenticationHttpClient(string baseUri)
    {
        BaseUri = new Uri(baseUri);
    }

    public async Task<HttpResponseMessage> GetUserByIdAsync(int id)
        => await this.SendAsync(new HttpRequestMessage(
            method: HttpMethod.Get,
            requestUri: $"{BaseUri}users/{id}"));
}

internal interface IAuthenticationHttpClient
{
    public Task<HttpResponseMessage> GetUserByIdAsync(int id);
}