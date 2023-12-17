

using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.subject.UseCases.ReadList;
public class Request : PagedRequest
{
    [FromClaim("InstituteId", isRequired: true)]
    public Guid InstituteId { get; set; }
}

public class Response
{
    public Guid Id { get; set; }
    public string Acronym { get; set; }
    public string Name { get; set; }
    public string Complexity { get; set; }
    public Guid RoomTypeId { get; set; }
}