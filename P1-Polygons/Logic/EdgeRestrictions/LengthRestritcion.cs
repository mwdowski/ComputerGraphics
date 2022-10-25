using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.EdgeRestrictions
{
    public class LengthRestritcion : IEdgeRestriction
    {
        public Edge Edge { get; }
        public float Length { get; }

        public string Symbol => "L";

        public int Order => 1;

        public LengthRestritcion(Edge edge, float length)
        {
            Edge = edge;
            Length = length;
        }

        public void Initialize()
        {
            Edge.EdgeRestrictions.Add(this);
            Edge.End.MoveByConsideringRestrictions(new PointF(0, 0));
            Edge.Start.MoveByConsideringRestrictions(new PointF(0, 0));
        }

        public PointF CorrectingMovement(Vertex moved, Vertex other)
        {
            var afterMovementVertexPosition = moved.Position;

            float ratio = Edge.Length;
            float newX = afterMovementVertexPosition.X + Length * (other.Position.X - afterMovementVertexPosition.X) / ratio;
            float newY = afterMovementVertexPosition.Y + Length * (other.Position.Y - afterMovementVertexPosition.Y) / ratio;

            return new PointF(newX - other.Position.X, newY - other.Position.Y);
        }
    }
}
