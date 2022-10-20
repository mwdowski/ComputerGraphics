using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Controls
{
    public class VertexContextMenuStrip : ContextMenuStrip
    {
        public Vertex Vertex { get; }
        public VertexContextMenuStrip(Vertex vertex) : base()
        {
            Vertex = vertex;
            Items.Add("Vertex");
            Items.Add("Remove", null, (_, _) => vertex.Remove());
        }
    }
}
