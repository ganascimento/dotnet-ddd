using Microsoft.EntityFrameworkCore;
using SampleProject.Infra.CrossCutting.Identity.Models;

namespace SampleProject.Infra.CrossCutting.Identity.Data.Seeds;

public static class ApplicationRoleSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationRole>().HasData(
            new ApplicationRole
            {
                Id = 1,
                Name = "ROOT",
                NormalizedName = "ROOT"
            },
            new ApplicationRole
            {
                Id = 2,
                Name = "ADMIN",
                NormalizedName = "ADMIN"
            },
            new ApplicationRole
            {
                Id = 3,
                Name = "DEFAULT",
                NormalizedName = "DEFAULT"
            }
        );
    }
}