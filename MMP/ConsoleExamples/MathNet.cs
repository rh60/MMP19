using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static MMP.Linspace;
using static System.Console;
using vec = MathNet.Numerics.LinearAlgebra.Double.DenseVector;
using mat = MathNet.Numerics.LinearAlgebra.Double.DenseMatrix;

namespace ConsoleExamples
{
    public static class MathNet
    {
        public static void Ex1()
        {
            var x = vec.OfEnumerable(linspace(-PI, PI, 11));
            x /= 2;
            var y = x.Map(Sin);
            var tab = mat.OfColumnVectors(x, y);
            WriteLine("\tx\ty");
            WriteLine(tab);
            WriteLine("Max(y)={0}", y.AbsoluteMaximum());
        }
    }
}
