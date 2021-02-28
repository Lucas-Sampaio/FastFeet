using AutoMapper;
using FastFeet.API.Application.Commands.DestinatarioCommands;
using FastFeet.API.Application.DTO;
using FastFeet.Dominio.AggregatesModel.DestinatarioAggregate;

namespace FastFeet.API.AutoMapper
{
    public class DestinatarioProfile : Profile
    {
        public DestinatarioProfile()
        {
            CreateMap<EnderecoDTO, Endereco>();
            CreateMap<CadastrarDestinatarioCommand, Destinatario>();
            CreateMap<AtualizarDestinatarioCommand, Destinatario>();
        }
    }
}
