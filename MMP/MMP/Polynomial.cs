using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMP.Double
{
    using scalar = System.Double;
    public class Polynomial
    {
        scalar[] a;
        public Polynomial(params scalar[] coefficients)
        {
            if(coefficients.Length==0)
                a = new scalar[1] {0};
            else
                a = coefficients;
        }

        public scalar Evaluate(scalar x)
        {
            scalar r = a[0];
            for (int i = 1; i < a.Length; i++)
                r = r * x + a[i];
            return r;
        }

        public Func<scalar,scalar> Functor
        {
            get { return Evaluate; }
        }

        public Polynomial MultiplyByFactor(scalar c)
        {
            var a1 = new scalar[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
            {
                a1[i] += a[i];
                a1[i + 1] -= c * a[i];
            }
            return new Polynomial(a1);
        }

        public static Polynomial OfRoots(params scalar[] roots)
        {
            if (roots.Length == 0)
                return new Polynomial();
            var a = new scalar[roots.Length + 1];
            a[0] = 1;
            for (int i = 0; i < roots.Length; i++)
            {
                var s = new ArraySegment<scalar>(a, 0, i + 2);
                if (roots[i] != 0.0)
                    for (int j = s.Count-1; j > 0; j--)                    
                        s.Array[j] -= roots[i] * s.Array[j-1];                    
            }           
            return new Polynomial(a);
        }

        public static Func<scalar,scalar> Poly(params scalar[] coefficients)
        {
            var p = new Polynomial(coefficients);
            return p.Evaluate;
        }
    }
}

namespace MMP.Complex
{
    using scalar = System.Numerics.Complex;
    public class Polynomial
    {
        scalar[] a;
        public Polynomial(params scalar[] coefficients)
        {
            if (coefficients.Length == 0)
                a = new scalar[1] { 0 };
            else
                a = coefficients;
        }

        public scalar Evaluate(scalar x)
        {
            scalar r = a[0];
            for (int i = 1; i < a.Length; i++)
                r = r * x + a[i];
            return r;
        }

        public Func<scalar, scalar> Functor
        {
            get { return Evaluate; }
        }

        public Polynomial MultiplyByFactor(scalar c)
        {
            var a1 = new scalar[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
            {
                a1[i] += a[i];
                a1[i + 1] -= c * a[i];
            }
            return new Polynomial(a1);
        }

        public static Polynomial OfRoots(params scalar[] roots)
        {
            if (roots.Length == 0)
                return new Polynomial();
            var a = new scalar[roots.Length + 1];
            a[0] = 1;
            for (int i = 0; i < roots.Length; i++)
            {
                var s = new ArraySegment<scalar>(a, 0, i + 2);
                if (roots[i] != 0.0)
                    for (int j = s.Count - 1; j > 0; j--)
                        s.Array[j] -= roots[i] * s.Array[j - 1];
            }
            return new Polynomial(a);
        }

        public static Func<scalar, scalar> Poly(params scalar[] coefficients)
        {
            var p = new Polynomial(coefficients);
            return p.Evaluate;
        }
    }
}
