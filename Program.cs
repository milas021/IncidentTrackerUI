using IncidentTrackerUI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Base address of this Blazor app (used for wwwroot-relative requests, e.g. appsettings.json)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Keyed HttpClient pointing at the backend API (see wwwroot/appsettings.json -> ApiBaseUrl).
// Swagger: https://localhost:7147/swagger/index.html
// Inject with: [FromKeyedServices("Api")] HttpClient api
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:7147/";
builder.Services.AddKeyedScoped("Api", (sp, key) => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

await builder.Build().RunAsync();
