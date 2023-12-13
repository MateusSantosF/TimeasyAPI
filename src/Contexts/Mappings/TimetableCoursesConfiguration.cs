using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace timeasy_api.src.Contexts.Mappings;

public class TimetableCourseConfiguration : IEntityTypeConfiguration<TimetableCourses>
{
    public void Configure(EntityTypeBuilder<TimetableCourses> builder)
    {
        builder.HasKey(t => new { t.CourseId, t.TimetableId });

        builder
            .HasOne(c => c.Course)
            .WithMany(tc => tc.TimetableCourses);

        builder
            .HasOne(c => c.Timetable)
            .WithMany(tc => tc.TimetableCourses);
    }
}

