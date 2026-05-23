namespace ImobiAPI.Domain.Entities;

public class UsoApiKey
{
    public long Id { get; private set; }
    public int ApiKeyId { get; private set; }
    public string Endpoint { get; private set; }
    public int StatusCode { get; private set; }
    public DateTime CriadoEm { get; private set; }

    protected UsoApiKey()
    {
        Endpoint = null!;
    }

    public UsoApiKey(int apiKeyId, string endpoint, int statusCode)
    {
        ApiKeyId = apiKeyId;
        Endpoint = endpoint;
        StatusCode = statusCode;
        CriadoEm = DateTime.UtcNow;
    }
}