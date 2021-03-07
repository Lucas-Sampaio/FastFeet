using AutoMapper;
using FastFeet.API.Application.Commands.EncomendaCommands;
using FastFeet.Dominio.AggregatesModel.EncomendasAggregate;

namespace FastFeet.API.AutoMapper
{
    public class EncomendaProfile : Profile
    {
        public EncomendaProfile()
        {
            CreateMap<CadastrarEncomendaCommand, Encomenda>();
            CreateMap<AtualizarEncomendaCommand, Encomenda>();
        }
    }
}
