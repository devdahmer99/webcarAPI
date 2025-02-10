using webcarsAPI.Comunicacao.Responses.Veiculo;

namespace webcarsAPI.Aplicacao.UseCase.Veiculos.Busca;
public interface IBuscaVeiculosUseCase
{
    Task<ResponseVeiculos> Execute();
}
