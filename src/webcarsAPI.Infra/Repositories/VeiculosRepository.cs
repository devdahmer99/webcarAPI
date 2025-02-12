using Microsoft.EntityFrameworkCore;
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

        public void AtualizaVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
        }

        public async Task<List<Veiculo>> BuscarTodosOsVeiculos()
        {
            return await _context.Veiculos.AsNoTracking().ToListAsync();
        }

        public async Task<Veiculo?> BuscaVeiculoPorId(Guid veiculoId)
        {
            return await _context.Veiculos.AsNoTracking().FirstOrDefaultAsync(veiculo => veiculo.Id == veiculoId);
        }

        public async Task<bool> deletaVeiculo(Veiculo veiculo, Guid id)
        {
            var result = await _context.Veiculos.FirstOrDefaultAsync(veiculo => veiculo.Id == id);
            if(result == null)
            {
                return false;
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();
            return true;
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
