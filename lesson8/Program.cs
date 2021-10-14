using System;
using System.Linq;
using System.Threading.Tasks;

namespace lesson8
{
    class Program
    {
        static async Task Main()
        {
            var counter = new Counter();
            counter.OnAlarmEventHandler += OnAlarm;
            await counter.Start();
        }

        private static void OnAlarm(object sender, CounterEventArgs e)
        {
            Console.WriteLine($"{e.Message}");
        }

        static void Main1(string[] args)
        {
            var sonlar = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var g = sonlar
                .OrderBy(i => i % 2)
                .OrderByDescending(i => i % 3)
                .Select(PrintIAndReturn)
                .ToArray();
        }

        private static int PrintIAndReturn(int i)
        {
            Console.Write($"{i} "); 
            return i;
        }
    }
}
