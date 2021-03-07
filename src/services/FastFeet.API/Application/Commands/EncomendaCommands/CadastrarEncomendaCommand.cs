using FastFeet.API.Messages;
using FluentValidation;

namespace FastFeet.API.Application.Commands.EncomendaCommands
{
    public class CadastrarEncomendaCommand : Command
    {
        public int DestinatarioId { get; set; }
        public int EntregadorId { get; set; }
        public string Descricao { get; set; }
        public override bool EhValido()
        {
            ValidationResult = new AdicionarEncomendaValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AdicionarEncomendaValidation : AbstractValidator<CadastrarEncomendaCommand>
        {
            public AdicionarEncomendaValidation()
            {

                RuleFor(c => c.Descricao)
                   .NotEmpty()
                   .NotNull()
                   .MinimumLength(2)
                   .WithMessage("Descrição Inválida");

                RuleFor(c => c.DestinatarioId)
                   .GreaterThan(0)
                   .WithMessage("Destinatario não informado");

                RuleFor(c => c.EntregadorId)
                  .GreaterThan(0)
                  .WithMessage("Entregador não informado");

            }
        }
    }
}
