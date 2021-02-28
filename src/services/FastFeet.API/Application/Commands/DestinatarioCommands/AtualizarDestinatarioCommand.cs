using FastFeet.API.Application.DTO;
using FastFeet.API.Messages;
using FluentValidation;

namespace FastFeet.API.Application.Commands.DestinatarioCommands
{
    public class AtualizarDestinatarioCommand : Command
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EnderecoDTO Endereco { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarDestinatarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtualizarDestinatarioValidation : AbstractValidator<AtualizarDestinatarioCommand>
        {
            public AtualizarDestinatarioValidation()
            {
                RuleFor(c => c.Id)
                    .GreaterThan(0)
                    .WithMessage("Destinatario não informado");

                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .NotNull()
                    .MinimumLength(2)
                    .WithMessage("Nome Inválido");

                RuleFor(c => c.Endereco)
                    .NotNull()
                    .WithMessage("Informe Endereco");

                RuleFor(c => c.Endereco.Cep)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Cep Inválido");

                RuleFor(c => c.Endereco.Logradouro)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("Logradouro Inválido");

                RuleFor(c => c.Endereco.Numero)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("Numero Inválido");

            }
        }
    }
}
