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

        public string Symbol => "L";

        public LengthRestritcion(Edge edge, float length)
        {
            Edge = edge;
            Length = length;
        }

        public void Consider(Vertex movedVertex)
        {
            movedVertex.Position = CorrectedPosition(movedVertex);
        }

        private PointF CorrectedPosition(Vertex movedVertex)
        {
            Vertex otherVertex = Edge.Start == movedVertex ? Edge.End : Edge.Start;

            float ratio = Edge.Length;
            float newX = otherVertex.Position.X + Length * (movedVertex.Position.X - otherVertex.Position.X) / ratio;
            float newY = otherVertex.Position.Y + Length * (movedVertex.Position.Y - otherVertex.Position.Y) / ratio;

            return new PointF(newX, newY);
        }

        private PointF CorrectedVector(Vertex movedVertex, PointF vector)
        {
            Vertex otherVertex = Edge.Start == movedVertex ? Edge.End : Edge.Start;

            var afterMovementVertexPosition = movedVertex.Position;
            afterMovementVertexPosition.X += vector.X;
            afterMovementVertexPosition.Y += vector.Y;

            float ratio = Edge.Length;
            float newX = otherVertex.Position.X + Length * (afterMovementVertexPosition.X - otherVertex.Position.X) / ratio;
            float newY = otherVertex.Position.Y + Length * (afterMovementVertexPosition.Y - otherVertex.Position.Y) / ratio;

            return new PointF(newX - movedVertex.Position.X, newY - movedVertex.Position.Y);
        }

        public PointF CorrectedVectorForVertexMovement(PointF vector, Vertex movedVertex)
        {
            var incomingLengthRestriction = movedVertex.Incoming?.EdgeRestrictions.SingleOrDefault(_ => _.GetType() == this.GetType());
            var outgoingLengthRestriction = movedVertex.Outgoing?.EdgeRestrictions.SingleOrDefault(_ => _.GetType() == this.GetType());
            if (incomingLengthRestriction == null && outgoingLengthRestriction == null)
            {
                return vector;
            }
            else if (incomingLengthRestriction != null && outgoingLengthRestriction == null)
            {
                return CorrectedVector(movedVertex, vector);
            }
            else if (incomingLengthRestriction == null && outgoingLengthRestriction != null)
            {
                return CorrectedVector(movedVertex, vector);
            }
            else if (incomingLengthRestriction != null && outgoingLengthRestriction != null)
            {
                return new PointF(0, 0);
            }

            throw new NotImplementedException();
        }

        public (PointF vector, List<Figure> moveSet) CorrectedVectorForEdgeMovement(PointF vector, Edge movedEdge)
        {
            var incomingLengthRestriction = movedEdge.Start.Incoming?.EdgeRestrictions.SingleOrDefault(_ => _.GetType() == this.GetType());
            var outgoingLengthRestriction = movedEdge.End.Outgoing?.EdgeRestrictions.SingleOrDefault(_ => _.GetType() == this.GetType());
            
            var moveSet = new List<Figure>();
            moveSet.Add(movedEdge.Start);
            moveSet.Add(movedEdge.End);

            if (incomingLengthRestriction == null && outgoingLengthRestriction == null)
            {
                return (vector, moveSet);
            }
            else if (incomingLengthRestriction != null && outgoingLengthRestriction == null)
            {
                return (vector, GetRestrictedEdgesChainStart(movedEdge, moveSet));
            }
            else if (incomingLengthRestriction == null && outgoingLengthRestriction != null)
            {
                return (vector, GetRestrictedEdgesChainEnd(movedEdge, moveSet));
            }
            else if (incomingLengthRestriction != null && outgoingLengthRestriction != null)
            {
                return (vector, GetRestrictedEdgesChainStart(movedEdge, moveSet).Concat(GetRestrictedEdgesChainEnd(movedEdge, moveSet)).ToList());
            }

            throw new NotImplementedException();
        }

        // TODO: cleanup of dupliucate code
        public static (PointF vector, List<Figure> moveSet) CorrectedVectorAndSetForEdgeMovement(PointF vector, Edge movedEdge)
        {
            var incomingLengthRestriction = movedEdge.Start.Incoming?.EdgeRestrictions.SingleOrDefault(_ => _.GetType() == typeof(LengthRestritcion));
            var outgoingLengthRestriction = movedEdge.End.Outgoing?.EdgeRestrictions.SingleOrDefault(_ => _.GetType() == typeof(LengthRestritcion));

            var moveSet = new List<Figure>();
            moveSet.Add(movedEdge.Start);
            moveSet.Add(movedEdge.End);

            if (incomingLengthRestriction == null && outgoingLengthRestriction == null)
            {
                return (vector, moveSet);
            }
            else if (incomingLengthRestriction != null && outgoingLengthRestriction == null)
            {
                return (vector, GetRestrictedEdgesChainStart(movedEdge, moveSet));
            }
            else if (incomingLengthRestriction == null && outgoingLengthRestriction != null)
            {
                return (vector, GetRestrictedEdgesChainEnd(movedEdge, moveSet));
            }
            else if (incomingLengthRestriction != null && outgoingLengthRestriction != null)
            {
                return (vector, GetRestrictedEdgesChainStart(movedEdge, moveSet).Concat(GetRestrictedEdgesChainEnd(movedEdge, moveSet)).ToList());
            }

            throw new NotImplementedException();
        }

        private static List<Figure> GetRestrictedEdgesChainStart(Edge edge, List<Figure> moveSet)
        {
            var edgeIncomingToStart = edge.Start.Incoming;

            if (edgeIncomingToStart?.Start == moveSet.FirstOrDefault())
            {
                return moveSet;
            }

            var incomingLengthRestriction = edgeIncomingToStart?.EdgeRestrictions.SingleOrDefault(_ => _.GetType() == typeof(LengthRestritcion));

            if (incomingLengthRestriction != null)
            {
                moveSet.Add(edgeIncomingToStart?.Start);
            }
            return GetRestrictedEdgesChainStart(edgeIncomingToStart, moveSet);
        }

        private static List<Figure> GetRestrictedEdgesChainEnd(Edge edge, List<Figure> moveSet)
        {
            var edgeOutgoingFromEnd = edge.End.Outgoing;

            if (edgeOutgoingFromEnd == null)
            {
                return moveSet;
            }

            if (edgeOutgoingFromEnd.End == moveSet.FirstOrDefault())
            {
                return moveSet;
            }

            var incomingLengthRestriction = edgeOutgoingFromEnd?.EdgeRestrictions.SingleOrDefault(_ => _.GetType() == typeof(LengthRestritcion));

            if (incomingLengthRestriction != null)
            {
                moveSet.Add(edgeOutgoingFromEnd.End);
            }
            return GetRestrictedEdgesChainEnd(edgeOutgoingFromEnd, moveSet);
        }

        public void Initiate(Edge edge)
        {
            edge.EdgeRestrictions.Add(this);
            edge.End.MoveBy(CorrectedVectorForVertexMovement(new PointF(0, 0), edge.End));
            edge.Start.MoveBy(CorrectedVectorForVertexMovement(new PointF(0, 0), edge.Start));
        }
    }
}
