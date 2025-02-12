
namespace webcarsAPI.Comunicacao.Requests.Usuarios
{
    public class UsuarioRequest
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int? VeiculoId { get; set; }
    }
}