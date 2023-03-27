using SampleProject.Application.Mapping;

namespace SampleProject.API.Configuration;

public static class AutoMapperConfiguration
{
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        var autoMapperConfig = new AutoMapper.MapperConfiguration(config =>
            {
                config.AddProfile(new CompanyMapping());
                config.AddProfile(new EmployeeMapping());
            });

        var mapper = autoMapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}