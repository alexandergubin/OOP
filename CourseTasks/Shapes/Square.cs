using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
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
