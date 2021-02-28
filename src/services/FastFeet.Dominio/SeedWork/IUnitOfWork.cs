using System.Threading.Tasks;

namespace FastFeet.Dominio.SeedWork
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
