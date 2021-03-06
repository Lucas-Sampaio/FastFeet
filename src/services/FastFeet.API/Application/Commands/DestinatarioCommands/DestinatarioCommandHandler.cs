using AutoMapper;
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
        private readonly IMapper _mapper;
        public DestinatarioCommandHandler(IDestinatarioRepository destinatarioRepository, IMapper mapper)
        {
            _destinatarioRepository = destinatarioRepository;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Handle(CadastrarDestinatarioCommand request, CancellationToken cancellationToken)
        {
            // Validação do comando
            if (!request.EhValido()) return request.ValidationResult;

            var destinatario = _mapper.Map<Destinatario>(request);
            _destinatarioRepository.Cadastrar(destinatario);
            var sucesso = await PersistirDados(_destinatarioRepository.UnitOfWork);
            return sucesso;
        }

        public async Task<ValidationResult> Handle(AtualizarDestinatarioCommand request, CancellationToken cancellationToken)
        {
            // Validação do comando
            if (!request.EhValido()) return request.ValidationResult;
            
            var destinatario = _mapper.Map<Destinatario>(request);
            _destinatarioRepository.Atualizar(destinatario);
            var sucesso = await PersistirDados(_destinatarioRepository.UnitOfWork);
            return sucesso;
        }       
    }
}
