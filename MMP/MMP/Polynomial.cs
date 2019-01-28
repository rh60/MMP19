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

        public int Degree
        {
            get { return a.Length - 1; }
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
                if (roots[i] != 0.0)
                    for (int j = i+1; j > 0; j--)                    
                        a[j] -= roots[i] * a[j-1];                    
            }           
            return new Polynomial(a);
        }

        /// <summary>
        /// Creates a formatted display of the polynom as powers of x.
        /// </summary>
        /// <returns>Formatted display</returns>
        public override string ToString()
        {            
            var d = Degree;
            if (d == 0)
                return a[0].ToString();
            var b = new StringBuilder();            
            foreach (var c in a)
            {
                if (c == 0.0) continue;
                if (d < Degree)
                    if (c > 0f)
                        b.Append("+");
                    else
                        b.Append("-");
                var ac = Math.Abs(c);
                if(ac!=1 || d==0)
                    b.Append(ac);
                if(d>1)
                    b.Append($"x^{d}");
                else if(d==1)
                    b.Append($"x");
                d--;
            }
            return b.ToString();
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
                if (roots[i] != 0.0)
                    for (int j = i + 1; j > 0; j--)
                        a[j] -= roots[i] * a[j - 1];
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
