

namespace timeasy_api.src.Modules.room.UseCases.Create;
public class Request
{
    public string Name { get; set; }
    public string Block { get; set; }
    public int Capacity { get; set; }
    public Guid RoomTypeId { get; set; }


}
public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O  Nome é obrigatório.")
            .MinimumLength(3).WithMessage("Informe o nome da sala completo.");

        RuleFor(x => x.Capacity)
            .NotEmpty().WithMessage("O parametro Capaciaade é Obrigatório.")
            .GreaterThan(1)
            .WithMessage("O valor mímino para a capacidade da sala é 1.");

        RuleFor(x => x.RoomTypeId)
            .NotEmpty().WithMessage("O Tipo de Sala é Obrigatório.");
    }
}

public class Response
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Block { get; set; }
    public int Capacity { get; set; }
    public Guid RoomTypeId { get; set; }
}