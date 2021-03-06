using AutoMapper;
using FastFeet.API.Application.Commands.EntregadorCommands;
using FastFeet.Dominio.AggregatesModel.EntregadorAggregate;

namespace FastFeet.API.AutoMapper
{
    public class EntregadorProfile : Profile
    {
        public EntregadorProfile()
        {
            CreateMap<CadastrarEntregadorCommand, Entregador>();
            CreateMap<AtualizarEntregadorCommand, Entregador>();
        }
    }
}
