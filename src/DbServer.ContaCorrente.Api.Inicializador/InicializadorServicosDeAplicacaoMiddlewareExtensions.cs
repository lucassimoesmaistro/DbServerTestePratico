using Microsoft.Extensions.DependencyInjection;

namespace DbServer.ContaCorrente.Api.Inicializador
{
    public static class InicializadorServicosDeAplicacaoMiddlewareExtensions
    {

        public static IServiceCollection AddServicosDeAplicacao(this IServiceCollection services)
        {

            //services.AddTransient<IAbcfarmaServicoWeb, AbcfarmaServicoWeb>();

            return services;
        }
    }
}
