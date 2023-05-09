using System.Text.Json.Serialization;

namespace CreditAppWeb.Shared.Models;

public class Exception
{
    [JsonPropertyName("message")] public string Message { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("aplication")] public object Aplication { get; set; }

    [JsonPropertyName("statusCode")] public int StatusCode { get; set; }
}