using Clusters;
using Microsoft.FSharp.Collections;

namespace TstngWtrsF
{
    public class FShapes
    {
        internal FShapes() { }
        
        public static FSharpList<FSharpList<double>> Clstr(int c = 1, int n = 1, double x = 0.0, double y = 0.0)
        {
            var tup = HexShapes.cls (n, HexShapes.adj( 0.0, 1074 ), x, y);
            var xm = (HexShapes.mcs(c, tup));
            
            //return HexShapes.tupLst(xm);
            //var prm = HexShapes.prm(tup);
            return HexShapes.tupXY(xm);            
        }
 
    }
}