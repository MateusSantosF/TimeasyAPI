using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using timeasy_api.src.modules.subject.Repository;

namespace timeasy_api.src.Contexts.Mappings;

public class TimetableSubjectsConfiguration : IEntityTypeConfiguration<TimetableSubjects>
{
    public void Configure(EntityTypeBuilder<TimetableSubjects> builder)
    {
        builder.HasKey(t => new { t.SubjectId, t.TimetableId, t.CourseId });

        builder
            .HasOne(s => s.Subject)
            .WithMany(tc => tc.TimetableSubjects)
            .HasForeignKey(s => s.SubjectId);

        builder
            .HasOne(s => s.Course)
            .WithMany(c => c.TimetableSubjects)
            .HasForeignKey(s => s.CourseId);

        builder
            .HasOne(t => t.Timetable)
            .WithMany(tc => tc.TimetableSubjects)
            .HasForeignKey(t => t.TimetableId);
    }
}
