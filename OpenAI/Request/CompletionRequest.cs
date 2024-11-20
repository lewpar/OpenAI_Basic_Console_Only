using System.Text.Json.Serialization;

namespace OpenAI_Basic_Console_Only.OpenAI.Request;

public class CompletionRequest
{
    [JsonPropertyName("model")]
    public required string Model { get; set; } = "gpt-3.5-turbo-1106";

    [JsonPropertyName("messages")]
    public required List<CompletionRequestMessage> Messages { get; set; }

    [JsonPropertyName("temperature")]
    public float Temperature { get; set; } = 0.5f;

    [JsonPropertyName("max_completion_tokens")]
    public int MaxTokens { get; set; } = 1000;
}
