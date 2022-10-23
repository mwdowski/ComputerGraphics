using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.EdgeRestrictions
{
    public interface IEdgeRestriction
    {
        string Symbol { get; }

        void Consider(Vertex movedVertex);
        void Initiate(Edge edge);
        PointF CorrectedVectorForVertexMovement(PointF vector, Vertex movedVertex);
        (PointF vector, List<Figure> moveSet) CorrectedVectorForEdgeMovement(PointF vector, Edge movedEdge);
    }
}
