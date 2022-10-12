using System.Diagnostics;
using System.Xml.Schema;

namespace P1_Polygons.Model
{
    public class Vertex : Figure
    {
        private PointF _position;
        public PointF Position { get => _position; private set
            {
                _position = value;
                _rasterizedPosition = Rasterize(Position);
            }
        }
        private Point _rasterizedPosition;
        public Point RasterizedPosition { get => _rasterizedPosition; private set
            {
                _rasterizedPosition = value;
                _position = Derasterize(RasterizedPosition);
            }
        }
        public Edge? From { get; set; }
        public Edge? To { get; set; }

        public Vertex(PointF position)
        {
            Position = position;
        }
        public Vertex(Point position)
        {
            RasterizedPosition = position;
        }

        private Point Rasterize(PointF point)
        {
            var _canvas = 2137;
            var xMax = 2;
            var xMin = 2;
            var yMax = 2;
            var yMin = 2;

            return new Point(
                (int)Math.Round(point.X * (_canvas) / (xMax - xMin)),
                (int)Math.Round(point.Y * (_canvas) / (yMax - yMin)));
        }
        private PointF Derasterize(Point point)
        {
            var _canvas = 2137;
            var xMax = 2;
            var xMin = 2;
            var yMax = 2;
            var yMin = 2;

            return new PointF(
                point.X * (xMax - xMin) / _canvas,
                point.Y * (yMax - yMin) / _canvas);
        }

        public void Move(Point position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {position}");
            RasterizedPosition = position;
        }

        public override void ProcessLeftClick()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public override void ProcessRightClick()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public override Polygon? GetPolygon()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            return From?.GetPolygon();
        }

        public override void MoveBy(Point vector)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {vector}");
            RasterizedPosition.Offset(vector.X, vector.Y);
        }

        public override void MoveTo(Point position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {position}");
            RasterizedPosition = position;
        }
    }
}
