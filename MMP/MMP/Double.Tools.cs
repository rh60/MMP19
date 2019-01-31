using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMP.Double
{
    using scalar = System.Double;
    public static class Tools
    {
        public static scalar Convolution(scalar[] x, scalar[] y)
        {
            if (x.Length < y.Length)
                MMP.Tools.Swap(ref x, ref y);
            scalar r = 0;
            for (int i = 0; i <y.Length; i++)
            {
                r += x[i] * y[y.Length - i - 1]; 
            }
            return r;
        }

        public static Polynomial QuadFactor(scalar a, scalar b)
        {
            return new Polynomial(1, -2 * a , a * a + b * b);
        }

    }
}
