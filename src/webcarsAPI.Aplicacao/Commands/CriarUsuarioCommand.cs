using MediatR;
using webcarsAPI.Comunicacao.Responses.Usuario;

namespace webcarsAPI.Aplicacao.Commands;
public class CriarUsuarioCommand : IRequest<ResponseCriaUsuario>
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public List<string>? Cargos { get; set; }
}
