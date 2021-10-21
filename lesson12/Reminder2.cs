using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace lesson12
{
    public class Reminder2 : BackgroundService
    {
        private readonly IMessageWriter _writer;

        public Reminder2(MessageWriter writer)
        {
            _writer = writer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                _writer.Write($"{nameof(Reminder2)}");
                await Task.Delay(1000);
            }
        }
    }
}