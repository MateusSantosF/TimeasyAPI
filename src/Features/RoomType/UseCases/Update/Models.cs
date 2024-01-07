

namespace timeasy_api.src.Modules.roomtype.UseCases.Update;
public class Request
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsComputerLab { get; set; }
    public string? OperationalSystem { get; set; }

}
public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O parametro Name é obrigatório.")
            .MinimumLength(5).WithMessage("Informe seu nome completo.");


        RuleFor(x => x.OperationalSystem)
        .NotEmpty().When(x => x.IsComputerLab)
        .WithMessage("OperationalSystem é obrigatório para laboratórios de computador.");
    }
}

public class Response
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsComputerLab { get; set; }
    public string? OperationalSystem { get; set; }
}