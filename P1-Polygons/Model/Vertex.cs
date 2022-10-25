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


        public override void MoveByConsideringRestrictions(PointF vector, Direction? direction = null)
        {
            var visitedRestrictions = new HashSet<IEdgeRestriction>();
            _MoveByConsideringRestrictions(vector, visitedRestrictions, null);
        }

        private void _MoveByConsideringRestrictions(PointF vector, HashSet<IEdgeRestriction> visited, Direction? direction = null)
        {
            MoveBy(vector);
            _ConsiderLengthRestrictions(vector, visited, direction);
            _ConsiderPerpendicularityRestrictions(vector, visited, direction);
        }

        private void _ConsiderPerpendicularityRestrictions(PointF vector, HashSet<IEdgeRestriction> visited, Direction? direction)
        {
            var incomingRestrictions = Incoming!.EdgeRestrictions.Where(_ => _ is PerpendicularityRestriction).Cast<PerpendicularityRestriction>().ToList();
            foreach (var incomingRestriction in incomingRestrictions)
            { 
                if (incomingRestriction != null && !visited.Contains(incomingRestriction))
                {
                    visited.Add(incomingRestriction);
                    var otherRestricitionEdge = incomingRestriction?.Edge1 == Incoming ? incomingRestriction?.Edge2 : incomingRestriction?.Edge1;
                    var otherVertex = otherRestricitionEdge?.Start == this ? otherRestricitionEdge?.End : otherRestricitionEdge?.Start;
                    var correctedMovement = incomingRestriction?.CorrectingMovement(this, otherVertex!);
                    if (correctedMovement.HasValue)
                    {
                        otherVertex?._MoveByConsideringRestrictions(correctedMovement.Value, visited, null);
                    }
                }
            }

            
            var outgoingRestrictions = Outgoing!.EdgeRestrictions.Where(_ => _ is PerpendicularityRestriction).Cast<PerpendicularityRestriction>().ToList();
            foreach (var outgoingRestriction in outgoingRestrictions)
            {
                if (outgoingRestriction != null && !visited.Contains(outgoingRestriction))
                {
                    visited.Add(outgoingRestriction);
                    var otherRestricitionEdge = outgoingRestriction?.Edge1 == Outgoing ? outgoingRestriction?.Edge2 : outgoingRestriction?.Edge1;
                    var otherVertex = otherRestricitionEdge?.End == this ? otherRestricitionEdge?.Start : otherRestricitionEdge?.End;
                    var correctedMovement = outgoingRestriction?.CorrectingMovement(this, otherVertex!);
                    if (correctedMovement.HasValue)
                    {
                        otherVertex?._MoveByConsideringRestrictions(correctedMovement.Value, visited, null);
                    }
                }
            }
            
        }

        private void _ConsiderLengthRestrictions(PointF vector, HashSet<IEdgeRestriction> visited, Direction? direction = null)
        {
            var incomingRestriction = (LengthRestritcion?)Incoming!.EdgeRestrictions.SingleOrDefault(_ => _ is LengthRestritcion);
            if (incomingRestriction != null && !visited.Contains(incomingRestriction) && direction != Direction.Outgoing)
            {
                visited.Add(incomingRestriction);
                var correctedMovement = incomingRestriction?.CorrectingMovement(this, Incoming!.Start);
                if (correctedMovement.HasValue)
                {
                    Incoming!.Start._MoveByConsideringRestrictions(correctedMovement.Value, visited, Direction.Incoming);
                }
            }

            var outgoingRestriction = (LengthRestritcion?)Outgoing!.EdgeRestrictions.SingleOrDefault(_ => _ is LengthRestritcion);
            if (outgoingRestriction != null && !visited.Contains(outgoingRestriction) && direction != Direction.Incoming)
            {
                visited.Add(outgoingRestriction);
                var correctedMovement = outgoingRestriction?.CorrectingMovement(this, Outgoing!.End);
                if (correctedMovement.HasValue)
                {
                    Outgoing!.End._MoveByConsideringRestrictions(correctedMovement.Value, visited, Direction.Outgoing);
                }
            }
        }

        public enum Direction
        {
            Incoming, Outgoing
        }
    }
}
