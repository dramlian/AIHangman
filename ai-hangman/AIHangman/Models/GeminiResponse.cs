public record GeminiResponse
{
    public List<Candidate>? candidates { get; init; }
}

public record Candidate
{
    public Content? content { get; init; }
}

public record Content
{
    public List<Part>? parts { get; init; }
    public string? role { get; init; }
}

public record Part
{
    public string? text { get; init; }
}
