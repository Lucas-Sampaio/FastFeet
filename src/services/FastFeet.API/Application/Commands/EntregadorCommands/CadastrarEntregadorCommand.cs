using FastFeet.API.Messages;
using FluentValidation;

namespace FastFeet.API.Application.Commands.EntregadorCommands
{
    public class CadastrarEntregadorCommand : Command
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarEntregadorValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AdicionarEntregadorValidation : AbstractValidator<CadastrarEntregadorCommand>
        {
            public AdicionarEntregadorValidation()
            {
                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .NotNull()
                    .MinimumLength(2)
                    .WithMessage("Nome Inválido");

                RuleFor(c => c.Email)
                      .EmailAddress()
                      .WithMessage("Email Inválido");

            }
        }
    }
}
