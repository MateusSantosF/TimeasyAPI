

namespace timeasy_api.src.Modules.subject.UseCases.Update;
public class Request
{
    public Guid Id { get; set; }
    public string Acronym { get; set; }
    public string Name { get; set; }
    public string Complexity { get; set; }
    public Guid RoomTypeId { get; set; }

}
public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O  Nome é obrigatório.")
            .MinimumLength(3).WithMessage("Informe o nome da sala completo.");

        RuleFor(x => x.Acronym)
            .MaximumLength(7).WithMessage("Sigla muito grande! O tamanho máximo é 7 caracteres")
            .NotEmpty().WithMessage("O parametro Sigla é Obrigatório.");

        RuleFor(x => x.RoomTypeId)
            .NotEmpty().WithMessage("O Tipo de Sala é Obrigatório.");
    }
}

public class Response
{
    public Guid Id { get; set; }
    public string Acronym { get; set; }
    public string Name { get; set; }
    public string Complexity { get; set; }
    public Guid RoomTypeId { get; set; }
}