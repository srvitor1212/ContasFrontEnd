using ContasFrontEnd;
using ContasFrontEnd.Services;
using ContasFrontEnd.Services.Interface;
using ContasFrontEnd.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


// Setar a URL de prod ou Local
if (builder.HostEnvironment.IsProduction())
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://contaswebapi.azurewebsites.net/") });
else
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/") });
builder.Services.AddScoped(typeof(BaseService<>));


// Registro de servi�os
builder.Services.AddScoped<IEntradaService, EntradaService>();
builder.Services.AddScoped<IRecebedorService, RecebedorService>();
builder.Services.AddScoped<IPagamentosService, PagamentosService>();
builder.Services.AddScoped<IDividasService, DividasService>();
builder.Services.AddScoped<IAlertService, AlertService>();


await builder.Build().RunAsync();

