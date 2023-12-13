using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace timeasy_api.src.Contexts.Mappings;

public class IntervalConfiguration : IEntityTypeConfiguration<Interval>
{
    public void Configure(EntityTypeBuilder<Interval> builder)
    {

        builder
            .HasOne(i => i.Institute)
            .WithMany(i => i.Intervals)
            .HasForeignKey(i => i.InstituteId);

    }
}

