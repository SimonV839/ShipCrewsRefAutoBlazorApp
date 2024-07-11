using LoggingHelpers;
using Serilog;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

throw new Exception("Does not appear to be used in dev");
Log.Logger = new LoggerConfiguration()
    .ConfigureBasic()
    .ConfigureMinLoggingLevel()
    .ConfigureWriteToDefaultFile()
    .ConfigureWriteToConsole()
    .CreateLogger();
Log.Logger.Information("Starting");

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

await builder.Build().RunAsync();
