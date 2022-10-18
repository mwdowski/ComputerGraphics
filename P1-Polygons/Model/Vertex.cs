using P1_Polygons.Logic.MainLogic;
using System.Diagnostics;
using System.Xml.Schema;

namespace P1_Polygons.Model
{
    public class Vertex : Figure
    {
        public PointF Position;
        private readonly Polygon _polygon;

        public Vertex(PointF position, Polygon polygon)
        {
            Position = position;
            _polygon = polygon;
        }

        public override void MoveTo(PointF position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {position}");
        }

        public override void ProcessLeftClick()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public override void ProcessRightClick()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public override Polygon GetPolygon()
        {
            return _polygon;
        }

        public override void MoveBy(PointF vector)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {vector}");
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
    }
}
