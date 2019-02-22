using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using int_t = System.Int64; 

namespace MELib
{
    public class Binomial
    {
        int_t[] p;
        public int_t[] Next()
        {
            if (p == null)
            {
                p = new int_t[] { 1 };
            }
            else
            {
                var q = new int_t[p.Length + 1];
                q[0] = 1;
                q[p.Length] = 1;
                for (int_t j = 1; j < p.Length; j++)
                    q[j] = p[j - 1] + p[j];
                p = q;
            }
            return p;
        }
    }

    public class BernsteinBase
    {
        double[][] p;
        double[] l1;
        double[] l2;
        public BernsteinBase(double[] t)
        {            
            l1 = t.Select(x => 1 - x).ToArray();
            l2 = t;            
        }
        public double[][] Next()
        {
            if (p == null)
            {
                p = new double[][] { new double[l2.Length] };
                p[0].Fill(1);                
            } 
            else
            {
                var q = new double[p.Length + 1][];
                q[0] = l1.Zip(p[0],(a,b)=>a*b).ToArray();            
                q[p.Length] = l2.Zip(p[p.Length-1], (a, b) => a * b).ToArray();
                for (int j = 1; j < p.Length; j++)
                    q[j] = p[j-1].Zip(l2, (a, b) => a * b)
                        .Zip(p[j].Zip(l1, (a, b) => a * b),(a,b)=>a+b).ToArray();
                p = q;               
            }
            return p;
        }
    }
}

