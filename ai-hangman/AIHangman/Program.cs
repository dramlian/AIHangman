AIDataMaker aIDataMaker = new AIDataMaker();
string wordToGuess = await aIDataMaker.GetWordToGuessAsync();

Hangman hangman = new Hangman(new GameDeterminer(wordToGuess, 8, aIDataMaker.GetHintAsync));
await hangman.StartGame();

