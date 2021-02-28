using FastFeet.Dominio.SeedWork;
using System.Threading.Tasks;

namespace FastFeet.Dominio.AggregatesModel.DestinatarioAggregate
{
    public interface IDestinatarioRepository : IRepository<Destinatario>
    {
        Task<int> Cadastrar(Destinatario destinatario);
        Task Update(Destinatario destinatario);
    }
}
