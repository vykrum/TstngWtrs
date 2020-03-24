using System;
using System.Linq;

namespace Tstngwtrs
{
    internal class Hxgn
    {
        internal Hxgn() { }
        private static (double, double)[] SvnCntrs(double x, double y)
        {
            double r = Math.Round(Math.Sqrt(2.0) / Math.Pow(3.0, 3.0 / 4.0),3);
            double a = Math.Round(Math.Sqrt(3.0) / 2.0 * r,3);
            double[] b = { 0.0, 0.0, 1.5 * r, 1.5 * r, 0.0, -1.5 * r, -1.5 * r };
            double[] c = {  0.0, 2.0 * a, a, -a, -2.0 * a, -a, a };
            var s = new (double, double)[7];
            for (var i = 0; i < 7; i++)
                s[i] = (Math.Round(b[i] + x,3), Math.Round(c[i] + y,3));
            return s;
        }

        private static (double, double)[] HxgCntrs(double x , double y, int ar, (double, double)[] occupied)
        {
            int i = 0, ct = 0;
            var hxg = (SvnCntrs(x, y).Except(occupied)).ToArray();
            
            while (ct < ar)
            {
                var a = SvnCntrs(hxg[i].Item1, hxg[i].Item2).Except(occupied).ToArray();
                var b = hxg.Except(occupied).Union(a).ToArray();
                ct = b.Length;
                hxg = b.ToArray();
                i ++;
            }
            return hxg.Take(ar).ToArray();
        }
    }
}

