


namespace timeasy_api.src.Modules.teacher.UseCases.UpdateWorkSchedule;

public class Mapper : Mapper<Request, Response, WorkSchedule>
{
    public override WorkSchedule ToEntity(Request r) => new()
    {
        Id = r.Id,
        TeacherId = r.TeacherId,
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