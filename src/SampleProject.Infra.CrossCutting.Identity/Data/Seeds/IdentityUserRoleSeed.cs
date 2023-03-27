using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SampleProject.Infra.CrossCutting.Identity.Data.Seeds;

public static class IdentityUserRoleSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>
            {
                UserId = 1,
                RoleId = 1
            }
        );
    }
}