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
                throw new ArgumentException("components.Length must be > 0");
            }
            components = new double[n];
        }

        public Vector(Vector other)
        {
            components = new double[other.components.Length];
            Array.Copy(other.components, components, other.components.Length);
        }

        public Vector(double[] array)
        {
            components = new double[array.Length];
            Array.Copy(array, components, array.Length);
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException("components.Length must be > 0");
            }
            components = new double[n];
            Array.Copy(array, components, array.Length);
        }

        public override string ToString()
        {
            String line = "{";
            for (int i = 0; i < components.Length; i++)
            {
                line += string.Format(" {0:f}", components[i]);
                if (i < components.Length - 1)
                {
                    line += ",";
                }
            }
            return line + " }";
        }

        public void Add(Vector other)
        {
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
                for (int i = 0; i < components.Length; i++)
                {
                    length += Math.Pow(components[i], 2.0);
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
            if (obj.GetHashCode() != this.GetHashCode() || v.components.Length != components.Length)
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
            hash = hash * prime + (ReferenceEquals(components, null) ? components.GetHashCode() : 0);
            hash = hash * prime + Size.GetHashCode();
            hash = hash * prime + Length.GetHashCode();
            return hash;
        }

        // STATIC METHODS

        public static Vector Add(Vector vector1, Vector vector2)
        {
            int maxLength = Math.Max(vector1.Size, vector2.Size);
            Vector resultVector = new Vector(maxLength);
            resultVector.Add(vector1);
            resultVector.Add(vector2);
            return resultVector;
        }

        public static Vector Sub(Vector vector1, Vector vector2)
        {
            int maxLength = Math.Max(vector1.Size, vector2.Size);
            Vector resultVector = new Vector(maxLength);
            resultVector.Add(vector1);
            resultVector.Sub(vector2);
            return resultVector;
        }

        public static double ScalarMultiply(Vector vector1, Vector vector2)
        {
            double result = 0;
            int i = 0;
            while (i < vector1.Size && i < vector2.Size)
            {
                result += vector1.components[i] * vector2.components[i];
                i++;
            }
            return result;
        }
    }
}
