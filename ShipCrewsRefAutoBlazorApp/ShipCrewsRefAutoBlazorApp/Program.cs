using LoggingHelpers;
using Serilog;
using ShipCrewsRefAutoBlazorApp;
using ShipCrewsRefAutoBlazorApp.Client.Pages;
using ShipCrewsRefAutoBlazorApp.Components;
using ShipCrewsRefAutoBlazorApp.Services;

Log.Logger = new LoggerConfiguration()
    .ConfigureBasic()
    .ConfigureMinLoggingLevel()
    .ConfigureWriteToDefaultFile()
    .ConfigureWriteToConsole()
    .CreateLogger();
Log.Logger.Information("Starting");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Simon: client injected into ship crews client
builder.Services.AddSingleton(new HttpClient());
builder.Services.AddSingleton<IShipCrewsService, ShipCrewsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ShipCrewsRefAutoBlazorApp.Client._Imports).Assembly);

app.Run();
