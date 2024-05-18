using FluentValidation;

namespace IAS.Application.Features.Service.Commands
{
  public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
  {
    public CreateServiceCommandValidator() 
    {
      RuleFor(p => p.Addres)
        .NotEmpty().WithMessage("{Address} no puede estar en blanco")
        .NotNull()
        .MaximumLength(30).WithMessage("{Addredd} no puede exceder los 30 caractere");

      RuleFor(p => p.Description)
        .MaximumLength(100).WithMessage("{Description} no puede exceder los 100 caractere");

      RuleFor(p => p.InitDateService)
        .NotEmpty().WithMessage("{InitDateService} no puede estar en blanco")
        .NotNull();

      RuleFor(p => p.EndDateService)
        .NotEmpty().WithMessage("{EndDateService} no puede estar en blanco")
        .NotNull();

      RuleFor(p => p.TechnicianId)
        .NotNull();
    }
  }
}
