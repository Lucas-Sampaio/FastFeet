using FastFeet.API.Application.Commands.EncomendaCommands;
using FastFeet.API.Mediator;
using FastFeet.Dominio.AggregatesModel.EncomendasAggregate;
using FastFeet.WebApi.Core.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastFeet.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class EncomendaController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IEncomendaRepository _encomendaRepository;
        public EncomendaController(IMediatorHandler mediator, IEncomendaRepository encomendaRepository)
        {
            _mediator = mediator;
            _encomendaRepository = encomendaRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var response = await _encomendaRepository.ObterTodos();
            return CustomResponse(response, StatusCodes.Status200OK);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(CadastrarEncomendaCommand command)
        {
            var response = await _mediator.EnviarComando(command);
            if (!response.IsValid) return CustomResponse(response);
            return CustomResponse(response, StatusCodes.Status201Created);
        }
        [HttpPut("")]
        public async Task<IActionResult> Put(AtualizarEncomendaCommand command)
        {
            var response = await _mediator.EnviarComando(command);
            if (!response.IsValid) return CustomResponse(response);
            return CustomResponse(response, StatusCodes.Status204NoContent);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var encomenda = _encomendaRepository.ObterPorId(id);
            if (encomenda == null) return NotFound("Encomenda não encontrada");

            _encomendaRepository.Remover(encomenda);
            _encomendaRepository.UnitOfWork.Commit();
            return CustomResponse(null, StatusCodes.Status204NoContent);
        }
    }
}
