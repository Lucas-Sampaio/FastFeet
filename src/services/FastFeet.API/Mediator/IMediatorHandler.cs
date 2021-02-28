using FastFeet.API.Messages;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace FastFeet.API.Mediator
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
