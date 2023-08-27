using System.Text;
using System.Text.Json;
using Azure;
using Azure.AI.OpenAI;

OpenAIClient aiClient = new OpenAIClient("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");
string deploymentName = "text-davinci-003";
string prompt = "Give me a short story.";
string apiUrl = "https://localhost:7158/api/story";

try
{
    Response<Completions> aiResponse = await aiClient.GetCompletionsAsync(deploymentName, prompt);
    string story = string.Concat(aiResponse.Value.Choices.Select(c => c.Text));
    Console.WriteLine(story);

    using var httpClient = new HttpClient();
    string jsonData = JsonSerializer.Serialize(new Story(story, new MetaData("OpenAI", deploymentName, prompt, DateTime.Now)));

    // Create the HTTP content with JSON data
    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

    HttpResponseMessage httpResponse = await httpClient.PostAsync(apiUrl, content);

    if (httpResponse.IsSuccessStatusCode)
    {
        string responseContent = await httpResponse.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
    }
    else
    {
        Console.WriteLine($"Error: {httpResponse.StatusCode}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

record MetaData(string Author, string Model, string Prompt, DateTime DateCreated);
record Story(string StoryText, MetaData MetaData);