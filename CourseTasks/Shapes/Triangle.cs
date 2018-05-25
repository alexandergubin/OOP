using System;

namespace Shapes
{
    class Triangle : IShape
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double x3;
        private double y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        private static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) { return true; }
            if (ReferenceEquals(obj, null) || (this.GetType() != obj.GetType()))
            {
                return false;
            }
            Triangle r = (Triangle)obj;
            double epsilon = 1e-15;
            return Math.Abs(GetSideLength(x1, y1, x2, y2) - GetSideLength(r.x1, r.y1, r.x2, r.y2)) < epsilon &&
                    Math.Abs(GetSideLength(x1, y1, x3, y3) - GetSideLength(r.x1, r.y1, r.x3, r.y3)) < epsilon &&
                     Math.Abs(GetSideLength(x3, y3, x2, y2) - GetSideLength(r.x3, r.y3, r.x2, r.y2)) < epsilon;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + x1.GetHashCode();
            hash = prime * hash + y1.GetHashCode();
            hash = prime * hash + x2.GetHashCode();
            hash = prime * hash + y2.GetHashCode();
            hash = prime * hash + x3.GetHashCode();
            hash = prime * hash + y3.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return string.Format("Rectangle with coordinates ({0:f}, {1:f}), ({2:f}, {3:f}), ({4:f}, {5:f}) ",
                x1, y1, x2, y2, x3, y3);
        }

        public double GetArea()
        {
            return Math.Abs(0.5 * ((x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3)));
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(y1, y2), y3) - Math.Min(Math.Min(y1, y2), y3);
        }

        public double GetPerimeter()
        {
            double side1 = GetSideLength(x1, y1, x2, y2);
            double side2 = GetSideLength(x3, y3, x2, y2);
            double side3 = GetSideLength(x1, y1, x3, y3);
            return side1 + side2 + side3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(x1, x2), x3) - Math.Min(Math.Min(x1, x2), x3);
        }
    }
}
