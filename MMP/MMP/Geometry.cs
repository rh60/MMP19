using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMP
{
    public struct Point
    {
        public double x, y;
        public static Point operator +(Point p, Point q)
        {
            return new Point { x = p.x + q.x, y = p.y + q.y };
        }
        public static Point operator *(double c, Point p)
        {
            return new Point { x = c * p.x, y = c * p.y };
        }
    }
    public struct ParPoint
    {
        public double t, x, y;
        public static implicit operator Point(ParPoint p)
        {
            return new Point { x = p.x, y = p.y };
        }
    }

    public struct TimeSpan
    {
        public readonly double Start, Stop;
        readonly double h;
        public TimeSpan(double t0, double t1)
        {
            Start = t0; Stop = t1;
            h = t1 - t0;
        }
        public double Left(double t)
        {
            return (Stop - t) / h;
        }
        public double Right(double t)
        {
            return (t - Start) / h;
        }
    }

    public class PlainCurve
    {
        public Func<double, double> x, y;

        public IEnumerable<ParPoint> Sample(params double[] T)
        {
            foreach (var it in T)
                yield return new ParPoint { t = it, x = x(it), y = y(it) }; ;
        }
    }

    public struct Linspace : IEnumerable<double>
    {
        public double a, b;
        public int n;
        public Linspace(double a, double b, int n = 100)
        {
            this.a = a;
            this.b = b;
            this.n = n;
        }

        public static Linspace linspace(double a, double b, int n = 100)
        {
            return new Linspace(a, b, n);
        }

        public IEnumerator<double> GetEnumerator()
        {
            double h = (b - a) / (n - 1);
            for (int i = 0; i < n - 1; i++)
            {
                yield return a + i * h;
            }
            yield return b;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class OxyPlotAdapter
    {
        public static void Plot(OxyPlot.WindowsForms.PlotView plotv, IEnumerable<PlainCurve> curves, IEnumerable<double> data)
        {
            //var plotv = new OxyPlot.WindowsForms.PlotView();
            var model = new OxyPlot.PlotModel();
            foreach (var c in curves)
            {
                var series = new OxyPlot.Series.LineSeries();
                series.Points.AddRange(data.Select(t => new OxyPlot.DataPoint(c.x(t), c.y(t))));
                model.Series.Add(series);
            }
            plotv.Model = model;
        }

        public static void Plot(OxyPlot.WindowsForms.PlotView plotv, IEnumerable<Func<double, double>> funs, IEnumerable<double> data)
        {
            var model = new OxyPlot.PlotModel();
            foreach (var f in funs)
            {
                var series = new OxyPlot.Series.LineSeries();
                series.Points.AddRange(data.Select(t => new OxyPlot.DataPoint(t, f(t))));
                model.Series.Add(series);
            }
            plotv.Model = model;
        }

        public static OxyPlot.WindowsForms.PlotView Plot(IEnumerable<PlainCurve> curves, IEnumerable<double> data)
        {
            var plotv = new OxyPlot.WindowsForms.PlotView();
            Plot(plotv, curves, data);
            return plotv;
        }

        public static OxyPlot.WindowsForms.PlotView Plot(IEnumerable<Func<double, double>> funs, IEnumerable<double> data)
        {
            var plotv = new OxyPlot.WindowsForms.PlotView();
            Plot(plotv, funs, data);
            return plotv;
        }

    }
}
