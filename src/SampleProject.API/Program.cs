using System.Reflection;
using SampleProject.API.Configuration;
using SampleProject.CrossCutting.IoC.ConfigureData;
using SampleProject.CrossCutting.IoC.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .ConfigureOData();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .ConfigureMediatr()
    .ConfigureCors()
    .ConfigureAuthorization(builder.Configuration)
    .ConfigureDependencies()
    .ConfigContext(builder.Configuration)
    .ConfigureAutoMapper();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
