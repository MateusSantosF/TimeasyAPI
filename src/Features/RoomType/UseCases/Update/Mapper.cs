


namespace timeasy_api.src.Modules.roomtype.UseCases.Update;

public class Mapper : Mapper<Request, Response, RoomType>
{
    public override RoomType ToEntity(Request r) => new()
    {
        Id = r.Id,
        Name = r.Name,
        IsComputerLab = r.IsComputerLab,
        OperationalSystem = r.OperationalSystem?.GetEnumFromString<OperationalSystem>()
    };


    public override Response FromEntity(RoomType e) => new()
    {
        Id = e.Id,
        Name = e.Name,
        IsComputerLab = e.IsComputerLab,
        OperationalSystem = e.OperationalSystem?.GetDescription()
    };
}