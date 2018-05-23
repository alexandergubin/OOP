using System;
namespace Range
{
    class Test
    {
        public static void Main(string[] args)
        {
            Range range1 = new Range(-4.0, 0.0);
            Range range2 = new Range(-1.0, 2.0);


            Range newRange = range1.GetIntersection(range2);
            if (newRange != null)
            {
                Console.Write("Интервал пересечения: \n");
                newRange.Print();
            }

            double point = 1.0;
            if (newRange != null)
            {
                Console.Write("Точка {0:f6} находится в этом интервале? ", point);
                Console.WriteLine(newRange.IsInside(point));
            }

            Range[] diffRanges;
            diffRanges = range1.GetDifference(range2);
            Console.Write("Разность интервалов: \n");
            Range.Print(diffRanges);


            Range[] sumRanges;
            sumRanges = range1.Union(range2);
            Console.Write("Обьединение интервалов: \n");
            Range.Print(sumRanges);

            Console.ReadKey();
        }
    }
}
