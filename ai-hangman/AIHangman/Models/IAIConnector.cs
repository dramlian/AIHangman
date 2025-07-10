public interface IAIConnector
{
    public Task<string> GetResponseAsync(string prompt);

}