using System.Text.Json.Serialization;

namespace OpenAI_Basic_Console_Only.OpenAI.Response;

public class CompletionResponse
{
    [JsonPropertyName("choices")]
    public required List<CompletionResponseChoice> Choices { get; set; }
}
