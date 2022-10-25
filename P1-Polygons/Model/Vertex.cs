using P1_Polygons.Controls;
using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Logic.MainLogic;
using System.Diagnostics;
using System.Numerics;
using System.Xml.Schema;
using static P1_Polygons.Model.Vertex;

namespace P1_Polygons.Model
{
    public class Vertex : Figure
    {
        public PointF Position;
        private readonly Polygon _polygon;

        public Edge? Incoming { get; set; }
        public Edge? Outgoing { get; set; }

        public Vertex(PointF position, Polygon polygon)
        {
            Position = position;
            _polygon = polygon;
        }

        public override Polygon GetPolygon()
        {
            return _polygon;
        }

        public override void MoveBy(PointF vector)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {vector}");
            Position.X += vector.X;
            Position.Y += vector.Y;
        }

        public override float GetDistanceSquared(PointF point)
        {
            var xDif = point.X - Position.X;
            var yDif = point.Y - Position.Y;

            return xDif * xDif + yDif * yDif;
        }

        public override int GetPixelDistanceSquared(Point point, Rasterizer rasterizer)
        {
            return rasterizer.PixelDistanceSquared(rasterizer.Rasterize(Position), point);
        }

        public override void ShowContextMenu(MainWindow mainWindow, Point point)
        {
            var vertexContextMenuStrip = new VertexContextMenuStrip(this);
            vertexContextMenuStrip.Show(mainWindow.pictureBox, point);
        }

        public override void Remove()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            if (_polygon.Vertices.Count <= 3) return;

            _polygon.Vertices.Remove(this);

            var edgeWithStartAsThis = _polygon.Edges.Single(_ => _.Start == this);
            var edgeWithEndAsThis = _polygon.Edges.Single(_ => _.End == this);
            var nextEdge = _polygon.Edges.Single(_ => _.Start == edgeWithStartAsThis.End);

            _polygon.Edges.Remove(edgeWithStartAsThis);
            edgeWithEndAsThis.End = nextEdge.Start;
            edgeWithEndAsThis.End.Outgoing = nextEdge;
            nextEdge.Start.Incoming = edgeWithStartAsThis;
        }

        private ISet<PerpendicularityRestriction> _visitedRestrictions;
        private Stack<PerpendicularityRestriction> _restritionsToVisit;

        public override void MoveByConsideringRestrictions(PointF vector, Direction? direction = null)
        {
            _visitedRestrictions = new HashSet<PerpendicularityRestriction>();
            _restritionsToVisit = new Stack<PerpendicularityRestriction>();
            MoveBy(vector);
            _ConsiderLengthRestrictions(vector, this, direction);
            _ConsiderPerpendicularityRestrictions(vector, this, direction);
        }

        private void _MoveByConsideringRestrictions(PointF vector, Vertex start, Direction? direction = null)
        {
            if (this == start) return;

            MoveBy(vector);
            _ConsiderLengthRestrictions(vector, start, direction);
            _ConsiderPerpendicularityRestrictions(vector, start, direction);
        }

        private void _ConsiderPerpendicularityRestrictions(PointF vector, Vertex start, Direction? direction)
        {
            var incomingRestriction = (PerpendicularityRestriction?)Incoming!.EdgeRestrictions.SingleOrDefault(_ => _ is PerpendicularityRestriction);

            var otherRestricitionEdge = incomingRestriction?.Edge1 == Incoming ? incomingRestriction?.Edge2! : incomingRestriction?.Edge1;
            var otherVertex = otherRestricitionEdge?.Start == this ? otherRestricitionEdge?.End : otherRestricitionEdge?.Start;
            var cm = incomingRestriction?.CorrectingMovement(this, otherVertex);
            if (cm.HasValue && direction != Direction.Outgoing)
            {
                otherVertex.MoveBy(cm.Value);
            }

            /*
            
            var outgoingRestriction = (PerpendicularityRestriction?)Outgoing!.EdgeRestrictions.SingleOrDefault(_ => _ is PerpendicularityRestriction);

            otherRestricitionEdge = outgoingRestriction?.Edge1 == Outgoing ? outgoingRestriction?.Edge2 : outgoingRestriction?.Edge1;
            otherVertex = otherRestricitionEdge?.Start == this ? otherRestricitionEdge?.End : otherRestricitionEdge?.Start;

            var cm2 = outgoingRestriction?.CorrectingMovement(this, otherVertex);
            if (cm2.HasValue && direction != Direction.Incoming)
            {
                otherVertex.MoveBy(cm2.Value);
            }
            */
        }

        private void _ConsiderLengthRestrictions(PointF vector, Vertex start, Direction? direction = null)
        {
            var incomingRestriction = (LengthRestritcion?)Incoming!.EdgeRestrictions.SingleOrDefault(_ => _ is LengthRestritcion);

            var cm = incomingRestriction?.CorrectingMovement(this, Incoming!.Start);
            if (cm.HasValue && direction != Direction.Outgoing)
            {
                Incoming!.Start._MoveByConsideringRestrictions(cm.Value, start, Direction.Incoming);
            }

            var outgoingRestriction = (LengthRestritcion?)Outgoing!.EdgeRestrictions.SingleOrDefault(_ => _ is LengthRestritcion);

            var cm2 = outgoingRestriction?.CorrectingMovement(this, Outgoing!.End);
            if (cm2.HasValue && direction != Direction.Incoming)
            {
                Outgoing!.End._MoveByConsideringRestrictions(cm2.Value, start, Direction.Outgoing);
            }
        }

        public enum Direction
        {
            Incoming, Outgoing
        }
    }
}
