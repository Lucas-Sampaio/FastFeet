using FastFeet.Dominio.AggregatesModel.DestinatarioAggregate;
using FastFeet.Dominio.SeedWork;

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

        public void Update(Destinatario destinatario)
        {
            _context.Update(destinatario);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
