using FastFeet.API.Messages;
using FluentValidation;

namespace FastFeet.API.Application.Commands.EntregadorCommands
{
    public class AtualizarEntregadorCommand : Command
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public override bool EhValido()
        {
            ValidationResult = new AtualizarEntregadorValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtualizarEntregadorValidation : AbstractValidator<AtualizarEntregadorCommand>
        {
            public AtualizarEntregadorValidation()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0)
                    .WithMessage("Entregador não informado");

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
