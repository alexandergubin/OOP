using System;

namespace Range
{
    class Range
    {
        private double from;
        private double to;

        public double From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }

        public double To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }

        public Range(double from, double to)
        {
            if (to > from)
            {
                this.From = from;
                this.to = to;
            }
            else
            {
                this.From = to;
                this.to = from;
            }
        }

        public double GetLength
        {
            get
            {
                return to - From;
            }
        }

        public bool IsInside(double input)
        {
            double epsilon = 1e-10;
            return (input - From >= -epsilon) && (to - input >= -epsilon);
        }

        public Range GetIntersection(Range range2)
        {
            if ((from > range2.to) || (to < range2.From))
            {
                return null;
            }
            else
            {
                double tmpFrom = from;
                double tmpTo = to;
                if (from < range2.From)
                {
                    tmpFrom = range2.From;
                }
                if (to > range2.to)
                {
                    tmpTo = range2.to;
                }
                return new Range(tmpFrom, tmpTo);
            }
        }

        public Range[] GetDifference(Range range2)
        {
            if ((from > range2.to) || (to < range2.From))
            {
                return new Range[] { this };
            }
            else
            {
                double f2 = range2.From;
                double t2 = range2.To;
                if ((from < f2) && ((to > f2) && (to <= t2)))
                {
                    return new Range[] { new Range(from, f2) };
                }
                else if ((f2 <= from) && ((t2 >= from) && (t2 <= to)))
                {
                    return new Range[] { new Range(t2, to) };
                }
                else if ((from < f2) && (to > t2))
                {
                    return new Range[] { new Range(from, f2), new Range(t2, to) };
                }
                return null;
            }

        }

        public Range[] Add(Range range2)
        {
            if ((from > range2.to) || (to < range2.From))
            {
                return new Range[] { this, range2 };
            }
            else
            {
                double tmpFrom = range2.From;
                double tmpTo = range2.to;
                if (from < range2.From)
                {
                    tmpFrom = from;
                }
                if (to > range2.to)
                {
                    tmpTo = to;
                }
                return new Range[] { new Range(tmpFrom, tmpTo) };
            }
        }

        public void Print()
        {
            Console.WriteLine("({0:f}; {1:f})", from, to);
        }

        public static void Print(Range[] array)
        {
            foreach (Range range in array)
            {
                Console.WriteLine("({0:f}; {1:f})", range.From, range.To);
            }
        }
    }

}

