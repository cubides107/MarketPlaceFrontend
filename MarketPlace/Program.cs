using Blazored.LocalStorage;
using CreditAppWeb;
using CreditAppWeb.Data.Auth;
using CreditAppWeb.Data.Http.Products;
using CreditAppWeb.Data.Http.Users;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddHttpClient<UserClient>(client => client.BaseAddress = new Uri("https://corpentunida-backend.herokuapp.com/api/Users/"));
builder.Services.AddHttpClient<UserClient>(client => client.BaseAddress = new Uri("https://localhost:44300/api/Users/"));
builder.Services.AddHttpClient<ProductClient>(client => client.BaseAddress = new Uri("https://localhost:44300/api/Product/"));
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<DialogService>();

await builder.Build().RunAsync();