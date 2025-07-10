class AIDataMaker
{
    readonly IAIConnector aIConnector;
    List<string> usedHints;

    public AIDataMaker(IAIConnector aIConnector)
    {
        this.aIConnector = aIConnector;
        usedHints = new List<string>();
    }

    public async Task<string> GetWordToGuessAsync()
    {
        var response = await aIConnector.GetResponseAsync("You are the brains behind my hangman game. Give me a word to guess. Nothing else just a word, no Special characters no bullshit. Example 'secret' just like that nothing else.");
        return response;
    }

    public async Task<string> GetHintAsync(string word)
    {
        var response = await aIConnector.GetResponseAsync($"You are the brains behind my hangman game. My word to guess is {word}. Give me a hint about the word to guess. with no extra bullshit just like this 'It is an object orbiting a star'.These hints are already taken: {string.Join(", ", usedHints)}");
        var hint = response;
        usedHints.Add(hint);
        return hint;
    }
}