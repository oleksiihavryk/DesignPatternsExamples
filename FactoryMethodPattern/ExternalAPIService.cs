namespace FactoryMethodPattern;
internal class ExternalApiService
{
    private readonly Uri _url;
    private readonly HttpClient _client;

    public ExternalApiService(string url, HttpClient client)
    {
        _url = new Uri(url);
        _client = client;
    }

    public async Task<ExternalApiRequest> MakeRequestAsync() => 
        await ExternalApiRequest.CreateRequestAsync(
            apiService: this,
            request: _client.GetAsync(_url));
}