class Drawing
{
    readonly string fullDrawing = "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n=========";

    int maxAttempts;

    public Drawing(int maxAttempts)
    {
        this.maxAttempts = maxAttempts;
    }

    public string DrawStage(int remainingAttempts)
    {
        int charactersToShow = fullDrawing.Length - (remainingAttempts * fullDrawing.Length / maxAttempts);
        return new string(fullDrawing.Take(charactersToShow).ToArray());
    }
}