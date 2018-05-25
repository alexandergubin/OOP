namespace Shapes
{
    class Rectangle : IShape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
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
            Rectangle r = (Rectangle)obj;
            return (this.height == r.height) && (this.width == r.width);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + height.GetHashCode();
            hash = prime * hash + width.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return string.Format("Rectangle with heigh = {0:f}, width = {1:f} ", height, width);
        }

        public double GetArea()
        {
            return height * width;
        }

        public double GetHeight()
        {
            return height;
        }

        public double GetPerimeter()
        {
            return 2 * (height + width);
        }

        public double GetWidth()
        {
            return width;
        }
    }
}
