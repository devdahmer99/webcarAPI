using AutoMapper;
using webcarsAPI.Comunicacao.Requests.Usuarios;
using webcarsAPI.Comunicacao.Requests.Veiculos;
using webcarsAPI.Comunicacao.Responses.Usuario;
using webcarsAPI.Comunicacao.Responses.Veiculo;
using webcarsAPI.Dominio.Entidades;

namespace webcarsAPI.Aplicacao.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            BuscaEntidade();
            RetornaEntidade();
        }

        public void BuscaEntidade()
        {
            CreateMap<RequestCriaUsuario, Usuario>();
            CreateMap<VeiculoRequest, Veiculo>();
        }

        public void RetornaEntidade()
        {
            CreateMap<Usuario, ResponseCriaUsuario>();
            CreateMap<Veiculo, VeiculoResponse>();
        }
    }
}
