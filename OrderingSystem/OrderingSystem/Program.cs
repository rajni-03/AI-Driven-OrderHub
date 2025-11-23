using OrderingSystem.Components;
using OrderingSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// ? Register HttpClient for API calls (pointing to your Server URL)
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:5255") });

// ? Register OrderService
builder.Services.AddScoped<OrderService>();

// ? Add Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// ? Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

// ? Map the root Blazor App component
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
