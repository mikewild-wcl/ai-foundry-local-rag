using AI.Foundry.Local.RAG.AI.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AI.Foundry.Local.RAG.AppHost.Extensions;

internal static class AIServiceExtensions
{
    extension(IDistributedApplicationBuilder builder)
    {
        internal IDictionary<string, IResourceBuilder<IResourceWithConnectionString>> AddAIServices()
        {
            var aiSettings = builder.Configuration.GetSection(AISettings.SectionName).Get<AISettings>()
                ?? throw new InvalidOperationException("AI settings are not configured properly.");

            var aiResources = new Dictionary<string, IResourceBuilder<IResourceWithConnectionString>>();

            foreach (var setting in aiSettings.Settings)
            {
                var name = setting.DeploymentName ?? throw new InvalidOperationException("AI setting must have a deployment name.");
                var model = setting.Provider switch
                {
                    AIProvider.FoundryLocal => builder.ConfigureFoundryLocal(name, setting),
                    _ => throw new InvalidOperationException(
                        $"Unsupported AI provider: {setting.Provider}")
                };
            }

            return aiResources;
        }

        private IResourceBuilder<IResourceWithConnectionString> ConfigureFoundryLocal(
           //IDistributedApplicationBuilder builder,
           string name,
           AISetting setting)
        {
            var foundry = builder.AddAzureAIFoundry("foundry")
                         .RunAsFoundryLocal();

            return foundry;
        }
    }

    extension(IResourceBuilder<ProjectResource> builder)
    {
        public IResourceBuilder<ProjectResource> WithAISettings()
        {
            var settings = builder.ApplicationBuilder.Configuration.GetSection(AISettings.SectionName).Get<AISettings>()
                ?? throw new InvalidOperationException("AI settings are not configured properly."); ;

            var index = 0;
            foreach (var setting in settings.Settings)
            {
#pragma warning disable CA1308 // Normalize strings to uppercase
                builder
                    .WithEnvironment($"AI:{index}:Provider", setting.Provider.ToString().ToLowerInvariant())
                    .WithEnvironment($"AI:{index}:DeploymentName", setting.DeploymentName)
                    .WithEnvironment($"AI:{index}:Model", setting.Model)
                    .WithEnvironment($"AI:{index}:Role", setting.Role.ToString().ToLowerInvariant())
                    .WithEnvironmentIfNotNull($"AI:{index}:ApiKey", setting.ApiKey)
                    .WithEnvironmentIfNotNull($"AI:{index}:Endpoint", setting.Endpoint)
                    .WithEnvironmentIfNotNull("AI:Timeout", setting.Timeout?.ToString(CultureInfo.InvariantCulture));
#pragma warning restore CA1308 // Normalize strings to uppercase

                index++;
            }

            return builder;
        }

        public IResourceBuilder<ProjectResource> WithEnvironmentIfNotNull(string name, string? value)
        {
            if (value is not null)
            {
                builder
                        .WithEnvironment(name, value);
            }

            return builder;
        }
    }
}
