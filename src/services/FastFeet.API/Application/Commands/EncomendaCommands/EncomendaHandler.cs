using AutoMapper;
using FastFeet.API.Messages;
using FastFeet.Dominio.AggregatesModel.DestinatarioAggregate;
using FastFeet.Dominio.AggregatesModel.EncomendasAggregate;
using FastFeet.Dominio.AggregatesModel.EntregadorAggregate;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FastFeet.API.Application.Commands.EncomendaCommands
{
    public class EncomendaHandler : CommandHandler,
         IRequestHandler<CadastrarEncomendaCommand, ValidationResult>,
         IRequestHandler<AtualizarEncomendaCommand, ValidationResult>
    {
        private readonly IEncomendaRepository _encomendaRepository;
        private readonly IDestinatarioRepository _destinatarioRepository;
        private readonly IEntregadorRepository _entregadorRepository;
        private readonly IMapper _mapper;

        public EncomendaHandler(IEncomendaRepository encomendaRepository, IMapper mapper, 
            IDestinatarioRepository destinatarioRepository, IEntregadorRepository entregadorRepository)
        {
            _encomendaRepository = encomendaRepository;
            _mapper = mapper;
            _destinatarioRepository = destinatarioRepository;
            _entregadorRepository = entregadorRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarEncomendaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var encomenda = _mapper.Map<Encomenda>(request);

            if (!(await ValidarEncomenda(encomenda)))
            {
                return this.ValidationResult;
            }

            _encomendaRepository.Cadastrar(encomenda);
            var sucesso = await PersistirDados(_encomendaRepository.UnitOfWork);
            return sucesso;
        }

        public async Task<ValidationResult> Handle(AtualizarEncomendaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var encomenda = _mapper.Map<Encomenda>(request);

            if (!(await ValidarEncomenda(encomenda)))
            {
                return this.ValidationResult;
            }

            _encomendaRepository.Atualizar(encomenda);
            var sucesso = await PersistirDados(_encomendaRepository.UnitOfWork);
            return sucesso;
        }

        private async Task<bool> ValidarEncomenda(Encomenda encomenda)
        {
            var destinatarioExiste = await _destinatarioRepository.Existe(x => x.Id == encomenda.DestinatarioId);
            if (!destinatarioExiste) AdicionarErro("Destinatario não encontrado");
            var entregadorExiste = await _entregadorRepository.Existe(x => x.Id == encomenda.EntregadorId);
            if (!entregadorExiste) AdicionarErro("Entregador não encontrado");

            return destinatarioExiste && entregadorExiste;

        }
    }
}
