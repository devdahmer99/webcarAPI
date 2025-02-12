using Microsoft.Extensions.DependencyInjection;
using webcarsAPI.Aplicacao.AutoMapper;

namespace webcarsAPI.Aplicacao
{
    public static class dependencyInjection
    {
        public static void AdicionaAplicacao(this IServiceCollection services)
        {
            AdicionarMediatR(services);
            AdicionaAutoMapper(services);
        }

        private static void AdicionaAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AdicionarMediatR(IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(dependencyInjection).Assembly));
        }
    }
}