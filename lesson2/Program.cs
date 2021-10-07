using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson2
{
    class Program
    {
        static void Main()
        {
            // int n = int.Parse(Console.ReadLine()) + 1;

            // int sum = 0;
            // while(n-->0)
            // {
            //     sum+=n;
            // }
            // Console.WriteLine($"{sum}");

            // int n = int.Parse(Console.ReadLine());
            // int sum = 0;

            // for(int i = 0; i <= n; i++)
            // {
            //     sum+=i;
            // }
            // Console.WriteLine($"{sum}");

            // var sonlar = new int[]{ 1, 2, 3, 4, 5, 6, 7 };
            // foreach(int son in sonlar)
            // {
            //     Console.WriteLine($"{son}");
            // }

            var sonlar = Enumerable.Range(1, 7).ToList();
            foreach(var son in sonlar)
            {
                Console.WriteLine($"{son}");
            }
        }

        static void Main_Conditionals(string[] args)
        {
            // int? a = null;
            // string hechnima = string.Empty;

            // if(hechnima is null)
            // {
            //     System.Console.WriteLine("Hechnima null ga teng");
            // }
            // else
            // {
            //     System.Console.WriteLine($"Hechnima {hechnima} ga teng");
            // }

            int son = int.Parse(Console.ReadLine());
            
            // switch(son)
            // {
            //     case 1: Console.WriteLine("Siz bir kiritdingiz!"); break;
            //     case 2: Console.WriteLine("Siz ikki kiritdingiz!"); break;
            //     case 3: Console.WriteLine("Siz uch kiritdingiz!"); break;
            //     case 4: Console.WriteLine("Siz to'rt kiritdingiz!"); break;
            //     default: Console.WriteLine($"Siz {son} kiritdingiz!"); break;
            // }

            // var message = son switch
            // {
            //     1 => "Siz bir kiritdingiz!",
            //     2 => "Siz ikki kiritdingiz!",
            //     3 => "Siz uch kiritdingiz!",
            //     4 => "Siz four kiritdingiz!",
            //     _ => $"Siz {son} kiritdingiz!",
            // };

            var message = son switch
            {
                > 0 => "Siz musbat son kiritdingiz!",
                (< 0) => "Siz manfiy son kiritdingiz!", // aslida skopka shart emas ekan
        
                _ => "Siz nol kiritdingiz!",
            };

            Console.WriteLine(message);
        }
    }
}
