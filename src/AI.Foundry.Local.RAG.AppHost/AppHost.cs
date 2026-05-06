using AI.Foundry.Local.RAG.AppHost.Extensions;
using AI.Foundry.Local.RAG.Shared;
using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

// Explicitly set environment-specific configuration loading
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>(optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.AddAIServices();

builder.AddProject<Projects.Frontend>(ResourceNames.Frontend)
    .WithAISettings();

await builder.Build().RunAsync().ConfigureAwait(true);
