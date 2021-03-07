using FastFeet.Dominio.AggregatesModel.EncomendasAggregate;
using FastFeet.Dominio.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FastFeet.Dominio.AggregatesModel.EntregadorAggregate
{
    public interface IEntregadorRepository : IRepository<Entregador>
    {
        Task<ICollection<Entregador>> ObterTodos();
        Entregador ObterPorId(int id);
        Entregador Cadastrar(Entregador entregador);
        void Atualizar(Entregador entregador);
        void Remover(Entregador entregador); 
        Task<bool> Existe(Expression<Func<Entregador, bool>> expression);
        Task<ICollection<Encomenda>> ObterEntregasDisponiveis(int entregadorId);
        int ContarRetiradasNoDia(int entregadorId);
    }
}
