using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static MMP.Linspace;
using MathNet.Numerics.LinearAlgebra;
using static System.Console;

namespace ConsoleExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = Vector<double>.Build.DenseOfEnumerable(linspace(0, PI, 11));
            var y = x.Map(Sin);
            WriteLine(y);
            WriteLine(y.AbsoluteMaximum());
        }
    }
}
