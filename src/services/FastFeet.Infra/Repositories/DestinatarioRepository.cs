using FastFeet.Dominio.AggregatesModel.DestinatarioAggregate;
using FastFeet.Dominio.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FastFeet.Infra.Repositories
{
    public class DestinatarioRepository : IDestinatarioRepository
    {
        private readonly FastFeetContext _context;

        public DestinatarioRepository(FastFeetContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Destinatario Cadastrar(Destinatario destinatario)
        {
            var entidade = _context.Destinatarios.Add(destinatario).Entity;
            return entidade;
        }

        public void Atualizar(Destinatario destinatario)
        {
            _context.Update(destinatario);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<bool> Existe(Expression<Func<Destinatario, bool>> expression)
        {
            return await _context.Destinatarios.AnyAsync(expression);
        }
    }
}
