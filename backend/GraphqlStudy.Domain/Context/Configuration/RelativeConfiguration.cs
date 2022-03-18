using GraphqlStudy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphqlStudy.Domain.Context.Configuration;

public class RelativeConfiguration : IEntityTypeConfiguration<Relative>
{
    public void Configure(EntityTypeBuilder<Relative> builder)
    {
        builder.ToTable("relative");
        builder.HasKey(r => r.Id);
        builder.HasIndex(r => r.Id).IsUnique();

        builder.Property(r => r.Id).HasColumnName("id");
        builder.Property(r => r.Name).HasColumnName("name");
        builder.Property(r => r.EmployeeId).HasColumnName("employeeid");
    }
}