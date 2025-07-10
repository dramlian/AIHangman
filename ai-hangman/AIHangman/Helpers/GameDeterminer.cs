class GameDeterminer
{
    readonly string secretWord;
    IEnumerable<char> guessedLetters;
    int maxAttempts;
    Func<string, Task<string>>? getHintFunc;

    public GameDeterminer(string secretWord, int maxAttempts = 6, Func<string, Task<string>>? getHintFunc = null)
    {
        this.secretWord = secretWord.ToLower();
        this.guessedLetters = Enumerable.Empty<char>();
        this.getHintFunc = getHintFunc;
        if (maxAttempts > 10)
        {
            Console.WriteLine("You can only have maximum of 10 attempts. Setting to 10.");
            maxAttempts = 10;
        }
        this.maxAttempts = maxAttempts;
    }

    public bool IsGameOver()
    {
        if (maxAttempts <= 0)
        {
            return true;
        }
        return WasTheWordGuessed();
    }

    public bool WasTheWordGuessed()
    {
        return !secretWord.Any(letter => !guessedLetters.Contains(letter));
    }

    public void AddGuessedLetter(char letter)
    {
        guessedLetters = guessedLetters.Append(char.ToLower(letter)).Distinct();
    }

    public string GetCurrentState()
    {
        return new string(secretWord.Select(letter => guessedLetters.Contains(letter) ? letter : '_').ToArray());
    }

    public string GetSecretWord()
    {
        return secretWord;
    }

    public void DecrementMaxAttempts()
    {
        if (maxAttempts > 0)
        {
            maxAttempts--;
        }
    }

    public int GetRemainingAttempts()
    {
        return maxAttempts;
    }

    public async Task<string?> GetHintAsync()
    {
        if (getHintFunc != null)
        {
            return await getHintFunc(secretWord);
        }
        return null;
    }
}