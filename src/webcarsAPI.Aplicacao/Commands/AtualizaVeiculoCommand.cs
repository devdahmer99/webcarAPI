using MediatR;
using webcarsAPI.Comunicacao.Requests.Veiculos;
using webcarsAPI.Comunicacao.Responses.Veiculo;

namespace webcarsAPI.Aplicacao.Commands;
public class AtualizaVeiculoCommand : IRequest<ResponseAdicionaVeiculo>
{
    public Guid VeiculoId { get; set; }
    public RequestAdicionaVeiculo Veiculo { get; set; }

    public AtualizaVeiculoCommand(Guid veiculoId, RequestAdicionaVeiculo veiculo)
    {
        VeiculoId = veiculoId;
        Veiculo = veiculo;
    }
}
