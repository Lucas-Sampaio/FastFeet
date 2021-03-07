using FastFeet.API.Messages;
using FluentValidation;

namespace FastFeet.API.Application.Commands.EncomendaCommands
{
    public class AtualizarEncomendaCommand : Command
    {
        public int Id { get; set; }
        public int DestinatarioId { get; set; }
        public int EntregadorId { get; set; }
        public string Descricao { get; set; }
        public override bool EhValido()
        {
            ValidationResult = new AtualizarEncomendaValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtualizarEncomendaValidation : AbstractValidator<AtualizarEncomendaCommand>
        {
            public AtualizarEncomendaValidation()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0)
                    .WithMessage("Encomenda não informada");

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



