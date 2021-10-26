using System;
using System.Threading.Tasks;
using bot.Entity;
using bot.HttpClients;
using bot.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

namespace bot
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; private set; }

        static Task Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .RunAsync();

        private static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices(Configure)
                .ConfigureAppConfiguration((context, configuration) => 
                {
                    configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    Configuration = configuration.Build();
                });

        private static void Configure(HostBuilderContext context, IServiceCollection services)
        {
            services.AddDbContext<BotDbContext>(options => 
            {
                options.UseSqlite(Configuration.GetConnectionString("BotConnection"));
            });

            services.AddMemoryCache();
            services.AddTransient<ICacheService, PrayerTimeCacheService>();
            services.AddSingleton<TelegramBotClient>(b => new TelegramBotClient(Configuration.GetSection("Bot:Token").Value));
            services.AddHostedService<Bot>();
            // services.AddTransient<IStorageService, InternalStorageService>();
            services.AddTransient<IStorageService, DbStorageService>();
            services.AddTransient<Handlers>();
            services.AddHttpClient<IPrayerTimeClient, AladhanClient>
            (client => 
            {
                client.BaseAddress = new Uri(Configuration.GetSection("Aladhan:BaseUrl").Value);
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
