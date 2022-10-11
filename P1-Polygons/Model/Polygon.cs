using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Model
{
    public class Polygon : Figure
    {
        private List<Edge> edges;
        private List<Vertex> points;

        public Polygon(List<Edge> edges, List<Vertex> points)
        {
            this.edges = edges;
            this.points = points;
        }

        public override Polygon GetPolygon()
        {
            return this;
        }

        public override void ProcessLeftClick()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public override void ProcessRightClick()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }
    }
}
