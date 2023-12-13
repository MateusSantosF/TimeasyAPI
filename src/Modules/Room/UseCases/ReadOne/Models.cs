

namespace timeasy_api.src.Modules.room.UseCases.ReadOne;
public class Request
{
    public Guid Id { get; set; }
}

public class Response
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Block { get; set; }
    public int Capacity { get; set; }
    public Guid RoomTypeId { get; set; }
}