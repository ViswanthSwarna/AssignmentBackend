using Assignment.Api.Configurations;
using Assignment.Api.ServiceCollectionConfigurations;
using Assignment.Entities;
using AssignmentApi.Middleware;
using Microsoft.EntityFrameworkCore;

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

app.UseBasicExceptionHandler();

app.UseMiddleware<AuthenticationMiddleware>();

app.Run();
