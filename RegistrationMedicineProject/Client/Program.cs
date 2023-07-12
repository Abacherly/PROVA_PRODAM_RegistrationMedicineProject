global using RegistrationMedicineProject.Client.Services.RegistrationMedicineService;
global using RegistrationMedicineProject.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RegistrationMedicineProject.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IRegistrationMedicineService, RegistrationMedicineService>();

await builder.Build().RunAsync();
