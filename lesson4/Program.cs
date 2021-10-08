using System;

namespace lesson4
{
    class Program
    {
        static void Main()
        {
            int sum = 0;
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
