

namespace timeasy_api.src.Modules.roomtype.UseCases.ReadOne;
public class Request
{
    public Guid Id { get; set; }


}
public class Response
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsComputerLab { get; set; }
    public string? OperationalSystem { get; set; }
}