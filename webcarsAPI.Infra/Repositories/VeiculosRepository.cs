using Microsoft.EntityFrameworkCore;
using webcarsAPI.Comunicacao.Requests.Veiculos;
using webcarsAPI.Comunicacao.Responses.Veiculo;
using webcarsAPI.Dominio.Entidades;
using webcarsAPI.Dominio.Repositories.Veiculos;
using webcarsAPI.Infra.DataAccess;

namespace webcarsAPI.Infra.Repositories
{
    public class VeiculosRepository : IVeiculosRepository
    {
        private readonly AppDbContext _context;
        public VeiculosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarVeiculo(Veiculo veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
        }

        public async Task<bool> ExisteChassi(string chassi)
        {
            return await _context.Veiculos.AnyAsync(veiculo => veiculo.Chassi == chassi);
        }

        public async Task<bool> ExistePlacaCadastrada(string placa)
        {
            return await _context.Veiculos.AnyAsync(veiculo => veiculo.Placa == placa);
        }

        public async Task<bool> ExisteRenavam(string renavam)
        {
            return await _context.Veiculos.AnyAsync(veiculo => veiculo.Renavam == renavam);
        }
    }
}
