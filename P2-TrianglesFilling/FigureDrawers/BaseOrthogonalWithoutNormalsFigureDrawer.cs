using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.FigureDrawers
{
    public abstract class BaseOrthogonalWithoutNormalsFigureDrawer : IFigureDrawer
    {
        protected Pen Pen = new Pen(Brushes.Black);
        protected Rasterizer Rasterizer;

        public BaseOrthogonalWithoutNormalsFigureDrawer(Rasterizer rasterizer)
        {
            Rasterizer = rasterizer;
        }

        protected static PointF Orthogonal(Vector3 vector)
        {
            var res = new PointF(vector.X, vector.Y);
            return res;
        }

        public abstract void DrawPolygon(Graphics graphics, ICanvas canvas, Polygon polygon, FigureDrawerArguments _);

        public void DrawPolygonSet<TPolygon>(Graphics graphics, ICanvas canvas, PolygonSet<TPolygon> polygonSet, FigureDrawerArguments _) where TPolygon : Polygon
        {
            foreach (var polygon in polygonSet.Polygons)
            {
                polygon.Draw(graphics, canvas, this, _);
            }
        }

        public void DrawPolygonSetWithNormals(Graphics graphics, ICanvas canvas, PolygonSetWithNormals polygonSetWithNormals, FigureDrawerArguments _)
        {
            foreach (var polygon in polygonSetWithNormals.Polygons)
            {
                polygon.Draw(graphics, canvas, this, _);
            }
        }

        public void DrawPolygonWithNormals(Graphics graphics, ICanvas canvas, PolygonWithNormals polygonWithNormals, FigureDrawerArguments _)
        {
            DrawPolygon(graphics, canvas, polygonWithNormals, _);
        }

        public void DrawVertex(Graphics graphics, ICanvas canvas, Vertex vertex, FigureDrawerArguments _)
        {
        }
    }
}
