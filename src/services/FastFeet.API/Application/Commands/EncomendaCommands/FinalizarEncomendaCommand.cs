using FastFeet.API.Messages;
using FluentValidation;

namespace FastFeet.API.Application.Commands.EncomendaCommands
{
    public class FinalizarEncomendaCommand : Command
    {
        public int Id { get; set; }
        public int EntregadorId { get; set; }
        public override bool EhValido()
        {
            ValidationResult = new FinalizarEncomendaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public class FinalizarEncomendaValidation : AbstractValidator<FinalizarEncomendaCommand>
        {
            public FinalizarEncomendaValidation()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0)
                    .WithMessage("Encomenda não informada");

                RuleFor(c => c.EntregadorId)
                   .GreaterThan(0)
                   .WithMessage("Entregador não informado");
            }
        }
    }
}
