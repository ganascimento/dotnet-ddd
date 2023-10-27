using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleProject.Infra.CrossCutting.Identity.Data.Context;
using SampleProject.Infra.Data.Context;

namespace SampleProject.CrossCutting.IoC.MigrationConfig;

public static class MigrationExec
{
    public static void ExecuteMigration(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;

            using (var context = services.GetRequiredService<DataContext>())
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }

            using (var context = services.GetRequiredService<IdentityDataContext>())
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}