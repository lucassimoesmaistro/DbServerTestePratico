using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.ContaCorrente.Api.Inicializador
{
    public static class InicializadorDominioMiddlewareExtensions
    {

        public static IServiceCollection AddDominio(this IServiceCollection services)
        {
            //services.AddTransient<IServicoDeIntegracaoAbcfarma, ServicoDeIntegracaoAbcfarma>();

            return services;
        }
    }
}
