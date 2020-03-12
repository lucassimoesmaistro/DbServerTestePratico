using System;
using System.IO.Compression;
using AutoMapper;
using DbServer.ContaCorrente.Api.Inicializador;
using DbServer.Comum.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DbServer.ContaCorrente.Api
{
    public class Startup
    {
        public IHostingEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            string appsettingNome = "";

            if (env.IsProduction())
                appsettingNome = "appsettings";
            else
                appsettingNome = $"appsettings.{env.EnvironmentName}";

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"{appsettingNome}.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();

            HostingEnvironment = env;

            if (env.IsDevelopment())
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuration
            services.AddSingleton(_ => Configuration);
            services.AddSingleton<IConfiguration>(_ => Configuration);

            services.AddAutoMapper();

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwagger();

            //ConfiguracaoDoAutoMapper.RegisterMappings();

            services.AddRepositorio();
            services.AddDominio();
            services.AddServicosDeAplicacao();
            services.AddAplicacao();
            services.AddSerilogServices(HostingEnvironment.ApplicationName);

            //Menor trafego de dados
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            // O método AddJsonOptions permite a customização das configurações de serialização
            // Ignorar propriedades nulas
            services.AddMvc().AddJsonOptions(opcoes =>
            {
                opcoes.SerializerSettings.NullValueHandling =
                    Newtonsoft.Json.NullValueHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseTratamentoDeErrosGlobal();

            app.UseCors(builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Contas Correntes");
            });

            app.UseHttpsRedirection();

            app.UseMvc();
        }

    }
}
