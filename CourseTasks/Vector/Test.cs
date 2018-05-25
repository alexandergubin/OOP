using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Test
    {
        public static void Main(string[] args)
        {
            double[] array1 = { 1.0, 2.0 };
            double[] array2 = { 1.0, 2.0 };
            Vector vector1 = new Vector(array1);
            Vector vector2 = new Vector(array2);

            Console.WriteLine("vector1 = " + vector1.ToString());

            vector1.Multiply(2);
            Console.WriteLine("vector1 * 2 = " + vector1.ToString());

            vector1.Add(vector2);
            Console.WriteLine("vector1 + vector2 = " + vector1);

            vector1.Sub(vector1);
            Console.WriteLine("vector1 - vector1 = " + vector1.ToString());

            vector1.Multiply(2);
            Console.WriteLine("vector1 * 2 = " + vector1.ToString());

            Console.WriteLine();
            Console.WriteLine("vector2 = " + vector2.ToString());

            vector1 = Vector.Add(vector2, vector2);
            Console.WriteLine("vector1 = Vector.Add(vector2, vector2) = " + vector1.ToString());

            double composition = Vector.ScalarMultiply(vector1, vector2);
            Console.WriteLine("Vector.ScalarMultiply(vector1, vector2) = " + composition);

            Console.ReadKey();
        }
    }
}
