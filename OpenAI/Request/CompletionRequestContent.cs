using System.Text.Json.Serialization;

namespace OpenAI_Basic_Console_Only.OpenAI.Request;

public class CompletionRequestContent
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}
