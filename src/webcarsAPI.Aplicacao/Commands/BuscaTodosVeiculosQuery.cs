using MediatR;
using webcarsAPI.Comunicacao.Responses.Veiculo;

namespace webcarsAPI.Aplicacao.Commands;
public class BuscaTodosVeiculosQuery : IRequest<IEnumerable<ResponseVeiculos>>
{
}
