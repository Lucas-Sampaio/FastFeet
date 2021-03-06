using FastFeet.Dominio.SeedWork;

namespace FastFeet.Dominio.AggregatesModel.EntregadorAggregate
{
    public class Entregador : Entity, IAggregateRoot
    {
        protected Entregador() { }
        public Entregador(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; set; }   
        public string Email { get; set; }
        public int AvatarId { get; set; }
    }
}
