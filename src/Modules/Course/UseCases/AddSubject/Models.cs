

namespace timeasy_api.src.Modules.course.UseCases.AddSubject;
public class Request
{
    public Guid CourseId { get; set; }
    public Guid SubjectId { get; set; }
    public int Period { get; set; }
    public int WeeklyClassCount { get; set; }

}


public class Response
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid SubjectId { get; set; }
    public int Period { get; set; }
    public int WeeklyClassCount { get; set; }

}