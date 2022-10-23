using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.EdgeRestrictions
{
    public class LengthRestritcion : IEdgeRestriction
    {
        public Edge Edge { get; }
        public float Length { get; }
        public LengthRestritcion(Edge edge, float length)
        {
            Edge = edge;
            Length = length;
        }

        public void Consider(Vertex movedVertex)
        {
            Vertex otherVertex = Edge.Start == movedVertex ? Edge.End : Edge.Start;

            float ratio = Edge.Length;
            float newX = otherVertex.Position.X + Length * (movedVertex.Position.X - otherVertex.Position.X) / ratio;
            float newY = otherVertex.Position.Y + Length * (movedVertex.Position.Y - otherVertex.Position.Y) / ratio;

            movedVertex.Position.X = newX;
            movedVertex.Position.Y = newY;
        }
    }
}
