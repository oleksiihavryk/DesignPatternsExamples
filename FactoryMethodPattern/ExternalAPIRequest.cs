namespace FactoryMethodPattern;
internal class ExternalApiRequest
{
    private readonly ExternalApiService _apiService;

    public HttpResponseMessage ResponseMessage { get; }

    private ExternalApiRequest(
        ExternalApiService apiService,
        HttpResponseMessage response)
    {
        _apiService = apiService;
        ResponseMessage = response;
    }

    public static async Task<ExternalApiRequest> CreateRequestAsync(
        ExternalApiService apiService,
        Task<HttpResponseMessage> request)
    {
        var response = await request;
        return new ExternalApiRequest(apiService, response);
    }
}