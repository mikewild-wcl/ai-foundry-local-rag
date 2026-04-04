namespace AI.Foundry.Local.RAG.Frontend.Models;

public record ChatMessage(string Role, string Content, DateTimeOffset Timestamp);
