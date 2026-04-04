namespace AI.Foundry.Local.RAG.Frontend.Services;

public sealed class DummyChatService : IChatService
{
    public Task<string> SendMessageAsync(string message, CancellationToken cancellationToken = default) =>
        Task.FromResult($"This is a placeholder response to: \"{message}\"");
}
