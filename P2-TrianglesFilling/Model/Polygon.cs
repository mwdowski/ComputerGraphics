using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.FigureDrawers;

namespace P2_TrianglesFilling.Model
{
    public class Polygon : Figure
    {
        public List<Vertex> Vertices { get; private set; }

        public Polygon()
        {
            Vertices = new();
        }

        public override void Draw(Graphics graphics, ICanvas canvas, IFigureDrawer drawer, FigureDrawerArgument argument)
        {
            drawer.DrawPolygon(graphics, canvas, this, argument);
        }
    }
}
