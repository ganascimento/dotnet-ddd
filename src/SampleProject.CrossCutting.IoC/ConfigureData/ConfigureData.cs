using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleProject.Domain.Interfaces;
using SampleProject.Infra.CrossCutting.Identity.Data.Context;
using SampleProject.Infra.CrossCutting.Identity.Models;
using SampleProject.Infra.Data.Context;
using SampleProject.Infra.Data.UoW;

namespace SampleProject.CrossCutting.IoC.ConfigureData;

public static class ConfigureData
{
    public static IServiceCollection ConfigContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DataContext>(
            option =>
            {
                option.UseSqlServer(connectionString);
            }
        );

        services.AddDbContext<IdentityDataContext>(
            option => option.UseSqlServer(connectionString)
        );

        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<IdentityDataContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}