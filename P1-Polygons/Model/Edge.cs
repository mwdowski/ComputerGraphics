﻿using P1_Polygons.Logic.EdgeRestrictions;
using System.Diagnostics;

namespace P1_Polygons.Model
{
    public class Edge : Figure
    {
        public readonly Vertex Start;
        public readonly Vertex End;
        private readonly Polygon Polygon;

        private List<IEdgeRestriction> _edgeRestriction = new List<IEdgeRestriction>(2);

        public Edge(Vertex start, Vertex end, Polygon polygon)
        {
            Start = start;
            End = end;
            Polygon = polygon;
        }

        public override Polygon? GetPolygon()
        {
            return Polygon;
        }

        public override void MoveBy(PointF vector)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {vector}");
            Start.MoveBy(vector);
            End.MoveBy(vector);
        }

        public override void MoveTo(PointF position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {position}");
            Start.MoveTo(position);
            End.MoveTo(position);
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
