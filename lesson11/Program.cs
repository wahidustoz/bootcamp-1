using System;
using lesson11.Extensions;

namespace lesson11
{
    class Program
    {

        static void Main(string[] args)
        {
            // var a = "Hello world";
            // Console.WriteLine($"{a.ToJson(true)}");
            // string text = a.ToJson().ToObject<string>();
            // Console.WriteLine($"{text}");

            var son = "abc";
            try
            {
                var a = int.Parse(son);
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.StackTrace.ToJson(true)}");
            }
        }
    }
}
