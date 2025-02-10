using webcarsAPI.Comunicacao.Responses.Veiculo;

namespace webcarsAPI.Aplicacao.UseCase.Veiculos.BuscaPorId
{
    public interface IBuscaVeiculosPorIdUseCase
    {
        Task<ResponseVeiculo> Execute(Guid veiculoId);
    }
}
