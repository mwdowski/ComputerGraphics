using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.FigureDrawers;
using P2_TrianglesFilling.FigureDrawers;

namespace P2_TrianglesFilling.Model
{
    public class Vertex : Figure
    {
        public Vector3 Position { get; set; }

        public Vertex(Vector3 position)
        {
            Position = position;
        }

        public override string ToString()
        {
            return Position.ToString();
        }

        public override void Draw(Graphics graphics, ICanvas canvas, IFigureDrawer drawer, FigureDrawerArguments argument)
        {
            drawer.DrawVertex(graphics, canvas, this, argument);
        }
    }
}
