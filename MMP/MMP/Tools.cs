using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMP
{
    public static class Tools
    {
        public static T[] _<T>(params T[] data) { return data; }
        public static List<T> _l<T>(params T[] data)
        {
            var l = new List<T>();
            l.AddRange(data);
            return l;
        }
    }
}
