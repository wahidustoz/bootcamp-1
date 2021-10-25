using System;
using System.Threading.Tasks;
using bot.HttpClients;
using bot.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

namespace bot
{
    class Program
    {
        static Task Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .RunAsync();

        private static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices(Configure);

        private static void Configure(HostBuilderContext context, IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddTransient<ICacheService, PrayerTimeCacheService>();
            services.AddSingleton<TelegramBotClient>(b => new TelegramBotClient("1999924501:AAH5qozUtZeQgf_OHDBhSTvXsNK6DLuoD0U"));
            services.AddHostedService<Bot>();
            services.AddTransient<IStorageService, InternalStorageService>();
            services.AddTransient<Handlers>();
            services.AddHttpClient<IPrayerTimeClient, AladhanClient>
            (client => 
            {
                client.BaseAddress = new Uri("http://api.aladhan.com/v1");
            });


            // services.AddHttpClient<IPrayerTimeClient, PrayerTimeClient>
            // (client => 
            // {
            //     client.BaseAddress = new Uri("https://api.pray.zone/v2");
            // });
            // services.AddTransient<IStorageService, DbStorageService>();
        }
    }
}
