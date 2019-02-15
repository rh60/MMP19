using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MELib
{
    public class Binomial
    {
        int[] p;
        public int[] Next
        {
            get
            {
                if (p == null)
                {
                    p = new int[] { 1 };
                }
                else
                {
                    var q = new int[p.Length + 1];
                    q[0] = 1;
                    q[p.Length] = 1;
                    for (int j = 1; j < p.Length; j++)
                        q[j] = p[j - 1] + p[j];
                    p = q;
                }
                return p;
            }
        }
    }
}

