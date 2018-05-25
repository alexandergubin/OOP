using System;

namespace Vector
{
    class Vector
    {
        private double[] components;

        public int Size
        {
            get
            {
                return components.Length;
            }
        }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("длина вектора должна быть больше 0");
            }
            components = new double[n];
        }

        public Vector(Vector other)
        {
            if (ReferenceEquals(other, null))
            {
                throw new ArgumentNullException("в параметры конструктора передан null");
            }
            components = new double[other.components.Length];
            Array.Copy(other.components, components, other.components.Length);
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("длина вектора должна быть больше 0");
            }
            components = new double[array.Length];
            Array.Copy(array, components, array.Length);
        }

        public Vector(int n, double[] array)
        {
            if (ReferenceEquals(array, null))
            {
                throw new NullReferenceException("массив равен null");
            }
            if (n <= 0)
            {
                throw new ArgumentException("размерность вектора не может быть меньше длинны передаваемого массива");
            }
            components = new double[n];
            Array.Copy(array, components, (n < array.Length) ? n : array.Length);
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("{");
            for (int i = 0; i < components.Length; i++)
            {
                sb.AppendFormat(" {0:f}", components[i]);
                if (i < components.Length - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append(" }");
            return sb.ToString();
        }

        public void Add(Vector other)
        {
            if (Size < other.Size)
            {
                double[] newComponents = new double[other.Size];
                Array.Copy(components, newComponents, components.Length);
                components = newComponents;
            }
            for (int i = 0; i < components.Length; i++)
            {
                if (i < other.components.Length)
                {
                    components[i] += other.components[i];
                }
            }
        }

        public void Sub(Vector other)
        {
            if (Size < other.Size)
            {
                double[] newComponents = new double[other.Size];
                Array.Copy(components, newComponents, components.Length);
                components = newComponents;
            }
            for (int i = 0; i < components.Length; i++)
            {
                if (i < other.components.Length)
                {
                    components[i] -= other.components[i];
                }
            }
        }

        public void Multiply(double scalar)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= scalar;
            }
        }

        public void TurnBack()
        {
            this.Multiply(-1.0);
        }

        public double Length
        {
            get
            {
                double length = 0;
                foreach (double e in components)
                {
                    length += Math.Pow(e, 2.0);
                }
                return Math.Sqrt(length);
            }
        }

        public double GetComponent(int index)
        {
            return components[index];
        }

        public void SetComponent(int index, double value)
        {
            components[index] = value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if ((ReferenceEquals(obj, null)) || (obj.GetType() != this.GetType()))
            {
                return false;
            }
            Vector v = (Vector)obj;
            if (v.components.Length != components.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < components.Length; i++)
                {
                    if (components[i] != v.components[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            if (!ReferenceEquals(components, null))
            {
                foreach (double e in components)
                {
                    hash = hash * prime + e.GetHashCode();
                }
            }
            hash = hash * prime + Size.GetHashCode();
            hash = hash * prime + Length.GetHashCode();
            return hash;
        }

        // STATIC METHODS

        public static Vector Add(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1);
            resultVector.Add(vector2);
            return resultVector;
        }

        public static Vector Sub(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1);
            resultVector.Sub(vector2);
            return resultVector;
        }

        public static double ScalarMultiply(Vector vector1, Vector vector2)
        {
            double result = 0;
            int border = Math.Min(vector1.Size, vector2.Size);
            for (int i = 0; i < border; i++)
            {
                result += vector1.components[i] * vector2.components[i];
            }
            return result;
        }
    }
}
