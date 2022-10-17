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
        private List<Vertex> vertices;

        public Polygon(List<Edge> edges, List<Vertex> vertices)
        {
            this.edges = edges;
            this.vertices = vertices;
        }

        public override Polygon GetPolygon()
        {
            return this;
        }

        public override void MoveBy(PointF vector)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {vector}");
            foreach (var vertex in vertices)
            {
                vertex.MoveBy(vector);
            }
        }

        public override void MoveTo(PointF position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {position}");
            foreach (var vertex in vertices)
            {
                vertex.MoveTo(position);
            }
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
