


namespace timeasy_api.src.Modules.room.UseCases.Update;

public class Mapper : Mapper<Request, Response, Room>
{
    public override Room ToEntity(Request r) => new()
    {
        Id = r.Id,
        Name = r.Name,
        Capacity = r.Capacity,
        RoomTypeId = r.RoomTypeId,
        Block = r.Block
    };


    public override Response FromEntity(Room e) => new()
    {
        Id = e.Id,
        Name = e.Name,
        Capacity = e.Capacity,
        RoomTypeId = e.RoomTypeId,
        Block = e.Block
    };
}