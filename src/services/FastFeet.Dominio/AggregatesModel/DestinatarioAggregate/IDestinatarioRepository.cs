using FastFeet.Dominio.SeedWork;
using System.Threading.Tasks;

namespace FastFeet.Dominio.AggregatesModel.DestinatarioAggregate
{
    public interface IDestinatarioRepository : IRepository<Destinatario>
    {
        Destinatario Cadastrar(Destinatario destinatario);
        void Update(Destinatario destinatario);
    }
}
