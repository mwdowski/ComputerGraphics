using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.EdgeRestrictions
{
    public class PerpendicularityRestriction : IEdgeRestriction
    {
        public string Symbol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Consider(Vertex movedVertex)
        {
            throw new NotImplementedException();
        }

        public PointF CorrectedVectorForEdgeMovement(PointF vector, Edge movedEdge)
        {
            throw new NotImplementedException();
        }

        public PointF CorrectedVectorForVertexMovement(PointF vector, Vertex movedVertex)
        {
            throw new NotImplementedException();
        }

        public void Initiate(Edge edge)
        {
            throw new NotImplementedException();
        }

        (PointF vector, List<Figure> moveSet) IEdgeRestriction.CorrectedVectorForEdgeMovement(PointF vector, Edge movedEdge)
        {
            throw new NotImplementedException();
        }
    }
}
