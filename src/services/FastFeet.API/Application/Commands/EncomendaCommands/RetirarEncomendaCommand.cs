using FastFeet.API.Messages;
using FastFeet.Dominio.AggregatesModel.EncomendasAggregate;
using FluentValidation;
using System;

namespace FastFeet.API.Application.Commands.EncomendaCommands
{
    public class RetirarEncomendaCommand : Command
    {
        private DateTime data;
        public RetirarEncomendaCommand()
        {
            data = DateTime.Now;
        }
        public int Id { get; set; }
        public int EntregadorId { get; set; }
        public override bool EhValido()
        {
            ValidationResult = new RetirarEncomendaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public class RetirarEncomendaValidation : AbstractValidator<RetirarEncomendaCommand>
        {
            public RetirarEncomendaValidation()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0)
                    .WithMessage("Encomenda não informada");

                RuleFor(c => c.EntregadorId)
                   .GreaterThan(0)
                   .WithMessage("Entregador não informado");

                RuleFor(c => c.data)
                   .Must(Encomenda.EhHoraValida)
                   .WithMessage("Data inválida");

            }
        }
    }
}
