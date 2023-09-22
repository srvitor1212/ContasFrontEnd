using ContasFrontEnd;
using ContasFrontEnd.Services;
using ContasFrontEnd.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


// Registro de serviços
builder.Services.AddScoped<IEntradaService, EntradaService>();
builder.Services.AddScoped<IAlertService, AlertService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

