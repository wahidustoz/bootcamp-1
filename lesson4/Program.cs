using System;
using System.Linq;

namespace lesson4
{
    public class NameNullException : ArgumentNullException
    {
        public NameNullException()
            : this("Name", "Name cannot be null or whitespaces")
        { }

        public NameNullException(string parameterName, string message)
            : base(parameterName, message)
        { }


    }
    
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Take(n)
                            .Select(son => int.Parse(son))
                            .ToList();

            var sum = numbers.Sum();
            var average = (double)sum / numbers.Count();

            Console.WriteLine($"{sum} {average}");

            var _ = numbers.Select(x => 
            {
                if(x >= average)
                {
                    Console.Write($"{x} ");
                }
                return x;
            }).ToList();
        }

        static void Main_list()
        {
            var text = Console.ReadLine().Substring(0, 7);
            var charList = text.Select(c => c).ToList();

            int count = 0;
            for(int i = 1; i < text.Length - 1; i++)
            {
                if(charList[i] == 'a' 
                    && charList[i - 1] == 'c' 
                    && charList[i + 1] == 't')
                {
                    count++;
                }
            }
            Console.WriteLine(count);

        }

        static void Main_array()
        {
            var text = Console.ReadLine().Substring(0, 7);
            var textArray = text.ToCharArray();

            int count = 0;

            for(int i = 1; i < text.Length - 1; i++)
            {
                if(textArray[i] == 'a' 
                    && textArray[i - 1] == 'c' 
                    && textArray[i + 1] == 't')
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        static void Main_string()
        {
            var text = Console.ReadLine().Substring(0, 7);

            int count = 0;
            while(text.IndexOf("cat") >= 0)
            {
                count++;
                text = text.Remove(text.IndexOf("cat"), "cat".Length);
            }

            Console.WriteLine(count);
        }


        static void Main_1()
        {
            try
            {
                PrintName("Shaxzod");
                PrintName(null);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Xato: {e.Message}");
            }
        }

        static void PrintName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new NameNullException(nameof(name), "Name cannot be null or whitespace!");
            }
            
            Console.WriteLine($"Ism is {name}");
        }

        static void Main_masala()
        {
            int x;
            while(!TryGetInt(out x));

            Console.WriteLine($"Sum: {x * x}");
        }

        static bool TryGetInt(out int x)
        {
            x = 0;
            try
            {
                x = int.Parse(Console.ReadLine());
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
                return false;
            }
        }

        static void Main_try(string[] args)
        {
            int x = 5;
            int y = 0;
            try
            {
                foo(x, y);
            }
            catch(DivideByZeroException xato)
            {
                Console.WriteLine($"Division by ZERO occured: {xato.Message}");
            }
            catch(Exception xato)
            {
                Console.WriteLine($"An error occured: {xato.Message}");
            }
        }

        static void foo(int x, int y)
        {
            Console.WriteLine($"{x / y}");
        }
    }
}
