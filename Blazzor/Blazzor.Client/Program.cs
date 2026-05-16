using Blazzor.Client;
using Blazzor.Client.Servicios;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7243/")
    });
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<NotificationService>();

// Registrar MudBlazor Services (opcional, ya no lo usaremos)
builder.Services.AddMudServices();

await builder.Build().RunAsync();
