using AI.Foundry.Local.RAG.Shared;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AI_Foundry_Local_RAG_Web>("ai-foundry-local-rag-web");

await builder.Build().RunAsync().ConfigureAwait(true);
