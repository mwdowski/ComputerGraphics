using P1_Polygons.Controls;
using P1_Polygons.Logic.MainLogic;
using System.Diagnostics;
using System.Numerics;
using System.Xml.Schema;

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

        public override void MoveByConsideringRestrictions(PointF vector)
        {
            foreach (var restriction in Incoming?.EdgeRestrictions)
            {
                vector = restriction.CorrectedVectorForVertexMovement(vector, this);
            }
            foreach (var restriction in Outgoing?.EdgeRestrictions)
            {
                vector = restriction.CorrectedVectorForVertexMovement(vector, this);
            }
            MoveBy(vector);
            //Incoming?.ConsiderRestrictions(this);
            //Outgoing?.ConsiderRestrictions(this);
        }
    }
}
