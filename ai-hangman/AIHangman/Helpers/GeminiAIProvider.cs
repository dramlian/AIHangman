using System.Text;
using System.Text.Json;

class GeminiAIProvider : IAIConnector
{
    readonly string _apiKey;
    readonly HttpClient _httpClient;

    public GeminiAIProvider()
    {
        DotNetEnv.Env.Load();
        _apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY") ?? throw new InvalidOperationException("GEMINI_API_KEY environment variable is not set.");
        _httpClient = new HttpClient();
    }

    public async Task<string> GetResponseAsync(string prompt)
    {
        var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}";
        var requestBody = @$"{{""contents"": [{{""parts"": [{{""text"": ""{prompt}""}}]}}]}}";
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);
        var responseText = await response.Content.ReadAsStringAsync();
        var geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(responseText);
        return geminiResponse?.candidates?[0]?.content?.parts?[0]?.text?.Trim() ?? string.Empty;
    }
}