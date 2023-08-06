using FinanceOperation.BlazorWebAssembly;
using FinanceOperation.BlazorWebAssembly.HttpClients;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
WebAssemblyHostConfiguration configuration = builder.Configuration;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<FinanceServiceClient>(client =>
{
    client.BaseAddress = new Uri(configuration.GetValue<string>("BaseUrl"));
});

await builder.Build().RunAsync();
