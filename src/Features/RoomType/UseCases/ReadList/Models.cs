

using System.Linq.Expressions;
using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.roomtype.UseCases.ReadList;
public class Request : PagedRequest
{
    [FromClaim("InstituteId", isRequired: true)]
    public Guid InstituteId { get; set; }
}

public class Response
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsComputerLab { get; set; }
    public string? OperationalSystem { get; set; }
}

