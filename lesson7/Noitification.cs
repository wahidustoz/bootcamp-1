using System;
using System.Threading;
using System.Threading.Tasks;

namespace lesson7
{
    public class Noitification
    {
        public delegate void OnMessageEvent(string message);

        public OnMessageEvent OnMessage;

        public Noitification()
        {
            
        }

        public void StartListening()
        {
            int i = 0;
            while(true)
            {
                var wait = Task.Delay(1000);

                OnMessage?.Invoke($"Message #{++i}");

                wait.Wait();
            }
        }
    }
}