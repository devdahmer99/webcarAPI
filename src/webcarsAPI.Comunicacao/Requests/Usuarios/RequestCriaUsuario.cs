using webcarsAPI.Comunicacao.Enums;

namespace webcarsAPI.Comunicacao.Requests.Usuarios
{
    public class RequestCriaUsuario
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
