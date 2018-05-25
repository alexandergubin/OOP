﻿namespace Shapes
{
    class Square : IShape
    {
        private double heigh;
        private double width;

        public Square(double side)
        {
            heigh = side;
            width = side;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) { return true; }
            if (ReferenceEquals(obj, null) || (this.GetType() != obj.GetType()))
            {
                return false;
            }
            Square square = (Square)obj;
            return (this.heigh == square.heigh);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + heigh.GetHashCode();
            hash = prime * hash + width.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return string.Format("Square with side = {0:f}", heigh);
        }

        public double GetArea()
        {
            return heigh * width;
        }

        public double GetHeight()
        {
            return heigh;
        }

        public double GetPerimeter()
        {
            return 2 * (heigh + width);
        }

        public double GetWidth()
        {
            return width;
        }
    }
}
