using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using number = Generic.Float64.Scalar;

namespace Generic
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Vector<number>(1, 2, 3);
            var norm2 = x.Dot(x);

            var T = new TriStorage<number>(5);
            T[2, 1] = 1;
        }
    }
}