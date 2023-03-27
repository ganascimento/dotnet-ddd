using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Infra.CrossCutting.Identity.Models;

namespace SampleProject.Infra.CrossCutting.Identity.Data.Mappings;

public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("TB_USER");

        builder
            .Ignore(p => p.PhoneNumber)
            .Ignore(p => p.PhoneNumberConfirmed)
            .Ignore(p => p.LockoutEnd)
            .Ignore(p => p.TwoFactorEnabled)
            .Ignore(p => p.LockoutEnabled)
            .Ignore(p => p.AccessFailedCount)
            .Ignore(p => p.ConcurrencyStamp);

        builder
            .Property(p => p.UpdateAt)
            .IsRequired(false);

        builder
            .Property(p => p.EmployeeId)
            .IsRequired(false);

        builder
            .Property(p => p.CompanyId)
            .IsRequired(false);
    }
}