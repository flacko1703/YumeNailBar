using System.Reflection;
using FluentResults;
using MediatR;
using Serilog;
using YumeNailBar.Application;
using YumeNailBar.Application.Registration.Commands.CreateClientCommand;
using YumeNailBar.Domain;
using YumeNailBar.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Layers registration

builder.Services
    .AddDomainLayer()
    .AddApplicationLayer()
    .AddInfrastructureLayer(builder.Configuration);




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




    

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