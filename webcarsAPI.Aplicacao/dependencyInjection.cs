using Microsoft.Extensions.DependencyInjection;
using webcarsAPI.Aplicacao.AutoMapper;
using webcarsAPI.Aplicacao.UseCase.Usuarios;
using webcarsAPI.Aplicacao.UseCase.Usuarios.Criar;
using webcarsAPI.Aplicacao.UseCase.Veiculos.BuscaPorId;
using webcarsAPI.Aplicacao.UseCase.Veiculos.Cadastrar;

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
            services.AddScoped<IAdicionaVeiculoUseCase, AdicionaVeiculoUseCase>();
            services.AddScoped<ILoginUsuarioUseCase, LoginUsuarioUseCase>();
            services.AddScoped<IBuscaVeiculosPorIdUseCase, BuscaVeiculosPorIdUseCase>();
        }
    }
}
