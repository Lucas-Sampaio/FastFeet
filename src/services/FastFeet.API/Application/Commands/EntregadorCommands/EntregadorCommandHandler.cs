using AutoMapper;
using FastFeet.API.Messages;
using FastFeet.Dominio.AggregatesModel.EntregadorAggregate;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FastFeet.API.Application.Commands.EntregadorCommands
{
    public class EntregadorCommandHandler : CommandHandler,
         IRequestHandler<CadastrarEntregadorCommand, ValidationResult>,
         IRequestHandler<AtualizarEntregadorCommand, ValidationResult>
    {
        private readonly IEntregadorRepository _entregadorRepository;
        private readonly IMapper _mapper;

        public EntregadorCommandHandler(IEntregadorRepository entregadorRepository, IMapper mapper)
        {
            _entregadorRepository = entregadorRepository;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Handle(CadastrarEntregadorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var entregador = _mapper.Map<Entregador>(request);

            if (!(await ValidarEntregador(entregador)))
            {
                return this.ValidationResult;
            }

            _entregadorRepository.Cadastrar(entregador);
            var sucesso = await PersistirDados(_entregadorRepository.UnitOfWork);
            return sucesso;
        }
        public async Task<ValidationResult> Handle(AtualizarEntregadorCommand request, CancellationToken cancellationToken)
        {
            // Validação do comando
            if (!request.EhValido()) return request.ValidationResult;
            if (!(await _entregadorRepository.Existe(x => x.Id == request.Id)))
            {
                AdicionarErro("Entregador não encontrado");
                return request.ValidationResult;
            }

            var entregador = _mapper.Map<Entregador>(request);

            if (!(await ValidarEntregador(entregador)))
            {
                return this.ValidationResult;
            }

            _entregadorRepository.Atualizar(entregador);
            var sucesso = await PersistirDados(_entregadorRepository.UnitOfWork);
            return sucesso;
        }

        private async Task<bool> ValidarEntregador(Entregador entregador)
        {
            var invalido = await _entregadorRepository.Existe(x => x.Id != entregador.Id && x.Email.Equals(entregador.Email));
            if (invalido)
            {
                AdicionarErro("Já existe um entregador com esse email");
                return false;
            }
            return true;
        }
    }
}
