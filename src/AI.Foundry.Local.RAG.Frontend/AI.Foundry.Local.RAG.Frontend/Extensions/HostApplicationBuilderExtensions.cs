using AI.Foundry.Local.RAG.AI.Abstractions;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace AI.Foundry.Local.RAG.Frontend.Extensions;

[SuppressMessage("Minor Code Smell", "S2325:Methods and properties that don't access instance data should be static", Justification = "False positive in extensions class")]
[SuppressMessage("Maintainability", "S3398:\"private\" methods called only by inner classes should be moved to those classe", Justification = "False positive in extensions class")]
internal static class HostApplicationBuilderExtensions
{
    extension(IHostApplicationBuilder builder)
    {
        internal IHostApplicationBuilder ConfigureOptions()
        {
            builder.Services
               .Configure<AISettings>(builder.Configuration.GetSection(AISettings.SectionName));

            return builder;
        }

        [SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
        internal IHostApplicationBuilder DumpConfiguration()
        {
            Console.WriteLine("\n======================");
            Console.WriteLine($"All configuration:");
            foreach (var config in builder.Configuration.AsEnumerable())
            {
                Console.WriteLine($"  {config.Key}:{config.Value}");
            }

            Console.WriteLine($"Connection strings:");
            var connections = builder.Configuration.GetSection("ConnectionStrings");
            if (connections is not null)
            {
                foreach (var conn in connections.AsEnumerable())
                {
                    Console.WriteLine($"  {conn.Key}:{conn.Value}");
                }
            }
            Console.WriteLine("======================\n");

            Console.WriteLine("\n======================");

            Console.WriteLine($"Environment variables:");

            foreach (DictionaryEntry e in System.Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"  {e.Key}:{e.Value}");
            }

            Console.WriteLine("======================\n");

            return builder;
        }

        internal IHostApplicationBuilder AddAIServices()
        {
            var aiSettings = builder.Configuration.GetSection(AISettings.SectionName).Get<AISettings>()
                ?? throw new InvalidOperationException("AI settings are not configured properly.");

            builder.Services.AddSingleton(aiSettings);

            builder.AddAIProviders(aiSettings);

            return builder;
        }

        private IHostApplicationBuilder AddAIProviders(AISettings aiSettings)
        {
            foreach (var setting in aiSettings.Settings)
            {
            }

            return builder;
        }
    }
}
