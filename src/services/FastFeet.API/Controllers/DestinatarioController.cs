using FastFeet.API.Application.Commands.DestinatarioCommands;
using FastFeet.API.Mediator;
using FastFeet.WebApi.Core.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastFeet.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class DestinatarioController : MainController
    {
     
        private readonly IMediatorHandler _mediator;

        public DestinatarioController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> AdicionarDestinatario(CadastrarDestinatarioCommand destinatarioCommand)
        {
            var response = await _mediator.EnviarComando(destinatarioCommand);
            return CustomResponse(response,StatusCodes.Status201Created);
        }
        [HttpPut("")]
        public async Task<IActionResult> AtualizarDestinatario(AtualizarDestinatarioCommand destinatarioCommand)
        {
            var response = await _mediator.EnviarComando(destinatarioCommand);
            return CustomResponse(response, StatusCodes.Status204NoContent);
        }
    }
}
