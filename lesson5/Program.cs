using System;

namespace lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            // var shape = new Shape(); // error

            // var tri = new Triangle() { A = 5, B = 6 };
            // var rec = new Rectangle() { A = 5, B = 6 };

            // Console.WriteLine($"{tri.GetArea()} {rec.GetArea()}");

            // var eshmat = new Student();
            // var odam = new Person("odam", DateTime.Now);
            
            // Console.WriteLine($"{eshmat.Age}");

            var husan = new Student("Husan", new DateTime(1998, 11, 11), Guid.NewGuid(), 100);
            var asror = new Student("Asror", new DateTime(2004, 2, 23), Guid.NewGuid(), 100);
            Console.WriteLine($"{husan}");
            Console.WriteLine($"{asror}");
        }
    }
}
