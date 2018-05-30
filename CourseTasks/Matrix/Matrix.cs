using System;
using System.Text;
using VectorPackage;

namespace MatrixPackage
{
    class Matrix
    {
        private Vector[] vectors;

        public Matrix(int n, int m)
        {
            if ((m <= 0) || (n <= 0))
            {
                throw new ArgumentException("размер матрицы должен быть больше 0");
            }
            vectors = new Vector[n];
            for (int i = 0; i < n; i++)
            {
                vectors[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            if (ReferenceEquals(matrix, null))
            {
                throw new ArgumentNullException();
            }
            vectors = new Vector[matrix.vectors.Length];
            for (int i = 0; i < matrix.vectors.Length; ++i)
            {
                vectors[i] = new Vector(matrix.vectors[i]);
            }
        }

        public Matrix(double[,] array)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException();
            }
            if ((array.GetLength(0) == 0) || (array.GetLength(0) == 0))
            {
                throw new ArgumentException("размер матрицы должен быть больше 0");
            }
            vectors = new Vector[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                vectors[i] = new Vector(array.GetLength(1));
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    vectors[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] array)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException();
            }
            int maxLength = 0;
            foreach (Vector e in array)
            {
                if (e.Size > maxLength)
                {
                    maxLength = e.Size;
                }
            }
            vectors = new Vector[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                vectors[i] = new Vector(maxLength);
                vectors[i].Add(array[i]);
            }
        }

        public int Rows
        {
            get
            {
                return vectors.Length;
            }
        }

        public int Columns
        {
            get
            {
                return vectors[0].Size;
            }
        }

        public Vector GetRow(int index)
        {
            if ((index < 0) || (index > Columns - 1))
            {
                throw new ArgumentException("некорректный индекс в GetRow(int index)");
            }
            return vectors[index].Clone();
        }

        public Matrix SetRow(int rowIndex, Vector vector)
        {
            if (Columns != vector.Size)
            {
                throw new ArgumentException("длина вектора не равно количеству столбцов матрицы");
            }
            for (int i = 0; i < Columns; i++)
            {
                vectors[rowIndex].SetComponent(i, vector.GetComponent(i));
            }
            return this;
        }

        public Vector GetColumn(int index)
        {
            if ((index < 0) || (index > Rows - 1))
            {
                throw new ArgumentException("некорректный индекс в GetColumn(int index)");
            }
            Vector result = new Vector(vectors.Length);
            for (int i = 0; i < vectors.Length; i++)
            {
                result.SetComponent(i, vectors[i].GetComponent(index));
            }
            return result;
        }


        public Matrix Transpose()
        {
            if (Rows != Columns)
            {
                throw new ArgumentException("матрица не квадратная");
            }
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    double tmp = vectors[i].GetComponent(j);
                    vectors[i].SetComponent(j, vectors[j].GetComponent(i));
                    vectors[j].SetComponent(i, tmp);
                }
            }
            return this;
        }

        public Matrix MultiplyOnScalar(double k)
        {
            foreach (Vector e in vectors)
            {
                e.Multiply(k);
            }
            return this;
        }

        public double GetValue(int i, int j)
        {
            return vectors[i].GetComponent(j);
        }

        public void SetValue(int i, int j, double value)
        {
            vectors[i].SetComponent(j, value);
        }

        public double GetDeterminant()
        {
            if (Rows != Columns)
            {
                throw new ArgumentException("матрица не квадратная");
            }
            return CalculateDeterminant(this);
        }

        private double CalculateDeterminant(Matrix minor)
        {
            double determinant = 0;
            if (minor.Rows == 1)
            {
                determinant = minor.vectors[0].GetComponent(0);
            }
            else
            {
                Matrix tmpMinor = new Matrix(minor.Rows - 1, minor.Columns - 1);
                for (int k = 0; k < minor.Columns; k++)
                {
                    for (int i = 1; i < minor.Rows; i++)
                    {
                        for (int j = 0; j < minor.Columns; j++)
                        {
                            if (j < k)
                            {
                                tmpMinor.SetValue(i - 1, j, minor.GetValue(i, j));
                            }
                            else if (j > k)
                            {
                                tmpMinor.SetValue(i - 1, j - 1, minor.GetValue(i, j));
                            }
                        }
                    }
                    determinant += Math.Pow((double)-1, (k + 2)) * CalculateDeterminant(tmpMinor) * minor.GetValue(0, k);
                }
            }
            return determinant;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("{");
            for (int i = 0; i < vectors.Length; i++)
            {
                sb.Append(vectors[i].ToString());
                if (i < vectors.Length - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("}");
            return sb.ToString();
        }


        public Matrix Add(Matrix other)
        {
            if (Rows != other.Rows || Columns != other.Columns)
            {
                throw new ArgumentException("размеры матриц не совпадают");
            }
            for (int i = 0; i < Rows; i++)
            {
                vectors[i].Add(other.vectors[i]);
            }
            return this;
        }

        public Matrix Sub(Matrix other)
        {
            if (Rows != other.Rows || Columns != other.Columns)
            {
                throw new ArgumentException("размеры матриц не совпадают");
            }
            for (int i = 0; i < Rows; i++)
            {
                vectors[i].Sub(other.vectors[i]);
            }
            return this;
        }

        public Matrix MultiplyOnVector(Vector vector)
        {
            if (vector.Size != Rows)
            {
                throw new ArgumentException("количество элементов вектора должно быть равно количество строк матрицы");
            }
            Matrix result = new Matrix(this);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    SetValue(i, j, GetValue(i, j) * vector.GetComponent(i));
                }
            }
            return result;
        }
        //        STATIC METHODS

        public static void Add(Matrix matrix1, Matrix matrix2)
        {
            matrix1.Add(matrix2);
        }

        public static void Sub(Matrix matrix1, Matrix matrix2)
        {
            matrix1.Sub(matrix2);
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new ArgumentException("матрицы разного размера");
            }
            Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    result.SetValue(i, j, Vector.ScalarMultiply(matrix1.GetRow(i), matrix2.GetColumn(j)));
                }
            }
            return result;
        }
    }
}

