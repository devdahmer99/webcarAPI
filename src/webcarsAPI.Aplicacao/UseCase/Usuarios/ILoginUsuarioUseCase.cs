using webcarsAPI.Comunicacao.Requests.Usuarios;
using webcarsAPI.Comunicacao.Responses.Usuario;

namespace webcarsAPI.Aplicacao.UseCase.Usuarios
{
    public interface ILoginUsuarioUseCase
    {
        Task<ResponseUsuarioRegistrado> Execute(RequestLoginUsuario request);
    }
}
