using webcarsAPI.Infra.DataAccess;

namespace webcarsAPI.Infra.Services
{
    public class TokenService
    {
        private readonly AppDbContext _context;
        public TokenService(AppDbContext context)
        {
            _context = context;
        }
    }
}
