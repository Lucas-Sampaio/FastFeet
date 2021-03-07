using FastFeet.Dominio.AggregatesModel.EncomendasAggregate;
using FastFeet.WebApi.Core.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastFeet.API.Controllers
{
    [Route("api/[controller]")]

    public class ProblemaController : MainController
    {
        private readonly IEncomendaRepository _encomendaRepository;

        public ProblemaController(IEncomendaRepository encomendaRepository)
        {
            _encomendaRepository = encomendaRepository;
        }

        [HttpDelete("{id}/cancelar-entrega")]
        public async Task<IActionResult> Get(int id)
        {
            var encomenda = _encomendaRepository.ObterPorId(id);
            if (encomenda == null) NotFound("Encomenda não encontrada");
            
            encomenda.CancelarEncomenda();
            _encomendaRepository.Atualizar(encomenda);
            await _encomendaRepository.UnitOfWork.Commit();

            return CustomResponse(null, StatusCodes.Status204NoContent);
        }
    }
}
