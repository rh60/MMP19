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
}

