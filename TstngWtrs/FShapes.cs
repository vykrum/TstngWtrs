using Clusters;
using Microsoft.FSharp.Collections;
using System.Collections.Generic;

namespace TstngWtrsF
{
    public class FShapes
    {
        internal FShapes() { }
        
        public static FSharpList<FSharpList<double>> Clstr(int n = 1, double x = 0.0, double y = 0.0)
        {
            var tup = HexShapes.cls (x, y, n, HexShapes.adj( 0.0, 1.074 ) );
            return HexShapes.tupXY(tup);
            //var prm = HexShapes.prm(tup);
            //return HexShapes.tupXY( prm );            
        }

        public static List<int> Test (List<int> a)
        {
            return a;
        }
    }
}