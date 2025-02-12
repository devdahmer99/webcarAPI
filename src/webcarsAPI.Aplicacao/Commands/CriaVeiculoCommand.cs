using MediatR;
using webcarsAPI.Comunicacao.Requests.Veiculos;
using webcarsAPI.Comunicacao.Responses.Veiculo;


namespace webcarsAPI.Aplicacao.Commands;
public class CriaVeiculoCommand : IRequest<ResponseAdicionaVeiculo>
{
    public RequestAdicionaVeiculo Veiculo { get; set; }

    public CriaVeiculoCommand(RequestAdicionaVeiculo veiculo)
    {
        Veiculo = veiculo;
    }
}
