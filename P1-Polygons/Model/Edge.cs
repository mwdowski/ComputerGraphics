﻿using P1_Polygons.Controls;
using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Logic.MainLogic;
using System.Diagnostics;

namespace P1_Polygons.Model
{
    public class Edge : Figure
    {
        internal Vertex Start;
        internal Vertex End;

        public float Length { get => (float)Math.Sqrt(
            (Start.Position.X - End.Position.X) * (Start.Position.X - End.Position.X) +
            (Start.Position.Y - End.Position.Y) * (Start.Position.Y - End.Position.Y));
        }

        private readonly Polygon _polygon;

        public List<IEdgeRestriction> EdgeRestrictions = new List<IEdgeRestriction>();

        public Edge(Vertex start, Vertex end, Polygon polygon)
        {
            Start = start;
            End = end;
            _polygon = polygon;
        }

        public override float GetDistanceSquared(PointF point)
        {
            var topSqrt = (End.Position.X - Start.Position.X) * (Start.Position.Y - point.Y)
                    - (Start.Position.X - point.X) * (End.Position.Y - Start.Position.Y);
            var bottom = Start.GetDistanceSquared(End.Position);

            return topSqrt * topSqrt / bottom;
        }

        private static int DotProduct(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static Point ToVector(Point from, Point to)
        {
            return new Point(to.X - from.X, to.Y - from.Y);
        }

        public override int GetPixelDistanceSquared(Point point, Rasterizer rasterizer)
        {
            var rasterizedStart = rasterizer.Rasterize(Start.Position);
            var rasterizedEnd = rasterizer.Rasterize(End.Position);

            if (DotProduct(ToVector(rasterizedStart, rasterizedEnd), ToVector(rasterizedEnd, point)) > 0)
            {
                return End.GetPixelDistanceSquared(point, rasterizer);
            }
            if (DotProduct(ToVector(rasterizedStart, rasterizedEnd), ToVector(rasterizedStart, point)) < 0)
            {
                return Start.GetPixelDistanceSquared(point, rasterizer);
            }

            float topSqrt = (rasterizedEnd.X - rasterizedStart.X) * (rasterizedStart.Y - point.Y)
                        - (rasterizedStart.X - point.X) * (rasterizedEnd.Y - rasterizedStart.Y);
            float bottom = Start.GetPixelDistanceSquared(rasterizedEnd, rasterizer);

            return (int)(topSqrt / bottom * topSqrt);
        }

        public override Polygon GetPolygon()
        {
            return _polygon;
        }

        public override void MoveBy(PointF vector)
        {
            Start.MoveBy(vector);
            End.MoveBy(vector);
        }

        public override void ShowContextMenu(MainWindow mainWindow, Point point)
        {
            var edgeContextMenuStrip = new EdgeContextMenuStrip(this);
            edgeContextMenuStrip.Items.Add("Add perpendicularity restriction", null, (_, _) =>
            {
                mainWindow.ClickMode = ClickModes.SelectingPerpendicularEdge;
            });
            edgeContextMenuStrip.Show(mainWindow.pictureBox, point);

        }

        public override void Remove()
        {
            if (_polygon.Edges.Count <= 3) return;

            _polygon.Edges.Remove(this);
            _polygon.Vertices.Remove(Start);
            _polygon.Vertices.Remove(End);

            var edgeWithEndToChange = _polygon.Edges.Single(_ => _.End == Start);
            var edgeWithStartToChange = _polygon.Edges.Single(_ => _.Start == End);

            var newVertex = CreateVertexInTheMiddle();
            _polygon.Vertices.Add(newVertex);

            edgeWithEndToChange.End = newVertex;
            newVertex.Incoming = edgeWithEndToChange;
            edgeWithStartToChange.Start = newVertex;
            newVertex.Outgoing = edgeWithStartToChange;

            ClearAllRestrictions();
        }

        private void ClearAllRestrictions()
        {
            var toRemove = new List<IEdgeRestriction>();
            foreach (var restriction in EdgeRestrictions)
            {
                toRemove.Add(restriction);
            }

            foreach (var restriction in toRemove)
            {
                restriction.Remove();
            }
        }

        public PointF Center => new PointF((Start.Position.X + End.Position.X) / 2, (Start.Position.Y + End.Position.Y) / 2);

        public string RestrictionString => EdgeRestrictions.Select(_ => _.Symbol).Aggregate(string.Empty, (s, v) => s + v);

        private Vertex CreateVertexInTheMiddle()
        {
            var middlePosition = Center;
            var newVertex = new Vertex(middlePosition, _polygon);

            return newVertex;
        }

        public void DivideEdgeWithVertexOnMiddle()
        {
            var newVertex = CreateVertexInTheMiddle();
            _polygon.Vertices.Add(newVertex);

            var newEdge = new Edge(newVertex, End, _polygon);
            _polygon.Edges.Add(newEdge);

            newVertex.Incoming = this;
            newVertex.Outgoing = newEdge;
            this.End.Incoming = newEdge;

            End = newVertex;

            ClearEdgeRestrictions();
        }

        private void ClearEdgeRestrictions()
        {
            EdgeRestrictions.Clear();
        }

        public void AddRestriction(IEdgeRestriction restriction)
        {
            restriction.Initialize();
        }

        public override void MoveByConsideringRestrictions(PointF vector, Vertex.Direction? direction = null)
        {
            Start.MoveByConsideringRestrictions(vector, Vertex.Direction.Incoming);
            End.MoveByConsideringRestrictions(vector, Vertex.Direction.Outgoing);
        }
    }
}
