using System;

namespace VectorArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            ArithmeticVector v1 = new ArithmeticVector(new Point(1, 2), new Point(13, 5));
            ArithmeticVector v2 = new ArithmeticVector(new Point(9, 2), new Point(22, 2));

            Console.WriteLine($"Vector v1 is: {v1}");
            Console.WriteLine($"Vector v2 is: {v2}");

            Console.WriteLine($"Vector v1 + v2 is {v1 + v2}");
            Console.WriteLine($"Vector v1 - v2 is {v1 - v2}");
        }
    }
}
