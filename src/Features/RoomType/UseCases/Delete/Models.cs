

namespace timeasy_api.src.Modules.roomtype.UseCases.Delete;
public class Request
{
    public Guid Id { get; set; }


}
public class Response
{
    public string Message { get; set; } = "Tipo removido com sucesso";
}