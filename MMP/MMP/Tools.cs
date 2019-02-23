using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using int_t = System.Int64;

public static class ME
{
    public static T[] _<T>(params T[] data) { return data; }
    public static List<T> _l<T>(params T[] data)
    {
        var l = new List<T>();
        l.AddRange(data);
        return l;
    }   
    public static void Swap<T>(ref T a, ref T b)
    {
        var tmp = a;
        a = b;
        b = tmp;
    }

    public static void Fill<T>(this T[] array, T value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }
    }

    public static int_t[] Binomial(int n)
    {
        var bin = new MELib.Binomial();
        for (int i = 0; i < n; i++)
            bin.Next();
        return bin.Next();
    }

    public static IEnumerable<int_t[]> PascalTriangle(int n)
    {
        var bin = new MELib.Binomial();
        for (int i = 0; i < n; i++)
            yield return bin.Next();
    }
    /// <summary>
    /// Computes n+1 values of Bernstein base polynomials at point x
    /// </summary>
    /// <param name="n">Degree</param>
    /// <param name="x">Point</param>
    /// <returns></returns>
    public static double[] BernsteinBase(int n, double x)
    {
        var b = new double[n + 1];
        b.Fill(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                b[j] *= 1 - x;
                b[n - j] *= x;
            }
        }
        var c = Binomial(n);
        for (int i = 0; i < n + 1; i++)
            b[i] *= c[i];
        return b;
    }
    /// <summary>
    /// Computes n+1 values of Bernstein base polynomials at point x
    /// </summary>
    /// <param name="n">Degree</param>
    /// <param name="x">Points</param>
    /// <returns></returns>
    public static double[][] BernsteinBase(int n, double[] x)
    {
        var b = new MELib.BernsteinBase(x);
        for (int i = 0; i < n; i++)
            b.Next();        
        return b.Next();
    }

    public static double Dot(double[] @base, double[] vals)
    {
        return @base.Zip(vals, (x, y) => x * y).Sum();
    }

    public static double[] Lin(double[][] @base, double[] vals)
    {
        var n = @base[0].Length;
        var r = new double[n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < @base.Length; j++)
                r[i] += vals[j] * @base[j][i];
        return r;
    }
}
