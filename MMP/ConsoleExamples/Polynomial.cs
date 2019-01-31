using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MMP.Tools;
using static System.Console;
using System.Numerics;
using dvec = MathNet.Numerics.LinearAlgebra.Double.DenseVector;
using cvec = MathNet.Numerics.LinearAlgebra.Complex.DenseVector;
using dpoly = MMP.Double.Polynomial;
using cpoly = MMP.Complex.Polynomial;

namespace ConsoleExamples
{
    public static class Polynomial
    {
        public static void Ex1()
        {
            var roots = _(0.0, 1, 2, 3, 4);
            var P = dpoly.OfRoots(roots);
            var p = P.Functor;
            var v = dvec.OfEnumerable(roots.Select(u => p(u)));
            WriteLine(v);
            WriteLine(P);
            WriteLine();
        }

        public static void Ex2()
        {
            var i = new Complex(0, 1);
            var roots = _<Complex>(-1, 1, -i, i);
            var P = cpoly.OfRoots(roots);
            var p = P.Functor;
            var v = cvec.OfEnumerable(roots.Select(u => p(u)));
            WriteLine(v);
            WriteLine(P);
            WriteLine();
        }

        public static void Ex3()
        {
            var i = new Complex(0, 1);
            var roots = _<Complex>(-1,1,1,1+i);
            var P = dpoly.OfRoots(roots);            
            WriteLine(P);
            WriteLine();
        }
    }
}

