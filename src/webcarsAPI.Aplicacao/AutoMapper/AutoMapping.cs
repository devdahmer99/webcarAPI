using AutoMapper;
using webcarsAPI.Comunicacao.Requests.Usuarios;
using webcarsAPI.Comunicacao.Requests.Veiculos;
using webcarsAPI.Comunicacao.Responses.Usuario;
using webcarsAPI.Comunicacao.Responses.Veiculo;
using webcarsAPI.Dominio.Entidades;
using webcarsAPI.Aplicacao.Commands;
using Microsoft.AspNet.Identity.EntityFramework;

namespace webcarsAPI.Aplicacao.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<RequestAdicionaVeiculo, Veiculo>()
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => src.Marca))
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Modelo))
                .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => src.Ano))
                .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.Placa))
                .ForMember(dest => dest.Cor, opt => opt.MapFrom(src => src.Cor))
                .ForMember(dest => dest.Chassi, opt => opt.MapFrom(src => src.Chassi))
                .ForMember(dest => dest.Renavam, opt => opt.MapFrom(src => src.Renavam))
                .ForMember(dest => dest.Combustivel, opt => opt.MapFrom(src => src.Combustivel))
                .ForMember(dest => dest.Quilometragem, opt => opt.MapFrom(src => src.Quilometragem))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(dest => dest.Imagem, opt => opt.MapFrom(src => src.Imagem))

                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UsuarioId));

            CreateMap<IdentityUser, ResponseCriaUsuario>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<Veiculo, ResponseAdicionaVeiculo>();
            CreateMap<Veiculo, ResponseVeiculo>();
        }
    }
}