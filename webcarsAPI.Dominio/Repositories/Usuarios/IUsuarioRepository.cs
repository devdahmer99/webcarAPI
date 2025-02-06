using webcarsAPI.Comunicacao.Requests.Usuarios;
using webcarsAPI.Dominio.Entidades;

namespace webcarsAPI.Dominio.Repositories.Usuarios
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> BuscaUsuarioPorEmail(string email);
        Task AdicionarUsuarioAsync(Usuario usuario);
        Task<bool> VerificaExistenciaUsuarioPorEmail(string email);
    }
}