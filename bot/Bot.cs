using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using bot.HttpClients;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace bot
{
    public class Bot : BackgroundService
    {
        private readonly TelegramBotClient _botClient;

        public readonly ILogger<Bot> _logger;
        private readonly IPrayerTimeClient _prayerTimeClient;

        public Bot(TelegramBotClient client, ILogger<Bot> logger, Handlers handlers, IPrayerTimeClient prayerTimeClient)
        {
            _botClient = client;
            _logger = logger;
            _prayerTimeClient = prayerTimeClient;
            _botClient.StartReceiving(new DefaultUpdateHandler(handlers.HandleUpdateAsync, handlers.HandleErrorAsync), new CancellationToken());
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var me = await _botClient.GetMeAsync();
            _logger.LogInformation($"{me.Username} has connected successfully!");
            // var prayerTime = await _prayerTimeClient.GetPrayerTimeAsync(69.2401, 41.2995);

            // _logger.LogInformation(JsonSerializer.Serialize(prayerTime.prayerTime));
        }
    }
}