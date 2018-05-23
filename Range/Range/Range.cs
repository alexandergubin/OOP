using System;

namespace Range
{
    class Range : ICloneable
    {

        public double From { get; set; }
        public double To { get; set; }

        public Range(double from, double to)
        {
            this.From = from;
            this.To = to;
        }

        public double Length
        {
            get
            {
                return To - From;
            }
        }

        public bool IsInside(double input)
        {
            return (input >= From) && (input <= To);
        }

        public Range GetIntersection(Range range2)
        {
            if ((From >= range2.To) || (To <= range2.From))
            {
                return null;
            }
            else
            {
                double tmpFrom = From;
                double tmpTo = To;
                if (From < range2.From)
                {
                    tmpFrom = range2.From;
                }
                if (To > range2.To)
                {
                    tmpTo = range2.To;
                }
                return new Range(tmpFrom, tmpTo);
            }
        }

        public Range[] GetDifference(Range range2)
        {
            if ((From >= range2.To) || (To <= range2.From))
            {
                return new Range[] { (Range)this.Clone() };
            }
            else
            {
                double f2 = range2.From;
                double t2 = range2.To;
                if ((From < f2) && ((To > f2) && (To <= t2)))
                {
                    return new Range[] { new Range(From, f2) };
                }
                else if ((f2 <= From) && ((t2 > From) && (t2 < To)))
                {
                    return new Range[] { new Range(t2, To) };
                }
                else if ((From < f2) && (To > t2))
                {
                    return new Range[] { new Range(From, f2), new Range(t2, To) };
                }
                return new Range[] { };
            }

        }

        public Range[] Union(Range range2)
        {
            if ((From > range2.To) || (To < range2.From))
            {
                return new Range[] { (Range)this.Clone(), (Range)range2.Clone() };
            }
            else
            {
                double tmpFrom = range2.From;
                double tmpTo = range2.To;
                if (From < range2.From)
                {
                    tmpFrom = From;
                }
                if (To > range2.To)
                {
                    tmpTo = To;
                }
                return new Range[] { new Range(tmpFrom, tmpTo) };
            }
        }

        public void Print()
        {
            Console.WriteLine("({0:f}; {1:f})", From, To);
        }

        public static void Print(Range[] array)
        {
            foreach (Range range in array)
            {
                Console.WriteLine("({0:f}; {1:f})", range.From, range.To);
            }
        }

        public object Clone()
        {
            return new Range(this.From, this.To);
        }
    }

}

