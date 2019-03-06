using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.Marshal;
using static System.Console;
using static US.Vector; 

namespace US
{  
    unsafe class Vector : IDisposable
    {
        public class  EndInd
        {
            private EndInd() { }
        };
        public static EndInd End;

        IntPtr data;
        double* p;
        long size; 
        public Vector(long size)
        {
            data = AllocHGlobal((IntPtr)(size * sizeof(double)));
            p = (double*)data;
            this.size = size;
        }

        public double this[long i]
        {
            get
            {
                return p[i];
            }
            set
            {
                p[i] = value;
            }
        }

        public double this[EndInd i]
        {
            get
            {            
                return p[size-1];
            }
            set
            {
                p[size-1] = value;
            }
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                FreeHGlobal(data);
                WriteLine("free");
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Vector()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
    unsafe class Program
    {
        static void Main(string[] args)
        {
            var v = new Vector(1000);
            WriteLine(v[0]);
            v[0] = 3;
            WriteLine(v[0]);
            v[End] = 100;
            WriteLine(v[End]);
            //EndInd ind = new EndInd();
            v.Dispose();
        }
    }
}