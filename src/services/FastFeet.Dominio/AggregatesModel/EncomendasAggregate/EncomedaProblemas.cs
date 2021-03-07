using FastFeet.Dominio.SeedWork;

namespace FastFeet.Dominio.AggregatesModel.EncomendasAggregate
{
    //child entity
    public class EncomedaProblemas : Entity
    {
        protected EncomedaProblemas() { }
        public EncomedaProblemas(string descricao, int encomendaId)
        {
            Descricao = descricao;
            EncomendaId = encomendaId;
        }

        public int EncomendaId { get; set; }
        public string Descricao { get; set; }
    }
}
