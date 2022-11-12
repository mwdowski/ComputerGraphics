using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.FigureDrawers;

namespace P2_TrianglesFilling.Model
{
    public class PolygonSetWithNormals : PolygonSet<PolygonWithNormals>
    {
        public List<Vertex> Normals { get; private set; }

        public PolygonSetWithNormals() : base()
        {
            Normals = new();
        }

        public override void Draw(Graphics graphics, ICanvas canvas, IFigureDrawer drawer, FigureDrawerArguments argument)
        {
            drawer.DrawPolygonSetWithNormals(graphics, canvas, this, argument);
        }
    }
}
