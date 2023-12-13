using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using timeasy_api.src.modules.institute.Repository;

namespace timeasy_api.src.Contexts.Mappings;

public class InstituteConfiguration : IEntityTypeConfiguration<Institute>
{
    public void Configure(EntityTypeBuilder<Institute> builder)
    {
        builder.HasMany(i => i.Intervals)
            .WithOne(i => i.Institute)
            .HasForeignKey(i => i.InstituteId);
    }
}

