using Microsoft.OpenApi.Models;
using SampleProject.API.Configuration;
using SampleProject.CrossCutting.IoC.ConfigureData;
using SampleProject.CrossCutting.IoC.DependencyInjection;
using SampleProject.CrossCutting.IoC.MigrationConfig;

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

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.ExecuteMigration();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
