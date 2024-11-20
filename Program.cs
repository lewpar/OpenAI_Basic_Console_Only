using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

// Create a new HttpClient and dispose of it after use
using var client = new HttpClient();

// Define the OpenAI API URL
string openAiApiURL = "https://api.openai.com/v1/completions" ?? string.Empty;

// Define your API key
string openAiApiKey = "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" ?? string.Empty;

// Define the text prompt to send to the API
string prompt = "Generate 3 astronomy multiple-choice quiz questions with correct answers. Format the quiz in valid JSON format. Use the following JSON format but replace single quotes with double quotes: {'Question 1':{'Question':'Sample question?','Options':{'A':'Sample answer 1','B':'Sample answer 2','C':'Sample answer 3','D':'Sample answer 4'},'Answer':'B'}}" ?? string.Empty;

// Define the completion model to use
string model = "text-davinci-003" ?? string.Empty;

// Define the maximum number of tokens in the response
int max_tokens = 1000;

// Define the temperature parameter for controlling the accuracy / creativity of the responses (randomness).
// The lower the value, the more accurate. The higher the value the more creative (random).
double temperature = 0.5;

// Set the HTTP Authentication header using the Bearer scheme and set it to the API key.
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", openAiApiKey);

// Anonymous data object to hold prompt, model, max_tokens, and temperature
var data = new
{
    prompt,
    model,
    max_tokens,
    temperature
};

// Serialize the data object into a JSON string
string json = JsonSerializer.Serialize(data);

// Print the JSON string to the console
Console.WriteLine($"JSON String to send to Open AI API: \n{json}");

// Send a POST request to the OpenAI API with the JSON data
var response = await client.PostAsync(openAiApiURL, new StringContent(json, Encoding.UTF8, "application/json"));

// Get the response status code
string? responseStatusCode = response.StatusCode.ToString();

// Check if the response is successful (status code 2xx)
if (response.IsSuccessStatusCode)
{
    // Read the response content as a string
    string responseContent = await response.Content.ReadAsStringAsync();

    // Print the response content
    Console.WriteLine($"Response Content:\n{responseContent}");
}
else // If the response is not successful
{
    Console.WriteLine($"\nERROR: Failed to generate the quiz. Status code: {responseStatusCode}");
}
