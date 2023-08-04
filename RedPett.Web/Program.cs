using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Radzen;
using RedPett.Web;
using ReDpett.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<ListAppDataService>();
builder.Services.AddScoped<ListAppDataService1>();
builder.Services.AddScoped<ListIntermediateResidentData>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddSingleton<AppDataService>();

builder.Services.AddScoped<ISaveDataService, StoreDataService>();
builder.Services.AddScoped<IntermediateResidentDataService, IRStoreDataService>();
builder.Services.AddScoped<IEmail, EmailService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

await builder.Build().RunAsync();
