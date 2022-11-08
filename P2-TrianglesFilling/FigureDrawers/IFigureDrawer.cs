using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.FigureDrawers
{
    public interface IFigureDrawer
    {
        public void DrawPolygon(Graphics graphics, ICanvas canvas, Polygon polygon, FigureDrawerArgument argument);
        public void DrawPolygonWithNormals(Graphics graphics, ICanvas canvas, PolygonWithNormals polygonWith, FigureDrawerArgument argument);
        public void DrawPolygonSetWithNormals(Graphics graphics, ICanvas canvas, PolygonSetWithNormals polygonSetWithNormals, FigureDrawerArgument argument);
        public void DrawPolygonSet<TPolygon>(Graphics graphics, ICanvas canvas, PolygonSet<TPolygon> polygonSet, FigureDrawerArgument argument) where TPolygon : Polygon;
        public void DrawVertex(Graphics graphics, ICanvas canvas, Vertex vertex, FigureDrawerArgument argument);
    }
}
