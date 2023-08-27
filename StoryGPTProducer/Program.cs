using Azure;
using Azure.AI.OpenAI;

OpenAIClient client = new OpenAIClient("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");
string deploymentName = "text-davinci-003";
string prompt = "Give me a short story.";

try
{
    Response<Completions> response = await client.GetCompletionsAsync(deploymentName, prompt);
    string story = string.Concat(response.Value.Choices.Select(c => c.Text));
    Console.WriteLine(story);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}