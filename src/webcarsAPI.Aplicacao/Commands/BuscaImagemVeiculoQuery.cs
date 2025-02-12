using MediatR;
using webcarsAPI.Comunicacao.Responses.Veiculo;

namespace webcarsAPI.Aplicacao.Commands;
public class BuscaImagemVeiculoQuery : IRequest<IEnumerable<ResponseVeiculoImagem>>
{

}
