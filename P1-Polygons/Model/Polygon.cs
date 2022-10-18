using P1_Polygons.Logic.MainLogic;
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
        public List<Edge> Edges { get; }
        public List<Vertex> Vertices { get; }

        public Polygon(List<Edge> edges, List<Vertex> vertices)
        {
            this.Edges = edges;
            this.Vertices = vertices;
        }

        public override Polygon GetPolygon()
        {
            return this;
        }

        public override void MoveBy(PointF vector)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {vector}");
            foreach (var vertex in Vertices)
            {
                vertex.MoveBy(vector);
            }
        }

        public override void MoveTo(PointF position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {position}");
            foreach (var vertex in Vertices)
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

        public override float GetDistanceSquared(PointF point)
        {
            throw new NotImplementedException();
        }

        public override int GetPixelDistanceSquared(Point point, Rasterizer rasterizer)
        {
            throw new NotImplementedException();
        }
    }
}
