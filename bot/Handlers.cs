using System;
using System.Threading;
using System.Threading.Tasks;
using bot.Entity;
using bot.HttpClients;
using bot.Services;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace bot
{
    public class Handlers
    {
        private readonly ILogger<Handlers> _logger;
        private readonly IStorageService _storage;
        private readonly ICacheService _cache;

        public Handlers(
            ILogger<Handlers> logger, 
            IStorageService storage,
            ICacheService cache)
        {
            _logger = logger;
            _storage = storage;
            _cache = cache;
        }

        public Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken ctoken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException => $"Error occured with Telegram Client: {exception.Message}",
                _ => exception.Message
            };

            _logger.LogCritical(errorMessage);

            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken ctoken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageReceived(client, update.Message),
                UpdateType.EditedMessage => BotOnMessageEdited(client, update.EditedMessage),
                UpdateType.CallbackQuery => BotOnCallbackQueryReceived(client, update.CallbackQuery),
                UpdateType.InlineQuery => BotOnInlineQueryReceived(client, update.InlineQuery),
                UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(client, update.ChosenInlineResult),
                _ => UnknownUpdateHandlerAsync(client, update)
            };

            try
            {
                await handler;
            }
            catch(Exception e)
            {

            }
        }

        private async Task BotOnMessageEdited(ITelegramBotClient client, Message editedMessage)
        {
            throw new NotImplementedException();
        }

        private async Task UnknownUpdateHandlerAsync(ITelegramBotClient client, Update update)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnChosenInlineResultReceived(ITelegramBotClient client, ChosenInlineResult chosenInlineResult)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnInlineQueryReceived(ITelegramBotClient client, InlineQuery inlineQuery)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnCallbackQueryReceived(ITelegramBotClient client, CallbackQuery callbackQuery)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnMessageReceived(ITelegramBotClient client, Message message)
        {
            if(message.Type == MessageType.Location && message.Location != null)
            {
                var result = await _cache.GetOrUpdatePrayerTimeAsync(message.Chat.Id, message.Location.Longitude, message.Location.Latitude);
                var times = result.prayerTime;
                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: @$"
*Fajr*: {times.Fajr}
*Sunrise*: {times.Sunrise}
*Dhuhr*: {times.Dhuhr}
*Asr*: {times.Asr}
*Maghrib*: {times.Maghrib}
*Isha*: {times.Isha}
*Midnight*: {times.Midnight}
                    
*Method*: {times.CalculationMethod}
                    ",
                    parseMode: ParseMode.Markdown);
            }

            switch(message.Text)
            {
                case "/start": 
                    if(!await _storage.ExistsAsync(message.Chat.Id))
                    {
                        var user = new BotUser(
                            chatId: message.Chat.Id,
                            username: message.From.Username,
                            fullname: $"{message.From.FirstName} {message.From.LastName}",
                            longitude: 0,
                            latitude: 0,
                            address: string.Empty);

                        var result = await _storage.InsertUserAsync(user);

                        if(result.IsSuccess)
                        {
                            _logger.LogInformation($"New user added: {message.Chat.Id}");
                        }
                    }
                    else
                    {
                        _logger.LogInformation($"User exists");
                    }

                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        parseMode: ParseMode.Markdown,
                        text: "Share location?",
                        replyMarkup: MessageBuilder.LocationRequestButton());
                    await client.DeleteMessageAsync(
                        chatId: message.Chat.Id,
                        messageId: message.MessageId);
                    break;
            }
        }
    }
}