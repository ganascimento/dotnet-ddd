using Microsoft.Extensions.DependencyInjection;
using SampleProject.Application.Queries.CompanyQuery;
using SampleProject.Application.Queries.EmployeeQuery;
using SampleProject.Domain.Interfaces.Repositories.Base;
using SampleProject.Infra.CrossCutting.Identity.Interfaces;
using SampleProject.Infra.CrossCutting.Identity.Services;
using SampleProject.Infra.Data.Repositories.Base;

namespace SampleProject.CrossCutting.IoC.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IEmployeeQuery, EmployeeQuery>();
        services.AddScoped<ICompanyQuery, CompanyQuery>();

        services.AddHttpContextAccessor();

        return services;
    }
}