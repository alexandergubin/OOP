using System;
using System.Text;
using VectorPackage;

namespace MatrixPackage
{
    class Matrix
    {
        private Vector[] vectors;
        private double determinant;

        public Matrix(int n, int m)
        {
            if (m <= 0)
            {
                throw new ArgumentException("длина вектора должна быть больше 0");

            }
            vectors = new Vector[n];
            for (int i = 0; i < n; i++)
            {
                vectors[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            vectors = new Vector[matrix.vectors.Length];
            for (int i = 0; i < matrix.vectors.Length; ++i)
            {
                vectors[i] = new Vector(matrix.vectors[i]);
            }
        }

        public Matrix(double[,] array)
        {
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
            vectors = new Vector[array.Length];
            vectors = (Vector[])array.Clone();
        }

        public int GetRows()
        {
            return vectors.Length;
        }

        public int GetColumns()
        {
            return vectors[0].Size;
        }

        public Vector GetVectorRow(int index)
        {
            return vectors[index];
        }

        public Vector GetVectorColumn(int index)
        {
            Vector result = new Vector(vectors.Length);
            for (int i = 0; i < vectors.Length; i++)
            {
                result.SetComponent(i, vectors[i].GetComponent(index));
            }
            return result;
        }


        public Matrix Transpose()
        {
            int rowsCount = vectors.Length;
            int columnsCount = vectors[0].Size;
            Matrix result = new Matrix(columnsCount, rowsCount);
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    result.vectors[j].SetComponent(i, vectors[i].GetComponent(j));
                }
            }
            return result;
        }

        public Matrix MultiplyOnScalar(double k)
        {
            for (int i = 0; i < vectors.Length; i++)
            {
                vectors[i].Multiply(k);
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
            CalculateDeterminant(this, 1);
            return determinant;
        }

        private void CalculateDeterminant(Matrix minor, double parentElem)
        {
            if (minor.GetRows() == 1)
            {
                determinant += parentElem * minor.vectors[0].GetComponent(0);
            }
            else
            {
                Matrix tmpMinor = new Matrix(minor.GetRows() - 1, minor.GetColumns() - 1);
                for (int k = 0; k < minor.GetColumns(); k++)
                {
                    for (int i = 1; i < minor.GetRows(); i++)
                    {
                        for (int j = 0; j < minor.GetColumns(); j++)
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
                    double newParent = Math.Pow(-1, k + 2) * minor.GetValue(0, k) * parentElem;
                    CalculateDeterminant(tmpMinor, newParent);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("{");
            for (int i = 0; i < vectors.Length; i++)
            {
                sb.Append("{");
                for (int j = 0; j < vectors[0].Size; j++)
                {
                    sb.AppendFormat(" {0:f}", GetValue(i, j));
                    if (j < vectors[0].Size - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append(" }");
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
            if (vectors.Length < other.vectors.Length)
            {
                Array.Resize(ref vectors, other.vectors.Length);
            }
            for (int i = 0; i < other.vectors.Length; i++)
            {
                vectors[i].Add(other.vectors[i]);
            }
            return this;
        }

        public Matrix Sub(Matrix other)
        {
            if (vectors.Length < other.vectors.Length)
            {
                Array.Resize(ref vectors, other.vectors.Length);
            }
            for (int i = 0; i < other.vectors.Length; i++)
            {
                vectors[i].Sub(other.vectors[i]);
            }
            return this;
        }

        public Matrix MultiplyOnVector(Vector vector)
        {
            if (vector.Size != GetRows())
            {
                throw new ArgumentException("количество элементов вектора должно быть равно количество строк матрицы");
            }

            for (int i = 0; i < vector.Size; i++)
            {
                for (int j = 0; j < GetColumns(); j++)
                {
                    SetValue(i, j, GetValue(i, j) * vector.GetComponent(i));
                }
            }
            return this;
        }
        //        STATIC METHODS

        public static void Add(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.vectors.Length < matrix2.vectors.Length)
            {
                Array.Resize(ref matrix1.vectors, matrix2.vectors.Length);
            }
            for (int i = 0; i < matrix2.vectors.Length; i++)
            {
                matrix1.vectors[i].Add(matrix2.vectors[i]);
            }
        }

        public static void Sub(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.vectors.Length < matrix2.vectors.Length)
            {
                Array.Resize(ref matrix1.vectors, matrix2.vectors.Length);
            }
            for (int i = 0; i < matrix2.vectors.Length; i++)
            {
                matrix1.vectors[i].Sub(matrix2.vectors[i]);
            }
        }

        public static void Multiply(Matrix result, Matrix matrix1, Matrix matrix2)
        {
            for (int i = 0; i < matrix1.GetRows(); i++)
            {
                for (int j = 0; j < matrix2.GetColumns(); j++)
                {
                    result.SetValue(i, j, Vector.ScalarMultiply(matrix1.GetVectorRow(i), matrix2.GetVectorColumn(j)));
                }
            }
        }
    }
}

