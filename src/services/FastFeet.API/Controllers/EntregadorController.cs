using FastFeet.API.Application.Commands.EntregadorCommands;
using FastFeet.API.Mediator;
using FastFeet.Dominio.AggregatesModel.EntregadorAggregate;
using FastFeet.WebApi.Core.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastFeet.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class EntregadorController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IEntregadorRepository _entregadorRepository;
        public EntregadorController(IMediatorHandler mediator, IEntregadorRepository entregadorRepository)
        {
            _mediator = mediator;
            _entregadorRepository = entregadorRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var response = await _entregadorRepository.ObterTodos();
            return CustomResponse(response, StatusCodes.Status200OK);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(CadastrarEntregadorCommand entregadorCommand)
        {
            var response = await _mediator.EnviarComando(entregadorCommand);
            if (!response.IsValid) return CustomResponse(response);
            return CustomResponse(response, StatusCodes.Status201Created);
        }
        [HttpPut("")]
        public async Task<IActionResult> Put(AtualizarEntregadorCommand entregadorCommand)
        {
            var response = await _mediator.EnviarComando(entregadorCommand);
            if (!response.IsValid) return CustomResponse(response);
            return CustomResponse(response, StatusCodes.Status204NoContent);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entregador = _entregadorRepository.ObterPorId(id);
            if (id == 0 || entregador == null) return NotFound("Entregador não encontrado");

            _entregadorRepository.Remover(entregador);
            _entregadorRepository.UnitOfWork.Commit();
            return CustomResponse(null, StatusCodes.Status204NoContent);
        }
    }
}
