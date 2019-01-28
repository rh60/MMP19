using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MMP.Tools;
using static System.Console;
using static MMP.Complex.Polynomial;
using System.Numerics;
using MMP.Complex;
using vec = MathNet.Numerics.LinearAlgebra.Complex.DenseVector;


namespace ConsoleExamples
{
    public static class Polynomial
    {
        public static void Ex()
        {
            var roots = _(new Complex(0,0), 1, 2, 3, 4);
            var p = OfRoots(roots).Functor;
            var v = vec.OfEnumerable(roots.Select(u => p(u)));
            WriteLine(v);
        }
    }
}

