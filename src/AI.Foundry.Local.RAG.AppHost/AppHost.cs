using AI.Foundry.Local.RAG.Shared;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Frontend>(ResourceNames.Frontend);

await builder.Build().RunAsync().ConfigureAwait(true);
