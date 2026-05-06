namespace AI.Foundry.Local.RAG.AI.Abstractions;

public class AISettings()
{
    public const string SectionName = "AI";

    public required IReadOnlyCollection<AISetting> Settings { get; init; }
}
