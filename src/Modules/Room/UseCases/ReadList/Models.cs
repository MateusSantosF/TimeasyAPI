

using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.room.UseCases.ReadList;
public class Request : PagedRequest
{

}

public class Response
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Block { get; set; }
    public int Capacity { get; set; }
    public Guid RoomTypeId { get; set; }
}