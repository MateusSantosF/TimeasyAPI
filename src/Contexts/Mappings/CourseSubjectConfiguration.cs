using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using timeasy_api.src.modules.coursesubject.Repository;

namespace timeasy_api.src.Contexts.Mappings;
public class CourseSubjectConfiguration : IEntityTypeConfiguration<CourseSubject>
{
    public void Configure(EntityTypeBuilder<CourseSubject> builder)
    {
        builder.HasKey(cs => new { cs.CourseId, cs.SubjectId });

        builder
            .HasOne(s => s.Subject)
            .WithMany(tc => tc.CourseSubject)
            .HasForeignKey(s => s.SubjectId);

        builder
           .HasOne(s => s.Course)
           .WithMany(tc => tc.CourseSubject)
           .HasForeignKey(s => s.CourseId);


    }
}
