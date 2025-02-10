using webcarsAPI.Comunicacao.Requests.Veiculos;
using webcarsAPI.Comunicacao.Responses.Veiculo;
using webcarsAPI.Dominio.Entidades;

namespace webcarsAPI.Dominio.Repositories.Veiculos
{
    public interface IVeiculosRepository
    {
        Task<List<Veiculo>> BuscarTodosOsVeiculos();
        Task<Veiculo?> BuscaVeiculoPorId(Guid veiculoId);
        Task AdicionarVeiculo(Veiculo veiculo);
        Task<bool> ExistePlacaCadastrada(string placa);
        Task<bool> ExisteRenavam(string renavam);
        Task<bool> ExisteChassi(string chassi);
    }
}
