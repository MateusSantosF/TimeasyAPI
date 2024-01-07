


using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace timeasy_api.src.Modules.course.UseCases.Update;

public class Mapper : Mapper<Request, Response, Course>
{
    public override Course ToEntity(Request r) => new()
    {
        Id = r.Id,
        Name = r.Name,
        PeriodAmount = r.PeriodAmount,
        Period = r.Period.GetEnumFromString<PeriodType>(),
        Turn = r.Turn.GetEnumFromString<Turn>(),
    };


    public override Response FromEntity(Course e) => new()
    {
        Id = e.Id,
        Name = e.Name,
        PeriodAmount = e.PeriodAmount,
        Period = e.Period.GetDescription(),
        Turn = e.Turn.GetDescription(),
        InstituteId = e.InstituteId
    };
}