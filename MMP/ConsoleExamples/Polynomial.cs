using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ME;
using static System.Console;
using System.Numerics;
using dvec = MathNet.Numerics.LinearAlgebra.Double.DenseVector;
using cvec = MathNet.Numerics.LinearAlgebra.Complex.DenseVector;
using dpoly = MELib.Double.Polynomial;
using cpoly = MELib.Complex.Polynomial;

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
            var roots = _<Complex>(-1, 1, 1, 1 + i);
            var P = dpoly.OfRoots(roots);
            WriteLine(P);
            WriteLine(cvec.OfArray(P.Roots));
        }

        public static void Ex4()
        {
            var p = new dpoly(1, 1, 0);
            var q = new dpoly(1, 2, -1);
            WriteLine($"({p}) * ({q}) = {p * q}");
            WriteLine($"({p}) + ({q}) = {p + q}");
            WriteLine($"({p}) - ({q}) = {p - q}");
            WriteLine();
        }

        public static void Ex5()
        {
            var p = new dpoly(-1, 2, 3, 0, 4);
            var z = new dpoly();
            WriteLine($"d({p})/dx = {p.Derivative()}");
            WriteLine($"Int({p})dx = {p.AntiDerivative()}");
            WriteLine($"Int({z})dx = {z.AntiDerivative()}");
            WriteLine();
        }

        public static void Ex6()
        {
            var b = ME.BernsteinBase(2, 0.1);
        }
    }
}

