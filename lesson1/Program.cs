using System;
using System.Linq;
using lesson1.Solutions;

namespace lesson1
{
    class Program
    {
        static void Main()
        {
            var lab2 = new Lab2();
            lab2.Problem1();
        }

        static void Main1()
        {
            //string input = Console.ReadLine();
            //Console.WriteLine("You entered: " + input);

            var inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            // foreach(string input in inputs)
            // {
            //     // int son = int.Parse(input);
            //     // Console.WriteLine(son * 10);

            //     int son = 0;
            //     bool parsed = int.TryParse(input, out son);
            //     if(parsed)
            //     {
            //         System.Console.WriteLine(son);
            //     }
            //     else
            //     {
            //         System.Console.WriteLine("Not son");
            //     }
            // }

            var ints = inputs.Select(i =>
            {
                int son = int.Parse(i);
                Console.WriteLine(son);
                return son;
            }).ToList();
        }
    }
}
