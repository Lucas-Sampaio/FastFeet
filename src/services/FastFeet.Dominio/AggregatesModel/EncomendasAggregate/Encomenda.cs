using FastFeet.Dominio.AggregatesModel.DestinatarioAggregate;
using FastFeet.Dominio.AggregatesModel.EntregadorAggregate;
using FastFeet.Dominio.Exceptions;
using FastFeet.Dominio.SeedWork;
using System;

namespace FastFeet.Dominio.AggregatesModel.EncomendasAggregate
{
    public class Encomenda : Entity, IAggregateRoot
    {
        protected Encomenda() { }

        public Encomenda(int destinatarioId, int entregadorId, string descricao)
        {
            DestinatarioId = destinatarioId;
            EntregadorId = entregadorId;
            Descricao = descricao;
        }

        public int DestinatarioId { get; set; }
        public int EntregadorId { get; set; }
        public string Descricao { get; set; }
        public int AssinaturaId { get; set; }
        public DateTime? CanceledAt { get; set; }
        public DateTime? DataInicio { get; private set; }
        public DateTime? DataFinal { get; private set; }
        public Entregador Entregador { get; set; }
        public Destinatario Destinatario { get; set; }
        public void RetirarEncomenda()
        {
            DataInicio = DateTime.Now;
            if (!EhHoraValida(DataInicio.Value)) throw new DomainException("Fora do horário de retirada");
        }
        public bool EhHoraValida(DateTime dataInicio)
        { 
            var hora = dataInicio.Hour;
            if (hora < 8 || hora > 18) return false;
            return true;
        }
        public void FinalizarEntrega() => DataFinal = DateTime.Now;
    }
}

