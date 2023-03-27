namespace SampleProject.API.Configuration;

public static class MediatrConfiguration
{
    public static IServiceCollection ConfigureMediatr(this IServiceCollection services)
    {
        var assembly = AppDomain.CurrentDomain.Load("SampleProject.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

        return services;
    }
}