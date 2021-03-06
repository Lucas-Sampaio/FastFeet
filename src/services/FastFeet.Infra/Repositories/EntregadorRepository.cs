using FastFeet.Dominio.AggregatesModel.EntregadorAggregate;
using FastFeet.Dominio.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FastFeet.Infra.Repositories
{
    public class EntregadorRepository : IEntregadorRepository
    {
        private readonly FastFeetContext _context;
        public EntregadorRepository(FastFeetContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Atualizar(Entregador entregador)
        {
            _context.Update(entregador);
        }

        public Entregador Cadastrar(Entregador entregador)
        {
            var entidade = _context.Entregadores.Add(entregador).Entity;
            return entidade;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<bool> Existe(Expression<Func<Entregador, bool>> expression)
        {
            return await _context.Entregadores.AnyAsync(expression);
        }

        public Entregador ObterPorId(int id)
        {
            return  _context.Entregadores.Find(id);
        }

        public async Task<ICollection<Entregador>> ObterTodos()
        {
            return await _context.Entregadores.ToListAsync();
        }

        public void Remover(Entregador entregador)
        {
            _context.Entregadores.Remove(entregador);
        }
    }
}
