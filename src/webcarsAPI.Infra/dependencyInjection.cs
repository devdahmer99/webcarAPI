using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webcarsAPI.Dominio.Repositories.UnitOfWork;
using webcarsAPI.Dominio.Repositories.Usuarios;
using webcarsAPI.Dominio.Repositories.Veiculos;
using webcarsAPI.Infra.DataAccess;
using webcarsAPI.Infra.Repositories;


namespace webcarsAPI.Infra
{
    public static class dependencyInjection
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            AdicionaRepositorios(services);
            AddDbContext(services, configuration);
        }

        private static void AdicionaRepositorios(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVeiculosRepository, VeiculosRepository>();
        }
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(config => config.UseSqlServer(connectionString));
        }
    }
}
