using AI.Foundry.Local.RAG.Frontend.Models;

namespace AI.Foundry.Local.RAG.Frontend.State;

public sealed class ChatState
{
    private readonly List<ChatMessage> _messages = [];

    public IReadOnlyList<ChatMessage> Messages => _messages.AsReadOnly();

    public void AddMessage(ChatMessage message) => _messages.Add(message);

    public void Clear() => _messages.Clear();
}
