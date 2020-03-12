using Microsoft.Extensions.DependencyInjection;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace DbServer.ContaCorrente.Api.Inicializador
{
    public static class InicializadorRepositorioMiddlewareExtensions
    {
        public static IServiceCollection AddRepositorio(this IServiceCollection services)
        {
            FluentMapper.Initialize(cfg =>
            {
               // cfg.AddMap(new MapeadorCondicaoComercial());
               

                cfg.ForDommel();
            });

            //services.AddScoped<IRepositorioPG, Repositorio.Base.RepositorioPG>();
            //services.AddScoped<IConexaoPG, PostgreSQLConexao>();

            //services.AddTransient<IRepositorioDeAbcfarma, RepositorioDeAbcfarma>();

            return services;
        }
    }
}
