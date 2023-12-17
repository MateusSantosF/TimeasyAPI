


namespace timeasy_api.src.Modules.teacher.UseCases.Create;
public class Request
{
    public string Registration { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }

    [FromClaim("InstituteId", isRequired: true)]
    public Guid InstituteId { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("O  Nome é obrigatório.")
            .MinimumLength(3).WithMessage("Informe o nome da sala completo.");

        RuleFor(x => x.Registration)
            .NotEmpty().WithMessage("O parametro matrícula é Obrigatório.")
            .MinimumLength(5).WithMessage("Informe o matrícula corretamente.");

        RuleFor(x => x.Email).EmailAddress().WithMessage("Informe um e-mail válido.");
    }
}

public class Response
{
    public Guid Id { get; set; }
    public string Registration { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public Guid InstituteId { get; set; }
}