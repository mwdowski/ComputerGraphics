using P1_Polygons.Controls;
using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Logic.MainLogic;
using System.Diagnostics;

namespace P1_Polygons.Model
{
    public class Edge : Figure
    {
        internal Vertex Start;
        internal Vertex End;
        private readonly Polygon _polygon;
        private EdgeContextMenuStrip _edgeContextMenuStrip;

        private List<IEdgeRestriction> _edgeRestriction = new List<IEdgeRestriction>(2);

        public Edge(Vertex start, Vertex end, Polygon polygon)
        {
            Start = start;
            End = end;
            _polygon = polygon;
            _edgeContextMenuStrip = new EdgeContextMenuStrip(this);
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

        private static Point ToVector(Point from, Point to)
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

        public override void ShowContextMenu(MainWindow mainWindow, Point point)
        {
            _edgeContextMenuStrip.Show(mainWindow.pictureBox, point);
        }

        public override void Remove()
        {
            _polygon.Edges.Remove(this);

            var edgeWithEndToChange = _polygon.Edges.Single(_ => _.End == Start);
            var edgeWithStartToChange = _polygon.Edges.Single(_ => _.Start == End);

            //edgeWithEndToChange.End = edgeWithStartToChange.;
            //edgeWithStartToChange.Start = edgeWithEndToChange
        }

        public void AddVertexOnMiddle()
        {
            var middlePosition = new PointF((Start.Position.X + End.Position.X) / 2, (Start.Position.Y + End.Position.Y) / 2);
            var newVertex = new Vertex(middlePosition, _polygon);
            _polygon.Vertices.Add(newVertex);

            var newEdge = new Edge(newVertex, End, _polygon);
            _polygon.Edges.Add(newEdge);
            End = newVertex;
        }
    }
}
