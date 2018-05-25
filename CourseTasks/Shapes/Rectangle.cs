namespace Shapes
{
    class Rectangle : IShape
    {
        private double heigh;
        private double width;

        public Rectangle(double heigh, double width)
        {
            this.heigh = heigh;
            this.width = width;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) { return true; }
            if (ReferenceEquals(obj, null) || (this.GetType() != obj.GetType()))
            {
                return false;
            }
            Rectangle r = (Rectangle)obj;
            return (this.heigh == r.heigh) && (this.width == r.width);
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
            return string.Format("Rectangle with heigh = {0:f}, width = {1:f} ", heigh, width);
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
