using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.FigureDrawers;
using P2_TrianglesFilling.FigureDrawers;

namespace P2_TrianglesFilling.Model
{
    public class PolygonSet<TPolygon> : Figure where TPolygon : Polygon
    {
        public List<TPolygon> Polygons { get; private set; }
        public List<Vertex> Vertices { get; private set; }

        public PolygonSet()
        {
            Polygons = new();
            Vertices = new();
        }

        public override void Draw(Graphics graphics, ICanvas canvas, IFigureDrawer drawer, FigureDrawerArguments argument)
        {
            drawer.DrawPolygonSet(graphics, canvas, this, argument);
        }
    }
}
