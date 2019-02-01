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
            if (coefficients.Length == 0)
                a = new scalar[1] { 0 };
            else
            {
                if (coefficients[0] == 0)
                {
                    var ind = Array.FindIndex(coefficients, p => p != 0);
                    if (ind == -1)
                        a = new scalar[1] { 0 };
                    else
                    {
                        a = new scalar[coefficients.Length - ind];
                        Array.Copy(coefficients, ind, a, 0, a.Length);
                    }
                }
                else
                    a = coefficients;
            }
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

        public static Polynomial OfRootsAlternative(params System.Numerics.Complex[] roots)
        {
            var rts = roots.Concat(roots.Where(a => a.Imaginary != 0).Select(a => System.Numerics.Complex.Conjugate(a)));
            var p = MMP.Complex.Polynomial.OfRoots(rts.ToArray());
            return p.Real;
        }

        public static Polynomial QuadFactor(System.Numerics.Complex z)
        {
            var a = z.Real;
            var b = z.Imaginary;
            return new Polynomial(1, -2 * a, a * a + b * b);
        }

        public static Polynomial OfRoots(params System.Numerics.Complex[] roots)
        {
            if (roots.Length == 0)
                return new Polynomial();
            var p = new Polynomial(1);
            foreach (var r in roots)
            {
                if (r.Imaginary == 0)
                    p *= new Polynomial(1, -r.Real);
                else
                    p *= QuadFactor(r);
            }
            return p;
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
                if (c != 0.0)
                {
                    if (d < Degree)
                        if (c > 0.0)
                            b.Append("+");
                        else
                            b.Append("-");
                    var ac = Math.Abs(c);
                    if (ac != 1 || d == 0)
                        b.Append(ac);
                    if (d > 1)
                        b.Append($"x^{d}");
                    else if (d == 1)
                        b.Append($"x");
                }
                d--;
            }
            return b.ToString();
        }

        /// <summary>
        /// Indexer 
        /// </summary>
        /// <param name="d">x^d</param>
        /// <returns></returns>
        public scalar this[int d]
        {
            get
            {
                if (d < a.Length)
                    return a[a.Length - d - 1];
                else
                    return 0;
            }
            set
            {
                if (d < a.Length)
                    a[a.Length - d - 1] = value;
            }
        }

        public static Func<scalar, scalar> Poly(params scalar[] coefficients)
        {
            var p = new Polynomial(coefficients);
            return p.Evaluate;
        }

        public static implicit operator Polynomial(scalar a)
        {
            return new Polynomial(a);
        }

        public static Polynomial operator *(Polynomial p, Polynomial q)
        {
            var a = new scalar[p.Degree + q.Degree + 1];
            a[0] = p.a[0] * q.a[0];
            var r = new Polynomial(a);
            for (int d = 0; d < r.Degree; d++)
                for (int i = 0; i < d + 1; i++)
                    r[d] += p[i] * q[d - i];
            return r;
        }

        public static Polynomial operator +(Polynomial p, Polynomial q)
        {
            if (p.Degree < q.Degree)
                MMP.Tools.Swap(ref p, ref q); //p.Degree >= q.Degree
            var a = new scalar[p.a.Length];
            p.a.CopyTo(a, 0);
            var r = new Polynomial(a);
            for (int d = 0; d <= q.Degree; d++)
                r[d] += q[d];
            return r;
        }

        public static Polynomial operator -(Polynomial p, Polynomial q)
        {
            return p + (-1) * q;
        }

        public System.Numerics.Complex[] Roots
        {
            get
            {
                return MathNet.Numerics.FindRoots.Polynomial(a.Reverse().ToArray());
            }
        }
    }
}

namespace MMP.Complex
{
    using scalar = System.Numerics.Complex;

    /// <summary>
    /// Simple version  
    /// </summary>
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
                if (c != 0.0)
                {
                    if (d < Degree)
                        b.Append("+");
                    b.Append(c);
                    if (d > 1)
                        b.Append($"z^{d}");
                    else if (d == 1)
                        b.Append($"z");
                }
                d--;
            }
            return b.ToString();
        }

        public MMP.Double.Polynomial Real
        {
            get
            {
                return new MMP.Double.Polynomial(a.Select(p => p.Real).ToArray());
            }
        }

        public static Func<scalar, scalar> Poly(params scalar[] coefficients)
        {
            var p = new Polynomial(coefficients);
            return p.Evaluate;
        }
    }
}

