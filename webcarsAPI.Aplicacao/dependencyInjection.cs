using Microsoft.Extensions.DependencyInjection;
using webcarsAPI.Aplicacao.AutoMapper;
using webcarsAPI.Aplicacao.UseCase.Usuarios;
using webcarsAPI.Aplicacao.UseCase.Usuarios.Criar;

namespace webcarsAPI.Aplicacao
{
    public static class dependencyInjection
    {
        public static void AdicionaAplicacao(this IServiceCollection services)
        {
            AdicionaAutoMapper(services);
            AdicionaUseCase(services);
        }

        private static void AdicionaAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AdicionaUseCase(IServiceCollection services)
        {
            services.AddScoped<IAdicionarUsuarioUseCase, AdicionarUsuarioUseCase>();
            services.AddScoped<ILoginUsuarioUseCase, LoginUsuarioUseCase>();
        }
    }
}
