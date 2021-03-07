using FastFeet.Dominio.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFeet.Dominio.AggregatesModel.EncomendasAggregate
{
    public interface IEncomendaRepository : IRepository<Encomenda>
    {
        Task<ICollection<Encomenda>> ObterTodos();
        Encomenda ObterPorId(int id, params string[] includeProperties);
        Encomenda Cadastrar(Encomenda encomenda);
        void Atualizar(Encomenda encomenda);
        void Remover(Encomenda encomenda);
        void AdicionarProblema(EncomedaProblemas encomedaProblema);
        
    }
}
