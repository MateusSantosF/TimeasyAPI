

using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.course.UseCases.ReadList;

public class Request : PagedRequest
{
    [FromClaim("InstituteId", isRequired: true)]
    public Guid InstituteId { get; set; }
}


public class Response
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int PeriodAmount { get; set; }
    public string Turn { get; set; }
    public string Period { get; set; }
    public Guid InstituteId { get; set; }
}