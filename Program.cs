using OpenAI_Basic_Console_Only.OpenAI.Request;
using OpenAI_Basic_Console_Only.OpenAI.Response;

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

// Create a new HttpClient and dispose of it after use
using var client = new HttpClient();

// Define the OpenAI API URL
string openAiApiURL = "https://api.openai.com/v1/chat/completions" ?? string.Empty;

// Define your API key
string openAiApiKey = "sk-proj-eYdYQSGcuaBrl2P" ?? string.Empty;

// Define the text prompt to send to the API
string prompt = "Generate 3 astronomy multiple-choice quiz questions with correct answers. Format the quiz in valid JSON format. Use the following JSON format but replace single quotes with double quotes: {'Question 1':{'Question':'Sample question?','Options':{'A':'Sample answer 1','B':'Sample answer 2','C':'Sample answer 3','D':'Sample answer 4'},'Answer':'B'}}" ?? string.Empty;

// Define the completion model to use
string model = "gpt-3.5-turbo-1106" ?? string.Empty;

// Define the maximum number of tokens in the response
int max_tokens = 1000;

// Define the temperature parameter for controlling the accuracy / creativity of the responses (randomness).
// The lower the value, the more accurate. The higher the value the more creative (random).
float temperature = 0.5f;

// Set the HTTP Authentication header using the Bearer scheme and set it to the API key.
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", openAiApiKey);

// Data object to hold prompt, model, max_tokens, and temperature
var completion = new CompletionRequest()
{ 
    Messages = new List<CompletionRequestMessage>()
    {
        new CompletionRequestMessage()
        {
            Role = "user",
            Content = new List<CompletionRequestContent>()
            {
                new CompletionRequestContent()
                {
                    Type = "text",
                    Text = prompt
                }
            }
        }
    },
    Temperature = temperature,
    MaxTokens = max_tokens,
    Model = "gpt-3.5-turbo-1106"
};

// Serialize the data object into a JSON string
string json = JsonSerializer.Serialize(completion);

// Print the JSON string to the console
Console.WriteLine($"JSON String to send to Open AI API: \n{json}");

// Send a POST request to the OpenAI API with the JSON data
var response = await client.PostAsync(openAiApiURL, new StringContent(json, Encoding.UTF8, "application/json"));

// Get the response status code
string? responseStatusCode = response.StatusCode.ToString();

// Read the response content
var responseContent = await response.Content.ReadAsStringAsync();

// Check if the response is successful (status code 2xx)
if (response.IsSuccessStatusCode)
{
    // Print the response content
    var completionResponse = await response.Content.ReadFromJsonAsync<CompletionResponse>();
    if (completionResponse is null)
    {
        Console.WriteLine("Failed to deserialize response content.");
        return;
    }

    if(completionResponse.Choices.Count < 1)
    {
        Console.WriteLine("Failed to generate completion for prompt.");
        return;
    }

    var choice = completionResponse.Choices.First();

    Console.WriteLine($"Response Content:\n{choice.Message.Content}");
}
else // If the response is not successful
{
    Console.WriteLine($"\nERROR: Failed to generate the quiz. Status code: {responseStatusCode} {responseContent}");
}
