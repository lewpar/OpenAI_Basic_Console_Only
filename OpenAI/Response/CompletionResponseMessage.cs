using System.Text.Json.Serialization;

namespace OpenAI_Basic_Console_Only.OpenAI.Response;

public class CompletionResponseMessage
{
    [JsonPropertyName("role")]
    public required string Role { get; set; }

    [JsonPropertyName("content")]
    public required string Content { get; set; }
}
