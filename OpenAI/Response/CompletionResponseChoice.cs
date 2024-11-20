using System.Text.Json.Serialization;

namespace OpenAI_Basic_Console_Only.OpenAI.Response;

public class CompletionResponseChoice
{
    [JsonPropertyName("message")]
    public required CompletionResponseMessage Message { get; set; }
}
