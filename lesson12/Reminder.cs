using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace lesson12
{
    public class Reminder : BackgroundService
    {
        private readonly IMessageWriter _writer;

        public Reminder(MessageWriter writer)
        {
            _writer = writer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                _writer.Write($"The time is: {DateTimeOffset.Now}");
                await Task.Delay(1000);
            }
        }
    }
}