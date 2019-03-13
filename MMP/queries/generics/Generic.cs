using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    interface IAddGroup<T>
        where T : struct
    {
        T Add(T a);
        T Zero { get; }
    }

    interface IMultGroup<T>
        where T : struct
    {
        T Mult(T a);
        T One { get; }
    }

    interface IRing<T> : IAddGroup<T>, IMultGroup<T>
        where T : struct
    { }


    namespace Float64
    {
        using scalar = System.Double;

        [DebuggerDisplay("{x}")]
        struct Scalar : IRing<Scalar>
        {
            scalar x;
            static Scalar zero = 0;
            static Scalar one = 1;
            public Scalar(scalar x)
            {
                this.x = x;
            }

            public Scalar Zero => zero;

            public Scalar One => one;

            public Scalar Add(Scalar a)
            {
                return a.x + x;
            }

            public Scalar Mult(Scalar a)
            {
                return a.x * x;
            }

            public static implicit operator Scalar(scalar x)
            {
                return new Scalar(x);
            }
        }
    }
    namespace Float32
    {
        using scalar = System.Single;

        [DebuggerDisplay("{x}")]
        struct Scalar : IRing<Scalar>
        {
            scalar x;
            static Scalar zero = 0;
            static Scalar one = 1;
            public Scalar(scalar x)
            {
                this.x = x;
            }

            public Scalar Zero => zero;

            public Scalar One => one;

            public Scalar Add(Scalar a)
            {
                return a.x + x;
            }

            public Scalar Mult(Scalar a)
            {
                return a.x * x;
            }

            public static implicit operator Scalar(scalar x)
            {
                return new Scalar(x);
            }
        }
    }
    namespace Float80
    {
        using scalar = System.Decimal;

        [DebuggerDisplay("{x}")]
        struct Scalar : IRing<Scalar>
        {
            scalar x;
            static Scalar zero = 0;
            static Scalar one = 1;
            public Scalar(scalar x)
            {
                this.x = x;
            }

            public Scalar Zero => zero;

            public Scalar One => one;

            public Scalar Add(Scalar a)
            {
                return a.x + x;
            }

            public Scalar Mult(Scalar a)
            {
                return a.x * x;
            }

            public static implicit operator Scalar(scalar x)
            {
                return new Scalar(x);
            }
        }
    }
    namespace Integer32
    {
        using scalar = System.Int32;

        [DebuggerDisplay("{x}")]
        struct Scalar : IRing<Scalar>
        {
            scalar x;
            static Scalar zero = 0;
            static Scalar one = 1;
            public Scalar(scalar x)
            {
                this.x = x;
            }

            public Scalar Zero => zero;

            public Scalar One => one;

            public Scalar Add(Scalar a)
            {
                return a.x + x;
            }

            public Scalar Mult(Scalar a)
            {
                return a.x * x;
            }

            public static implicit operator Scalar(scalar x)
            {
                return new Scalar(x);
            }
        }
    }
    namespace Integer64
    {
        using scalar = System.Int64;

        [DebuggerDisplay("{x}")]
        struct Scalar : IRing<Scalar>
        {
            scalar x;
            static Scalar zero = 0;
            static Scalar one = 1;
            public Scalar(scalar x)
            {
                this.x = x;
            }

            public Scalar Zero => zero;

            public Scalar One => one;

            public Scalar Add(Scalar a)
            {
                return a.x + x;
            }

            public Scalar Mult(Scalar a)
            {
                return a.x * x;
            }

            public static implicit operator Scalar(scalar x)
            {
                return new Scalar(x);
            }
        }
    }

    class Vector<T>
        where T : struct, IRing<T>
    {
        T[] u;

        public Vector(params T[] v)
        {
            u = v;
        }
        public T Dot(Vector<T> v)
        {
            T r = u[0].Zero;
            for (int i = 0; i < u.Length; i++)
            {
                var tmp = u[i].Mult(v.u[i]);
                r=r.Add(tmp);
            }
            return r;
        }
    }

}
