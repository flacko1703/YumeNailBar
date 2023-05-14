using System.Reflection;
using YumeNailBar.Application;
using YumeNailBar.Infrastructure;
using Serilog;
using YumeNailBar.Domain;
using YumeNailBar.Domain.Factories;
using YumeNailBar.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Layers registration

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));



var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IClientFactory, ClientFactory>();


    

//Add Serilog
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
});

Log.Logger = new LoggerConfiguration()

    // Add console (Sink) as logging target
    .WriteTo.Console()

    // Set default minimum log level
    .MinimumLevel.Debug()

    // Create the actual logger
    .CreateLogger();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();