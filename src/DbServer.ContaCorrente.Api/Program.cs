using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace DbServer.ContaCorrente.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", optional: true)
                .Build();

            BuildWebHost(args, config).Run();
        }
        public static IWebHost BuildWebHost(string[] args, IConfiguration configurationBuilder) =>
                    WebHost.CreateDefaultBuilder(args)
                        .UseIISIntegration()
                        .UseKestrel()
                        .UseConfiguration(configurationBuilder)
                        .UseStartup<Startup>()
                        .Build();
    }
}
