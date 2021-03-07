using FastFeet.Dominio.AggregatesModel.EncomendasAggregate;
using FastFeet.Dominio.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public Encomenda ObterPorId(int id)
        {
            return _context.Encomendas.Find(id);
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
