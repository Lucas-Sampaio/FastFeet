using FastFeet.Dominio.SeedWork;

namespace FastFeet.Dominio.AggregatesModel.DestinatarioAggregate
{
    public class Destinatario : Entity, IAggregateRoot
    {
        protected Destinatario()
        {

        }
        public Destinatario(string nome, Endereco endereco)
        {
            Nome = nome;
            Endereco = endereco;
        }

        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
    }
}
