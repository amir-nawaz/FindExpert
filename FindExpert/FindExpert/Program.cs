using FindExpert.Models;
using FindExpert.Services;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IExpertService, ExpertService>();
builder.Services.AddSingleton<IExpert, Expert>();
builder.Services.AddSingleton<IExpertGraph, ExpertGraph>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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

// Global exception Hanler
// Custom Exception Filter can also be written for more detailed exception.
app.UseExceptionHandler(options => {
    options.Run(
    async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "text/html";
        var ex = context.Features.Get<IExceptionHandlerFeature>();
        if (ex != null)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(ex.Error.Message).ConfigureAwait(false);
        }
    });
});

app.Run();
