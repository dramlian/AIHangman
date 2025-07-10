using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class LocalAIModelProvider : IAIConnector
{
    readonly string uri;
    readonly string model;
    readonly IChatClient chatClient;

    public LocalAIModelProvider(string uri, string model)
    {
        this.uri = uri;
        this.model = model;
        chatClient = PrepareChatClient();
    }

    private IChatClient PrepareChatClient()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddChatClient(new OllamaChatClient(new Uri(uri), model));

        var app = builder.Build();

        return app.Services.GetRequiredService<IChatClient>();
    }

    public async Task<string> GetResponseAsync(string prompt)
    {
        return (await chatClient.GetResponseAsync(prompt)).Text.Trim();
    }

}