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
        public static Polynomial QuadFactor(System.Numerics.Complex z)
        {
            var a = z.Real;
            var b = z.Imaginary;
            return new Polynomial(1, -2 * a , a * a + b * b);
        }

    }
}
