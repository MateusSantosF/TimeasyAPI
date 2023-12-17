


using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.teacher.UseCases.ReadList;
public class Request : PagedRequest
{
    [FromClaim("InstituteId", isRequired: true)]
    public Guid InstituteId { get; set; }
}

public class Response
{
    public Guid Id { get; set; }
    public string Registration { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public Guid InstituteId { get; set; }
}