using Microsoft.Extensions.AI;

class AIDataMaker
{
    AIConnector aIConnector;
    IChatClient chatClient;
    List<string> usedHints;

    public AIDataMaker()
    {
        aIConnector = new AIConnector("http://localhost:11434", "gemma3n");
        chatClient = aIConnector.GetChatClient();
        usedHints = new List<string>();
    }

    public async Task<string> GetWordToGuessAsync()
    {
        var response = await chatClient.GetResponseAsync("You are the brains behind my hangman game. Give me a word to guess. Nothing else just a word, no Special characters no bullshit. Example 'secret' just like that nothing else.");
        return response.Text.Trim();
    }

    public async Task<string> GetHintAsync(string word)
    {
        var response = await chatClient.GetResponseAsync($"You are the brains behind my hangman game. My word to guess is {word}. Give me a hint about the word to guess. with no extra bullshit just like this 'It is an object orbiting a star'.These hints are already taken: {string.Join(", ", usedHints)}");
        var hint = response.Text.Trim();
        usedHints.Add(hint);
        return hint;
    }
}