using Microsoft.Extensions.DependencyInjection;
using webcarsAPI.Aplicacao.AutoMapper;

namespace webcarsAPI.Aplicacao
{
    public static class dependencyInjection
    {
        public static void AdicionaAplicacao(this IServiceCollection services)
        {
            AdicionaAutoMapper(services);
        }

        private static void AdicionaAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }
    }
}