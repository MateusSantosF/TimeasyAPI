using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace timeasy_api.src.Contexts.Mappings;
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {

        builder.Property(c => c.Period).HasConversion<string>();
        builder.Property(c => c.Turn).HasConversion<string>();
    }
}
