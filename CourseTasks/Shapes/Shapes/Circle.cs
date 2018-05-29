using System;

namespace ShapesPackage
{
    class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || (this.GetType() != obj.GetType()))
            {
                return false;
            }
            Circle c = (Circle)obj;
            return this.radius == c.radius;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + radius.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return string.Format("Circle with radius = {0:f}", radius);
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public double GetHeight()
        {
            return 2 * radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public double GetWidth()
        {
            return 2 * radius;
        }
    }
}
