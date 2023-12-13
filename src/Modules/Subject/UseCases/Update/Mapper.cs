


namespace timeasy_api.src.Modules.subject.UseCases.ReadOne;

public class Mapper : Mapper<Request, Response, Subject>
{


    public override Response FromEntity(Subject e) => new()
    {
        Id = e.Id,
        Acronym = e.Acronym,
        Name = e.Name,
        Complexity = e.Complexity.GetDescription(),
        RoomTypeId = e.RoomTypeId,
    };
}