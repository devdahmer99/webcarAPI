using MediatR;
using webcarsAPI.Comunicacao.Responses.Veiculo;

namespace webcarsAPI.Aplicacao.Commands;
public class BuscaVeiculoPorIdQuery : IRequest<ResponseVeiculo>
{
    public Guid VeiculoId { get; set; }
    public BuscaVeiculoPorIdQuery(Guid veiculoId)
    {
        VeiculoId = veiculoId;
    }
}
