using System;
using System.Collections.Generic;
using System.Linq;

namespace Tstngwtrs
{
    public class Shapes
    {
        internal Shapes() { }
        public static (double, double)[] AdjCntrs(double x, double y, int shape)
        {
            //Cell with similar cells on all edges
            switch (shape)
            {
                default:
                    double[] sqx = { 0.0, 0.0, 1.0, 1.0, 1.0, 0.0, -1.0, -1.0, -1.0 };
                    double[] sqy = { 0.0, 1.0, 1.0, 0.0, -1.0, -1.0, -1.0, 0.0, 1.0 };
                    var s = new (double, double)[9];
                    for (var i = 0; i < 9; i++)
                        s[i] = (Math.Round(sqx[i] + x, 3), Math.Round(sqy[i] + y, 3));
                    return s;

                case 1:
                    double r = Math.Round(Math.Sqrt(2.0) / Math.Pow(3.0, 3.0 / 4.0), 3);
                    double a = Math.Round(Math.Sqrt(3.0) / 2.0 * r, 3);
                    double[] hxx = { 0.0, 0.0, 1.5 * r, 1.5 * r, 0.0, -1.5 * r, -1.5 * r };
                    double[] hxy = { 0.0, 2.0 * a, a, -a, -2.0 * a, -a, a };
                    s = new (double, double)[7];
                    for (var i = 0; i < 7; i++)
                        s[i] = (Math.Round(hxx[i] + x, 3), Math.Round(hxy[i] + y, 3));                    
                    return s;
            }
        }
        public static (double, double)[] ClstrCntrs(double x, double y, int area, (double, double)[] occupied, int shape = 0)
        {
            //Cluster of cells
            int i = 0, cnt = 0;
            var sqr = (AdjCntrs(x, y,shape).Except(occupied)).ToArray();
            while (cnt < area)
            {
                var a = AdjCntrs(sqr[i].Item1, sqr[i].Item2,shape).Except(occupied).ToArray();
                var b = sqr.Except(occupied).Union(a).ToArray();
                cnt = b.Length;
                sqr = b.ToArray();
                i ++;
            }
            return sqr.Take(area).ToArray();
        }
        public static List<(double, double)> PrmtrSqnce(List<(double, double)> prmCtr, int shape)
        {
            //Arrange in sequence
            List<(double, double)> a = new List<(double, double)> { prmCtr.First() };
            while (a.Count < prmCtr.Count)
                a.Add(AdjCntrs(Math.Round(a.Last().Item1,3), Math.Round(a.Last().Item2,3), shape).Intersect(prmCtr).Except(a).First());
            return a;
        }
        public static List<(double, double)> PrmtrCntrs((double,double)[]clstrCntrs,int shape)
        {
            //Perimeter cells
            List<(double, double)> a = new List<(double, double)>();
            foreach ((double,double)i in clstrCntrs)
                if(AdjCntrs(i.Item1, i.Item2, shape).Except(clstrCntrs).ToArray().Length > 0)
                    a.Add(i);
            return a;
            //return PrmtrSqnce(a,shape);
        }
    }
}


  