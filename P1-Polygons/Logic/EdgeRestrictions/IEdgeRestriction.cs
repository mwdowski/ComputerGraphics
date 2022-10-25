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
        int Order { get; }
        string Symbol { get; }
        void Initialize();
        public PointF CorrectingMovement(Vertex moved, Vertex other);
        void Remove();
    }
}
