using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.FigureDrawers;

namespace P2_TrianglesFilling.Model
{
    public abstract class Figure
    {
        public abstract void Draw(Graphics graphics, ICanvas canvas, IFigureDrawer drawer, FigureDrawerArguments argument);
    }
}
