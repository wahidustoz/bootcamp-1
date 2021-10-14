using System;
using System.Threading.Tasks;

namespace lesson7
{
    class Program
    {
        public static int Add(float a, float b)
        {
            Console.WriteLine($"Chaqirdi");
            
            return (int)(a + b);
        }

        public static void PrintHello(string text)
        {
            Console.WriteLine($"{text}");
        }

        // public delegate void PrintDelegate(string text);

        static void Main()
        {
            // PrintDelegate print = PrintHello;
            Action<string> print = PrintHello;
            // Action<int, int> add = Add; // error: return type int
            Func<float, float, int> add = Add;

            print("Hello Asror");
        }

        static async Task Main2()
        {
            var converter = new VideoConverter();
            converter.OnVideoConverted += VideoConverted;
            await converter.Convert("Spiderman: Home coming.");
        }

        private static void VideoConverted(string message)
        {
            Console.WriteLine($"{message}");
        }

        static void Main1(string[] args)
        {
            var noti = new Noitification();
            // noti.OnMessage += MessageReceived;

            noti.StartListening();

            Console.ReadKey();
        }

        private static void MessageReceived(string message)
        {
            Console.WriteLine($"Abubakr");
            Console.WriteLine($"{message}");
        }
    }
}
