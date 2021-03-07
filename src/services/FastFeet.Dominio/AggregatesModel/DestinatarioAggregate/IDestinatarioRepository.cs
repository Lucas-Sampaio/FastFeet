using FastFeet.Dominio.SeedWork;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FastFeet.Dominio.AggregatesModel.DestinatarioAggregate
{
    public interface IDestinatarioRepository : IRepository<Destinatario>
    {
        Destinatario Cadastrar(Destinatario destinatario);
        void Atualizar(Destinatario destinatario);
        Task<bool> Existe(Expression<Func<Destinatario, bool>> expression);
    }
}
