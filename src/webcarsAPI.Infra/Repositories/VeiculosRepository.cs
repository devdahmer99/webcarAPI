using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webcarAPI.Infra.DataAccess;
using webcarsAPI.Dominio.Entidades;
using webcarsAPI.Dominio.Repositories.Veiculos;

namespace webcarsAPI.Infra.Repositories
{
    public class VeiculosRepository : IVeiculosRepository
    {
        private readonly AppDbContext _context;
        public VeiculosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Veiculo> AddVeiculoAsync(Veiculo veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
            return veiculo;
        }

        public void AtualizaVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
        }

        public async Task<List<Veiculo>> GetAllVeiculosAsync()
        {
            return await _context.Veiculos.AsNoTracking().ToListAsync();
        }

        public async Task<Veiculo?> GetVeiculoByIdAsync(Guid veiculoId)
        {
            return await _context.Veiculos.AsNoTracking()
                .FirstOrDefaultAsync(veiculo => veiculo.VeiculoId == veiculoId);
        }

        public async Task<bool> DeleteVeiculoAsync(Veiculo veiculo, Guid id)
        {
            var result = await _context.Veiculos.FirstOrDefaultAsync(v => v.VeiculoId == id);
            if (result == null)
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