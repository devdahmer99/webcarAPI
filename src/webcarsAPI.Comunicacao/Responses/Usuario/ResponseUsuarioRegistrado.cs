using System.Globalization;

namespace webcarsAPI.Comunicacao.Responses.Usuario
{
    public class ResponseUsuarioRegistrado
    {
        public int Id { get; set; }
        public string? Nome { get;set; }
        public string? Token { get; set; }
    }
}
