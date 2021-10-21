using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace lesson12
{
    class Program
    {
        static Task Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .RunAsync();

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(Configure);
        }

        private static void Configure(HostBuilderContext context, IServiceCollection services)
        {
            services.AddHostedService<Reminder>();
            services.AddHostedService<Reminder2>();
            services.AddSingleton<LoggerWriter>();
            services.AddTransient<MessageWriter>();
        }
    }
}
