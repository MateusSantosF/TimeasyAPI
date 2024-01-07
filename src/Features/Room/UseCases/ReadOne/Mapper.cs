


namespace timeasy_api.src.Modules.room.UseCases.ReadOne;

public class Mapper : Mapper<Request, Response, Room>
{
    public override Response FromEntity(Room e) => new()
    {
        Id = e.Id,
        Name = e.Name,
        Capacity = e.Capacity,
        RoomTypeId = e.RoomTypeId,
        Block = e.Block
    };
}