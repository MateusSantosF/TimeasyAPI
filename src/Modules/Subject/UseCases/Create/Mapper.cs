


namespace timeasy_api.src.Modules.subject.UseCases.Create;

public class Mapper : Mapper<Request, Response, Subject>
{
    public override Subject ToEntity(Request r) => new()
    {
        Name = r.Name,
        Acronym = r.Acronym,
        Complexity = r.Complexity.GetEnumFromString<SubjectComplexity>(),
        RoomTypeId = r.RoomTypeId,
        InstituteId = r.InstituteId
    };


    public override Response FromEntity(Subject e) => new()
    {
        Id = e.Id,
        Acronym = e.Acronym,
        Name = e.Name,
        Complexity = e.Complexity.GetDescription(),
        RoomTypeId = e.RoomTypeId,
    };
}