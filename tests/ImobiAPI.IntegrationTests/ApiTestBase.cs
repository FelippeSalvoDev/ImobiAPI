namespace ImobiAPI.IntegrationTests;

public abstract class ApiTestBase
{
    protected readonly HttpClient Client;
    private const string BaseUrl = "http://localhost:5023";

    protected ApiTestBase()
    {
        var apiKey = Environment.GetEnvironmentVariable("IMOBIAPI_TEST_KEY")
            ?? throw new InvalidOperationException("Variável de ambiente IMOBIAPI_TEST_KEY não definida.");

        Client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
        Client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
    }
}