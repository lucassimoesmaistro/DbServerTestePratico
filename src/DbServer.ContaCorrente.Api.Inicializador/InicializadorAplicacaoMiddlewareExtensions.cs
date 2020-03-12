using Microsoft.Extensions.DependencyInjection;
using System;

namespace DbServer.ContaCorrente.Api.Inicializador
{
    public static class InicializadorAplicacaoMiddlewareExtensions
    {
        public static IServiceCollection AddAplicacao(this IServiceCollection services)
        {
            //services.AddTransient<IAplicacaoDeVenda, AplicacaoDeVenda>();

            return services;
        }
    }
}
