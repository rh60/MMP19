using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    [DebuggerDisplay("{data}")]
    public class TriStorage<T>
    {
        T[][] data;        
        public TriStorage(int n)
        {
            data = new T[n][];
            for (int i = 0; i < n; i++)
            {
                data[i] = new T[i + 1];
            }
        }

        public T this[int i, int j]
        {
            get
            {
                return data[i][j];
            }
            set
            {
                data[i][j] = value;
            }
        }
    }
}
