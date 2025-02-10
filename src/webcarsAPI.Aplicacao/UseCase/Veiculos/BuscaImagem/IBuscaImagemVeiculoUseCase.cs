using webcarsAPI.Comunicacao.Responses.Veiculo;

namespace webcarsAPI.Aplicacao.UseCase.Veiculos.BuscaImagem;
public interface IBuscaImagemVeiculoUseCase
{
    Task<ResponseVeiculoImagem> BuscaImagemVeiculo();
}
