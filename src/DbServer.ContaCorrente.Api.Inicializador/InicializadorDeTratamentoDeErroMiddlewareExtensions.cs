using DbServer.Comum.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace DbServer.ContaCorrente.Api.Inicializador
{
    public static class InicializadorDeTratamentoDeErroMiddlewareExtensions
    {
        public static IApplicationBuilder UseTratamentoDeErrosGlobal(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MiddlewareDeExcecaoGlobal>();
        }
    }
}
