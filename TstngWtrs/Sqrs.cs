using System;
using System.Linq;

namespace Tstngwtrs
{
    internal class Sqrs
    {
        internal Sqrs() { }
        private static (double, double)[] AdjCntrs(double x, double y)
        {
            double[] b = { 0.0, 0.0, 1.0, 1.0, 1.0, 0.0, -1.0, -1.0, -1.0 };
            double[] c = { 0.0, 1.0, 1.0, 0.0, -1.0, -1.0, -1.0, 0.0, 1.0 };
            var s = new (double, double)[9];
            for (var i = 0; i < 9; i++)
                s[i] = (Math.Round(b[i] + x, 3), Math.Round(c[i] + y, 3));
            return s;
        }

        private static (double, double)[] SqrCntrs(double x, double y, int ar, (double, double)[] occupied)
        {
            int i = 0, ct = 0;
            var sqr = (AdjCntrs(x, y).Except(occupied)).ToArray();

            while (ct < ar)
            {
                var a = AdjCntrs(sqr[i].Item1, sqr[i].Item2).Except(occupied).ToArray();
                var b = sqr.Except(occupied).Union(a).ToArray();
                ct = b.Length;
                sqr = b.ToArray();
                i ++;
            }
            return sqr.Take(ar).ToArray();
        }
    }
}


