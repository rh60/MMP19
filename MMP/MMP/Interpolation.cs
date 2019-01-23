using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMP.Interpolation
{
       
    public class Node
    {
        public class Leaf
        {
            Point c;
            public Leaf(Point p)
            {
                c = p;
            }

            public Func<double, Point> Functor => t => c;
        }

        TimeSpan tspan;
        Func<double, Point> left;
        Func<double, Point> right;
        public Node(double t1, double t2, Point p1, Point p2)
        {
            tspan = new TimeSpan(t1, t2);
            var leaf = new Leaf(p1);
            left = leaf.Functor;
            leaf = new Leaf(p2);
            right = leaf.Functor;
        }

        public Node(Node n1, Node n2)
        {
            tspan = new TimeSpan(n1.tspan.Start, n2.tspan.Stop);           
            left = n1.Functor;          
            right = n2.Functor;
        }        

        public Func<double, Point> Functor => t => tspan.Left(t) * left(t) + tspan.Right(t) * right(t);       
    }

    public static class Curve
    {
        public static Func<double, Point> From(ParPoint[] c)
        {
            int n = c.Length - 1;
            Node[] nodes = new Node[n];
            for (int i = 0; i < n; i++)
                nodes[i] = new Node(c[i].t, c[i + 1].t, c[i], c[i + 1]);
            for (int i = 1; i < n; i++)
                for (int j = 0; j < n-i; j++)                
                    nodes[j] = new Node(nodes[j], nodes[j + 1]);               
            return nodes[0].Functor;
        }
    }

}
