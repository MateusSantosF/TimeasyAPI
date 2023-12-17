


using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace timeasy_api.src.Modules.course.UseCases.ReadOne;

public class Mapper : Mapper<Request, Response, Course>
{

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