using FastFeet.Dominio.AggregatesModel.EncomendasAggregate;
using FastFeet.Dominio.SeedWork;
using FastFeet.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFeet.Infra.Repositories
{
    public class EncomendaRepository : IEncomendaRepository
    {
        private readonly FastFeetContext _context;

        public EncomendaRepository(FastFeetContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void AdicionarProblema(EncomedaProblemas encomedaProblema)
        {
            _context.EncomedaProblemas.Add(encomedaProblema);
        }

        public void Atualizar(Encomenda encomenda)
        {
            _context.Encomendas.Update(encomenda);
        }

        public Encomenda Cadastrar(Encomenda encomenda)
        {
            var entidade = _context.Encomendas.Add(encomenda).Entity;
            return entidade;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Encomenda ObterPorId(int id, params string[] includeProperties)
        {
            return _context.Encomendas.IncludeProp(includeProperties).SingleOrDefault(x => x.Id == id);
        }

        public async Task<ICollection<Encomenda>> ObterTodos()
        {
            return await _context.Encomendas.ToListAsync();
        }

        public void Remover(Encomenda encomenda)
        {
            _context.Encomendas.Remove(encomenda);
        }
    }
}
