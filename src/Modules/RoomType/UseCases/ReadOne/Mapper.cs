

using timeasy_api.src.modules.roomType;

namespace timeasy_api.src.Modules.roomtype.UseCases.ReadOne;

public class Mapper : Mapper<Request, Response, RoomType>
{

    public override Response FromEntity(RoomType e) => new()
    {
        Id = e.Id,
        Name = e.Name,
        IsComputerLab = e.IsComputerLab,
        OperationalSystem = e.OperationalSystem?.GetDescription()
    };
}