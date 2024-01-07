


namespace timeasy_api.src.Modules.teacher.UseCases.AddWorkSchedule;

public class Mapper : Mapper<Request, Response, WorkSchedule>
{
    public override WorkSchedule ToEntity(Request r) => new()
    {
        TeacherId = r.Id,
        Start = r.Start.ToTimeSpan(),
        End = r.End.ToTimeSpan()
    };


    public override Response FromEntity(WorkSchedule e) => new()
    {
        Id = e.Id,
        Start = e.Start,
        End = e.End,
    };
}