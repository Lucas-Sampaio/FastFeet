using FastFeet.API.Messages;
using FastFeet.Dominio.AggregatesModel.DestinatarioAggregate;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FastFeet.API.Application.Commands.DestinatarioCommands
{
    public class DestinatarioCommandHandler : CommandHandler,
        IRequestHandler<CadastrarDestinatarioCommand, ValidationResult>,
        IRequestHandler<AtualizarDestinatarioCommand, ValidationResult>
    {
        private readonly IDestinatarioRepository _destinatarioRepository;

        public DestinatarioCommandHandler(IDestinatarioRepository destinatarioRepository)
        {
            _destinatarioRepository = destinatarioRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarDestinatarioCommand request, CancellationToken cancellationToken)
        {
            // Validação do comando
            if (!request.EhValido()) return request.ValidationResult;

            var destinatario = MapearDestinatario(request);
            _destinatarioRepository.Cadastrar(destinatario);
            var sucesso = await PersistirDados(_destinatarioRepository.UnitOfWork);
            return sucesso;
        }

        public async Task<ValidationResult> Handle(AtualizarDestinatarioCommand request, CancellationToken cancellationToken)
        {
            // Validação do comando
            if (!request.EhValido()) return request.ValidationResult;

            var destinatario = MapearDestinatario(request);
            _destinatarioRepository.Atualizar(destinatario);
            var sucesso = await PersistirDados(_destinatarioRepository.UnitOfWork);
            return sucesso;
        }

        //TODO: refatorar depois
        private Destinatario MapearDestinatario(CadastrarDestinatarioCommand request)
        {
            var endereco = new Endereco
            {
                Logradouro = request.Endereco.Logradouro,
                Numero = request.Endereco.Numero,
                Complemento = request.Endereco.Complemento,
                Cep = request.Endereco.Cep,
                Cidade = request.Endereco.Cidade,
                Estado = request.Endereco.Estado
            };
            var destinatario = new Destinatario(request.Nome, endereco);
            return destinatario;
        }
        private Destinatario MapearDestinatario(AtualizarDestinatarioCommand request)
        {
            var endereco = new Endereco
            {
                Logradouro = request.Endereco.Logradouro,
                Numero = request.Endereco.Numero,
                Complemento = request.Endereco.Complemento,
                Cep = request.Endereco.Cep,
                Cidade = request.Endereco.Cidade,
                Estado = request.Endereco.Estado
            };
            var destinatario = new Destinatario(request.Nome, endereco,request.Id);
            return destinatario;
        }
    }
}
