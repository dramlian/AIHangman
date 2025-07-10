AIDataMaker aIDataMaker = new AIDataMaker(new GeminiAIProvider());
string wordToGuess = await aIDataMaker.GetWordToGuessAsync();

Hangman hangman = new Hangman(new GameDeterminer(wordToGuess, Random.Shared.Next(5, 11), aIDataMaker.GetHintAsync));
await hangman.StartGame();
