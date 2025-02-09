using webcarsAPI.Comunicacao.Requests.Usuarios;
using webcarsAPI.Comunicacao.Responses.Usuario;

namespace webcarsAPI.Aplicacao.UseCase.Usuarios.Criar
{
    public interface IAdicionarUsuarioUseCase
    {
        Task<ResponseCriaUsuario> Execute(RequestCriaUsuario request);
    }
}
