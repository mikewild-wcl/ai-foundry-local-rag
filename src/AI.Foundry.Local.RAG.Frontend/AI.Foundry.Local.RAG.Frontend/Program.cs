using AI.Foundry.Local.RAG.Frontend.Components;
using AI.Foundry.Local.RAG.Frontend.Extensions;
using AI.Foundry.Local.RAG.Frontend.Services;
using AI.Foundry.Local.RAG.Frontend.State;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.ConfigureOptions();
if (builder.Environment.IsDevelopment())
{
    builder.DumpConfiguration();
}

builder.AddAIServices();

builder.Services.AddScoped<IChatService, DummyChatService>();
builder.Services.AddScoped<ChatState>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();
