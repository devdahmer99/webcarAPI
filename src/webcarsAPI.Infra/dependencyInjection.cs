using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webcarsAPI.Dominio.Repositories.UnitOfWork;
using webcarsAPI.Dominio.Repositories.Usuarios;
using webcarsAPI.Dominio.Repositories.Veiculos;
using webcarsAPI.Dominio.Seguranca;
using webcarsAPI.Infra.DataAccess;
using webcarsAPI.Infra.Repositories;
using webcarsAPI.Infra.Seguranca.Cripty;
using webcarsAPI.Infra.Seguranca.JWT;


namespace webcarsAPI.Infra
{
    public static class dependencyInjection
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPasswordIncripty, Encripty>();

            AdicionaRepositorios(services);
            AddToken(services, configuration);
            AddDbContext(services, configuration);
        }

        private static void AdicionaRepositorios(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVeiculosRepository, VeiculosRepository>();
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationMinutes = configuration.GetValue<uint>("Settings:JWt:ExpiresMinutes");
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

            services.AddScoped<ITokenGenerator>(config => new JwtTokenGenerator(signingKey!, expirationMinutes));
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var conenctionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = ServerVersion.AutoDetect(conenctionString);

            services.AddDbContext<AppDbContext>(config => config.UseMySql(conenctionString, serverVersion));
        }
    }
}
