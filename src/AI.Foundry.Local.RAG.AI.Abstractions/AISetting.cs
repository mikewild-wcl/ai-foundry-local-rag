using System.Diagnostics;

namespace AI.Foundry.Local.RAG.AI.Abstractions;

#pragma warning disable CS9113 // Parameter is unread.

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class AISetting
{
    public const string SectionName = "AI";

    public required AIProvider Provider { get; init; }

    public required string DeploymentName { get; init; }

    public required string Model { get; init; }

    public required ModelRole Role { get; init; } = ModelRole.Chat;

    public string? ApiKey { get; init; }

    public string? Endpoint { get; init; } //Optional endpoint to override default for the provider

    public int? Timeout { get; init; } = Defaults.DefaultTimeoutSeconds;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay =>
        $$"""
        Provider = {{Provider}}, 
        Role = {{Role}},         
        Deployment = {{DeploymentName}}, 
        Model = {{Model}}
        """;
}
#pragma warning restore CS9113 // Parameter is unread.
