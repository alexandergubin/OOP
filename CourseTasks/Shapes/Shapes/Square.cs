namespace ShapesPackage
{
    class Square : IShape
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
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
            Square square = (Square)obj;
            return (this.side == square.side);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + side.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return string.Format("Square with side = {0:f}", side);
        }

        public double GetArea()
        {
            return side * side;
        }

        public double GetHeight()
        {
            return side;
        }

        public double GetPerimeter()
        {
            return 4 * side;
        }

        public double GetWidth()
        {
            return side;
        }
    }
}
