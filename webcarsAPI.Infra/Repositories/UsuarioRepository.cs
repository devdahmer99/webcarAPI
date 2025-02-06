
using Microsoft.EntityFrameworkCore;
using webcarsAPI.Dominio.Entidades;
using webcarsAPI.Dominio.Repositories.Usuarios;
using webcarsAPI.Infra.DataAccess;

namespace webcarsAPI.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarUsuarioAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task<Usuario?> BuscaUsuarioPorEmail(string email)
        {
            return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(user => user.Email!.Equals(email));
        }

        public async Task<bool> VerificaExistenciaUsuarioPorEmail(string email)
        {
            return await _context.Usuarios.AnyAsync(user => user.Email == email);
        }
    }
}