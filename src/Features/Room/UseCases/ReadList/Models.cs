

using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Modules.room.UseCases.ReadList;
public class Request : PagedRequest
{
    [FromClaim("InstituteId", isRequired: true)]
    public Guid InstituteId { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Page)
        .GreaterThanOrEqualTo(1).WithMessage("O número da página deve ser maior ou igual a 1");
    }
}


public class Response
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Block { get; set; }
    public int Capacity { get; set; }
    public Guid RoomTypeId { get; set; }
}