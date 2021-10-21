using System.Collections.Generic;
using System;
using System.Linq;
using lesson11.Extensions;

namespace lesson11
{
    class Program
    {

        static void Main()
        {
            var sonlar = new int[] {1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,7,8,9 };
            var uchlar = sonlar
                .Select((x, y) => new KeyValuePair<int, int>(y, x))
                .ToJson(true);

            // foreach(var son in uchlar)
            // {
            //     Console.WriteLine($"{son}");
            // }
            Console.WriteLine($"{uchlar}");
        }

        static void Main123123(string[] args)
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
