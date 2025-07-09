using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class AIConnector
{
    string uri;

    string model;

    public AIConnector(string uri, string model)
    {
        this.uri = uri;
        this.model = model;
    }

    public IChatClient GetChatClient()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddChatClient(new OllamaChatClient(new Uri(uri), model));

        var app = builder.Build();

        return app.Services.GetRequiredService<IChatClient>();
    }

    public async Task<string> GetResponseAsync(IChatClient chantClient, string prompt)
    {
        return (await chantClient.GetResponseAsync(prompt)).Text.Trim();
    }

}