



namespace timeasy_api.src.Modules.course.UseCases.UpdateSubject;

public class Mapper : Mapper<Request, Response, CourseSubject>
{
    public override CourseSubject ToEntity(Request req) => new()
    {
        Id = req.Id,
        SubjectId = req.SubjectId,
        CourseId = req.CourseId,
        Period = req.Period,
        WeeklyClassCount = req.WeeklyClassCount
    };


    public override Response FromEntity(CourseSubject e) => new()
    {
        Id = e.Id,
        SubjectId = e.SubjectId,
        CourseId = e.CourseId,
        Period = e.Period,
        WeeklyClassCount = e.WeeklyClassCount
    };
}