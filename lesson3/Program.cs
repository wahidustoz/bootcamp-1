using System;
using System.Linq;
using System.Collections.Generic;

namespace lesson3
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> sonlar = new Dictionary<string, int>();
            Dictionary<string, int> sonlar1 = new();
            var sonlar2 = new Dictionary<string, int>();

            sonlar.Add("one", 1);
            sonlar.Add("two", 2);
            sonlar.Add("three", 3);
        }

        static void Main_sample()
        {
            var n = int.Parse(Console.ReadLine());

            var qatorlar = new int[n][];

            for (int i = 0; i < n; i++)
            {
                qatorlar[i] = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            }

            foreach(var qator in qatorlar)
            {
                Console.WriteLine(qator.Max());
            }
        }

        static void Main_2()
        {
            //int[] sonlar = new int[10];
            //var sonlar1 = new int[10];

            //var sonlar2 = new int[] {1, 2, 3};

            //// multi-D
            //int[][] sonlarlar = new int[5][];
            //sonlarlar[0] = new int[10];
            //sonlarlar[1] = new int[1];
            //sonlarlar[2] = new int[11];
            //sonlarlar[3] = new int[15];
            //sonlarlar[4] = new int[150];


            //foreach(var qator in sonlarlar)
            //{
            //    Console.WriteLine($"{qator.Count()}");
            //}

            var a = new int[3, 2];
            int[,] b = new int[4, 5];

            int[,] c = 
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
        }

        static void Main_list()
        {
            List<int> sonlar = new List<int>();
            var sonlar1 = new List<int>();
            List<int> sonlar2 = new();

            List<int> sonlar3 = new List<int>() { 1, 2, 3 };
            List<int> sonlar4 = new () { 1, 2, 3 };
            var sonlar5 = new List<int>() { 1, 2, 3 };

            sonlar.Add(1);
            sonlar.AddRange(new List<int> { 1, 2, 3, 4 });

            Console.WriteLine($"{sonlar[2]}");

            Console.WriteLine($"{sonlar3.Count}");
        }

        static void Main_12313(string[] args)
        {
            var numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(i => int.Parse(i))
            .ToList();

            int sum = 0;

            foreach (var son in numbers)
            {
                if(son <= 0) break;

                sum += son;
            }

            Console.WriteLine($"{sum}");
        }
    }
}
