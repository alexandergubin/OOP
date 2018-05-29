using System;

namespace ShapesPackage
{
    class Test
    {
        public static void Main(String[] args)
        {
            Circle circle1 = new Circle(2.0);
            Circle circle2 = new Circle(1.0);
            Rectangle rectangle = new Rectangle(2.0, 5.0);
            Triangle triangle1 = new Triangle(1.0, 0.0, 5.0, 5.0, 0.0, 20.0);
            Triangle triangle2 = new Triangle(1.0, 0.0, -5.0, -5.0, 0.0, 20.0);
            Square square = new Square(5.0);

            IShape[] shapes = { circle1, circle2, rectangle, triangle1, triangle2, square };

            IShape biggestShape = GetShapeWithMaxArea(shapes);
            Console.WriteLine(biggestShape.GetType());
            Console.WriteLine("ширина = {0:f}, высота = {1:f}", biggestShape.GetWidth(), biggestShape.GetHeight());
            Console.WriteLine("периметр = {0:f}, площадь = {1:f}", biggestShape.GetPerimeter(), biggestShape.GetArea());

            Console.WriteLine("Периметры фигур:");
            foreach (IShape e in shapes)
            {
                Console.WriteLine(e.GetPerimeter());
            }
            Console.WriteLine("Второй по величине периметр = " + GetShapeWithSecondPerimeter(shapes).GetPerimeter());

            Console.ReadKey();
        }

        public static IShape GetShapeWithMaxArea(IShape[] shapes)
        {
            if (shapes == null) { return null; }
            double maxArea = shapes[0].GetArea();
            IShape shapeWithMaxArea = shapes[0];

            foreach (IShape e in shapes)
            {
                if (e.GetArea() > maxArea)
                {
                    maxArea = e.GetArea();
                    shapeWithMaxArea = e;
                }
            }
            return shapeWithMaxArea;
        }

        public static IShape GetShapeWithSecondPerimeter(IShape[] shapes)
        {
            PerimeterComparer perimeterComparer = new PerimeterComparer();
            Array.Sort(shapes, perimeterComparer);
            return shapes[1];
        }

    }


}
