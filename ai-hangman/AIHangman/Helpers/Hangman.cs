class Hangman
{
    readonly GameDeterminer gameDeterminer;
    readonly Drawing drawing;
    public Hangman(GameDeterminer gameDeterminer)
    {
        this.gameDeterminer = gameDeterminer;
        this.drawing = new Drawing(gameDeterminer.GetRemainingAttempts());
    }

    public async Task StartGame()
    {
        Console.WriteLine($"Welcome to Hangman! You have {gameDeterminer.GetRemainingAttempts()} attempts to guess the word.");
        while (!gameDeterminer.IsGameOver())
        {
            var hint = await gameDeterminer.GetHintAsync();
            if (hint != null)
            {
                Console.WriteLine($"Hint: {hint}");
            }
            Console.WriteLine("Current state: " + gameDeterminer.GetCurrentState());
            Console.Write("Guess a letter: ");
            char guessedLetter = Console.ReadKey().KeyChar;
            Console.WriteLine();
            gameDeterminer.AddGuessedLetter(guessedLetter);
            if (!gameDeterminer.GetCurrentState().Contains(guessedLetter))
            {
                gameDeterminer.DecrementMaxAttempts();
                Console.WriteLine($"Wrong guess! You have {gameDeterminer.GetRemainingAttempts()} attempts left.");
            }
            else
            {
                Console.WriteLine("Good guess!");
            }
            Console.WriteLine(drawing.DrawStage(gameDeterminer.GetRemainingAttempts()));
            Console.WriteLine("==========================");

        }
        if (gameDeterminer.WasTheWordGuessed())
        {
            Console.WriteLine("Congratulations! You've guessed the word " + gameDeterminer.GetSecretWord());
        }
        else
        {
            Console.WriteLine("Game Over! The word was: " + gameDeterminer.GetSecretWord());
        }
    }

}