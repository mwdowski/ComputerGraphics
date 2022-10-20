using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Controls
{
    public class EdgeContextMenuStrip : ContextMenuStrip
    {
        public Edge Edge { get; }
        public EdgeContextMenuStrip(Edge edge) : base()
        {
            Edge = edge;
            Items.Add("Edge");
            Items.Add("Remove", null, (_, _) => edge.Remove());
            Items.Add("Add vertex in the middle", null, (_, _) => edge.DivideEdgeWithVertexOnMiddle());
        }
    }
}
