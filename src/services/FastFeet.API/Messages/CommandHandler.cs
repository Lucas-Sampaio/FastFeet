using FastFeet.Dominio.SeedWork;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace FastFeet.API.Messages
{
    public class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }
        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure("", mensagem));
        }
        protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit())
            {
                AdicionarErro("Houve um erro ao persistir dado");
            }
            return ValidationResult;
        }
    }
}
