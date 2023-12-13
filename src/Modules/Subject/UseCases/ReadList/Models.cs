

using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.subject.UseCases.ReadList;
public class Request : PagedRequest
{

}

public class Response
{
    public Guid Id { get; set; }
    public string Acronym { get; set; }
    public string Name { get; set; }
    public string Complexity { get; set; }
    public Guid RoomTypeId { get; set; }
}