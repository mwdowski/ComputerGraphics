using System.Diagnostics;
using System.Xml.Schema;

namespace P1_Polygons.Model
{
    public class Vertex : Figure
    {
        public PointF Position;
        public Edge? From { get; set; }
        public Edge? To { get; set; }

        public Vertex(PointF position)
        {
            Position = position;
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

        public override Polygon? GetPolygon()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            return From?.GetPolygon();
        }

        public override void MoveBy(PointF vector)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {vector}");
        }
    }
}
