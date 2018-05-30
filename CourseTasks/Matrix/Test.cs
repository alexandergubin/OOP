using System;
using VectorPackage;

namespace MatrixPackage
{
    class Test
    {
        public static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(new double[,]{
                {1.0, -2.0, 3.0},
                {4.0, 0.0, 6.0},
                {-7.0, 8.0, 9.0}
            });

            Matrix matrix2 = new Matrix(new double[,]{
                {1.0, -2.0, 0},
                {4.0, 0.0, 0},
                {-7.0, 8.0, 0}
            });

            Matrix matrix3 = new Matrix(new double[,]{
                {0.0, 0.0, 1.0},
                {0.0, 1.0, 0.0},
                {1.0, 0.0, 0.0}
            });

            Vector vector = new Vector(new double[] { 5.0, 5.0, 5.0 });

            Console.WriteLine(matrix3.SetRow(0, vector));
            Console.WriteLine();

            Console.WriteLine("matrix1.GetDeterminant()");
            Console.WriteLine(matrix1.GetDeterminant());
            Console.WriteLine();

            Console.WriteLine("matrix2.Add(matrix1)");
            Console.WriteLine(matrix2.Add(matrix1).ToString());
            Console.WriteLine();

            Console.WriteLine("matrix2.Transpose()");
            Console.WriteLine(matrix2.Transpose().ToString());
            Console.WriteLine();

            Console.WriteLine("умножение матриц matrix1 и matrix3:");
            Matrix result = Matrix.Multiply(matrix1, matrix3);

            Console.WriteLine(result.ToString());

            Console.ReadKey();
        }
    }
}
