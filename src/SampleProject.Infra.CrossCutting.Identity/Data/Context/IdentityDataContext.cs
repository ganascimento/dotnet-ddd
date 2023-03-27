using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleProject.Infra.CrossCutting.Identity.Data.Mappings;
using SampleProject.Infra.CrossCutting.Identity.Data.Seeds;
using SampleProject.Infra.CrossCutting.Identity.Models;

namespace SampleProject.Infra.CrossCutting.Identity.Data.Context;

public class IdentityDataContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserMap());
        builder.ApplyConfiguration(new ApplicationRoleMap());

        builder.Entity<IdentityUserRole<int>>()
            .ToTable("TB_USER_ROLE");

        builder.Entity<IdentityUserClaim<int>>()
            .ToTable("TB_USER_CLAIM");

        builder.Entity<IdentityRoleClaim<int>>()
            .ToTable("TB_ROLE_CLAIM");

        builder
            .Ignore<IdentityUserToken<int>>()
            .Ignore<IdentityUserLogin<int>>();

        ApplicationRoleSeed.Seed(builder);
        ApplicationUserSeed.Seed(builder);
        IdentityUserRoleSeed.Seed(builder);
    }
}