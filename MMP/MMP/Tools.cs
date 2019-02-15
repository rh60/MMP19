using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public static IEnumerable<int[]> PascalTriangle(int n)
    {
        var bin = new MELib.Binomial();
        for (int i = 0; i < n; i++)
            yield return bin.Next;
    }
}

