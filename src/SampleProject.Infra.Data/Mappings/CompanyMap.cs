using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Domain.Models;

namespace SampleProject.Infra.Data.Mappings;

public class CompanyMap : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("TB_COMPANY");

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Document)
            .HasMaxLength(14)
            .IsRequired();

        builder
            .Property(p => p.CorporateName)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(p => p.FantasyName)
            .HasMaxLength(80)
            .IsRequired();

        builder.HasOne(p => p.Address);

        builder
            .HasMany(p => p.Employees)
            .WithOne(p => p.Company)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(n => n.Address).AutoInclude();
    }
}