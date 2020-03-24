namespace Tstngwtrs
{
    public class Extrct
    {
        internal Extrct() { }
        public static double[] CnX((double, double, double)[] tpl)
        {
            double[] x = new double[tpl.Length];
            for (int i = 0; i < tpl.Length; i++)
            {
                x[i] = tpl[i].Item1;
            }
            return x;
        }

        public static double[] CnY((double, double, double)[] tpl)
        {
            double[] y = new double[tpl.Length];
            for (int i = 0; i < tpl.Length; i++)
            {
                y[i] = tpl[i].Item2;
            }
            return y;
        }

    }
}
