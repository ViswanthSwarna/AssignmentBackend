using Assignment.Api.ServiceCollectionConfigurations;
using Assignment.Entities;
using AssignmentApi.Middleware;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDependencies();

builder.Services.AddControllers();

builder.Services.AddDbContext<AssignmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerAuthorization();

builder.Services.AddCorsPolicy(builder);

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CORS");

app.UseMiddleware<AuthenticationMiddleware>();

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Response.ContentType = Text.Plain;

        await context.Response.WriteAsync("An exception was thrown.");
    });
});

app.Run();
