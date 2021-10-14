using System;
using System.Threading.Tasks;

namespace lesson8
{
    public class CounterEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    public class Counter
    {
        private int time = 0;
        public async Task Start()
        {
            while(true)
            {
                time++;
                await Task.Delay(1000);
                if(time % 5 == 0)
                {
                    OnAlarm(time);
                }
            }
        }

        public delegate void CounterEventHandler(object sender, CounterEventArgs e);
        public event CounterEventHandler OnAlarmEventHandler;

        protected virtual void OnAlarm(int time)
        {
            OnAlarmEventHandler?.Invoke(this, new CounterEventArgs() 
            { 
                Message = $"{time} seconds passed!"
            });
        }
    }
}