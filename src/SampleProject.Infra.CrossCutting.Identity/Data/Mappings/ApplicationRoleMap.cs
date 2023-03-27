using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Infra.CrossCutting.Identity.Models;

namespace SampleProject.Infra.CrossCutting.Identity.Data.Mappings;

public class ApplicationRoleMap : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("TB_ROLE");

        builder.Ignore(p => p.ConcurrencyStamp);
    }
}