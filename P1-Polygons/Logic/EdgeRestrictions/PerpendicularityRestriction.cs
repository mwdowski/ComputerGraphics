using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.EdgeRestrictions
{
    public class PerpendicularityRestriction : IEdgeRestriction
    {
        public string Symbol { get => "P"; }
        public Edge Edge1 { get; }
        public Edge Edge2 { get; }

        public int Order => 2;

        public PerpendicularityRestriction(Edge edge1, Edge edge2)
        {
            Edge1 = edge1;
            Edge2 = edge2;
        }

        public void Initialize()
        {
            Edge1.EdgeRestrictions.Add(this);
            Edge2.EdgeRestrictions.Add(this);

            Edge1.Start.MoveByConsideringRestrictions(new PointF(0, 0));
        }

        private static float DotProduct(PointF a, PointF b)
        {
            return a.X * b.X + a.Y * b.Y;
        }
        private static float CrossProduct(PointF a, PointF b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        public static PointF ToVector(PointF from, PointF to)
        {
            return new PointF(to.X - from.X, to.Y - from.Y);
        }

        public void Remove()
        {
            Edge1.EdgeRestrictions.Remove(this);
            Edge2.EdgeRestrictions.Remove(this);
        }

        public PointF CorrectingMovement(Vertex moved, Vertex other)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            PointF pivot = default;
            PointF pivotOther = default;
            PointF toRotate = other.Position;
            PointF toRotateOther = default;
            float sin = Edge1.End == Edge2.Start ? 1 : -1;
            float cos = Edge1.End == Edge2.Start ? 1 : -1;

            if (Edge1.Start == Edge2.End && Edge1.Start == moved)
            {
                pivot = moved.Position;
                toRotateOther = moved.Position;
                pivotOther = Edge1.End == other ? Edge2.Start.Position : Edge1.End.Position;
                cos *= -1;
                sin *= -1;
            }
            else if (Edge1.End == Edge2.Start && Edge1.End == moved)
            {
                pivot = moved.Position;
                toRotateOther = moved.Position;
                pivotOther = Edge1.Start == other ? Edge2.End.Position : Edge1.Start.Position;
            }
            else if (Edge1.Start == Edge2.End && Edge1.End == moved)
            {
                pivot = Edge1.Start.Position;
                pivotOther = Edge1.End.Position;
                toRotateOther = Edge2.Start == other ? Edge2.End.Position : Edge2.Start.Position;
            }
            else if (Edge1.End == Edge2.Start && Edge2.End == moved)
            {
                pivot = Edge2.Start.Position;
                pivotOther = Edge2.End.Position;
                toRotateOther = Edge1.Start == other ? Edge1.End.Position : Edge1.Start.Position;
                cos *= -1;
                sin *= -1;
            }
            else if (Edge1.Start == Edge2.End && Edge2.Start == moved)
            {
                pivot = Edge1.Start.Position;
                pivotOther = Edge2.Start.Position;
                toRotateOther = Edge1.End == other ? Edge1.Start.Position : Edge1.End.Position;
                cos *= -1;
                sin *= -1;
            }
            else if (Edge1.End == Edge2.Start && Edge1.Start == moved)
            {
                pivot = Edge2.Start.Position;
                pivotOther = Edge1.Start.Position;
                toRotateOther = Edge2.End == other ? Edge2.Start.Position : Edge2.End.Position;
            }
            else if (Edge1.Start == moved)
            {
                pivot = moved.Position;
                pivotOther = Edge1.End.Position;
                toRotateOther = Edge2.Start == other ? Edge2.End.Position : Edge2.Start.Position;
                cos *= -1;
                sin *= -1;
            }
            else if (Edge2.Start == moved)
            {
                pivot = moved.Position;
                pivotOther = Edge2.End.Position;
                toRotateOther = Edge1.Start == other ? Edge1.End.Position : Edge1.Start.Position;
            }
            else if (Edge1.End == moved)
            {
                pivot = moved.Position;
                pivotOther = Edge1.Start.Position;
                toRotateOther = Edge2.Start == other ? Edge2.End.Position : Edge2.Start.Position;
                cos *= -1;
                sin *= -1;
            }
            else if (Edge2.End == moved)
            {
                pivot = moved.Position;
                pivotOther = Edge2.Start.Position;
                toRotateOther = Edge1.Start == other ? Edge1.End.Position : Edge1.Start.Position;
            }

            var edgePivot = ToVector(pivot, pivotOther); 
            var edgeRotated = ToVector(toRotateOther, toRotate);

            var l1 = Length(edgePivot, new PointF());
            var l2 = Length(edgeRotated, new PointF());

            sin *= CrossProduct(edgePivot, edgeRotated) / (l1 * l2);
            cos *= DotProduct(edgePivot, edgeRotated) / (l1 * l2);

            var rotation = new PointF(edgeRotated.X * sin - edgeRotated.X - edgeRotated.Y * cos, edgeRotated.Y * sin - edgeRotated.Y + edgeRotated.X * cos);

            return rotation;
        }

        private float Length(PointF a, PointF b) => (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
    }
}
