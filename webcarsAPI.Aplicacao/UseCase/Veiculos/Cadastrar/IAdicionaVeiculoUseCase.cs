using webcarsAPI.Comunicacao.Requests.Veiculos;
using webcarsAPI.Comunicacao.Responses.Veiculo;

namespace webcarsAPI.Aplicacao.UseCase.Veiculos.Cadastrar
{
    public interface IAdicionaVeiculoUseCase
    {
        Task<ResponseAdicionaVeiculo> Execute(RequestAdicionaVeiculo request);
    }
}
