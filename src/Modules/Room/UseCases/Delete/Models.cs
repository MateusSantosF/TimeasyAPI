

namespace timeasy_api.src.Modules.room.UseCases.Delete;
public class Request
{
    public Guid Id { get; set; }
}

public class Response
{
    public string Message { get; set; } = "Sala removida com sucesso";
}