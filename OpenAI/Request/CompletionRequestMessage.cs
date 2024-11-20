using System.Text.Json.Serialization;

namespace OpenAI_Basic_Console_Only.OpenAI.Request;

public class CompletionRequestMessage
{
    [JsonPropertyName("role")]
    public required string Role { get; set; }

    [JsonPropertyName("content")]
    public required List<CompletionRequestContent> Content { get; set; }
}
