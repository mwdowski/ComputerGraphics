using System.Diagnostics;

namespace P1_Polygons.Model
{
    public class Vertex : Figure
    {
        public PointF Position { get; private set; }
        public Edge From { get; private set; }
        public Edge? To { get; private set; }

        public Vertex(PointF position, Edge from)
        {
            Position = position;
            From = from;
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
            return From.GetPolygon();
        }
    }
}
