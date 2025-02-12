using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webcarsAPI.Dominio.Entidades;

namespace webcarsAPI.Dominio.Repositories.Veiculos
{
    public interface IVeiculosRepository
    {
        Task<Veiculo> AddVeiculoAsync(Veiculo veiculo);
        void AtualizaVeiculo(Veiculo veiculo);
        Task<List<Veiculo>> GetAllVeiculosAsync();
        Task<Veiculo?> GetVeiculoByIdAsync(Guid veiculoId);
        Task<bool> DeleteVeiculoAsync(Veiculo veiculo, Guid id);
        Task<bool> ExisteChassi(string chassi);
        Task<bool> ExistePlacaCadastrada(string placa);
        Task<bool> ExisteRenavam(string renavam);
    }
}