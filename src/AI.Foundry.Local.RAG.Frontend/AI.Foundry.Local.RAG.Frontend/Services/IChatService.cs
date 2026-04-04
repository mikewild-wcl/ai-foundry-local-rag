namespace AI.Foundry.Local.RAG.Frontend.Services;

public interface IChatService
{
    Task<string> SendMessageAsync(string message, CancellationToken cancellationToken = default);
}
