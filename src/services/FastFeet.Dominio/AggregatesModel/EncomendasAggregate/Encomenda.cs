using FastFeet.Dominio.AggregatesModel.DestinatarioAggregate;
using FastFeet.Dominio.AggregatesModel.EntregadorAggregate;
using FastFeet.Dominio.Exceptions;
using FastFeet.Dominio.SeedWork;
using System;
using System.Collections.Generic;

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
        public DateTime? CanceledAt { get; private set; }
        public DateTime? DataInicio { get; private set; }
        public DateTime? DataFinal { get; private set; }
        public Entregador Entregador { get; set; }
        public Destinatario Destinatario { get; set; }

        private readonly List<EncomedaProblemas> _problemas;
        public IReadOnlyCollection<EncomedaProblemas> Problemas => _problemas;

        public void CancelarEncomenda() => CanceledAt = DateTime.Now;
        public void RetirarEncomenda()
        {
            DataInicio = DateTime.Now;
            if (!EhHoraValida(DataInicio.Value)) throw new DomainException("Fora do horário de retirada");
        }
        public static bool EhHoraValida(DateTime dataInicio)
        {
            var hora = dataInicio.Hour;
            if (hora < 8 || hora > 18) return false;
            return true;
        }
        public void FinalizarEntrega() => DataFinal = DateTime.Now;
    }
}

