using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace bot
{
    public class Bot : BackgroundService
    {
        private readonly TelegramBotClient _botClient;

        public readonly ILogger<Bot> _logger;

        public Bot(TelegramBotClient client, ILogger<Bot> logger)
        {
            _botClient = client;
            _logger = logger;
            _botClient.OnMessage += HandleMessageReceived;
            _botClient.StartReceiving();
        }

        private void HandleMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            _logger.LogInformation($"{message.From.FirstName} @{message.From.Username} sent a message: \n{message.Text}");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var me = await _botClient.GetMeAsync();
            _logger.LogInformation($"{me.Username} has connected successfully!");
        }
    }
}