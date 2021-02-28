using FastFeet.API.Application.DTO;
using FastFeet.API.Messages;
using FluentValidation;

namespace FastFeet.API.Application.Commands.DestinatarioCommands
{
    public class CadastrarDestinatarioCommand : Command
    {
        public string Nome { get; set; }
        public EnderecoDTO Endereco { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarDestinatarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AdicionarDestinatarioValidation : AbstractValidator<CadastrarDestinatarioCommand>
        {
            public AdicionarDestinatarioValidation()
            {
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
