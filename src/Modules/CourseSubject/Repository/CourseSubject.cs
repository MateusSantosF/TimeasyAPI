
using timeasy_api.src.modules.course.Repository;
using timeasy_api.src.modules.subject.Repository;

namespace timeasy_api.src.modules.coursesubject.Repository;
public class CourseSubject
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int Period { get; set; }
    public int WeeklyClassCount { get; set; }
}

