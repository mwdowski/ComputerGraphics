using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.MainLogic.FigureDrawers
{
    public class FigureDrawer
    {
        protected static Pen Pen = new Pen(Color.Black, 1);
        protected static int Radius = 4;
        public Rasterizer Rasterizer { get; }

        public FigureDrawer(Rasterizer rasterizer)
        {
            Rasterizer = rasterizer;
        }

        public virtual void DrawVertex(Vertex vertex, Graphics graphics)
        {
            var rasterizedPosition = Rasterizer.Rasterize(vertex.Position);
            var vertexPaintRect = new Rectangle(
                rasterizedPosition.X - Radius,
                rasterizedPosition.Y - Radius,
                Radius * 2,
                Radius * 2);

            graphics.FillEllipse(Pen.Brush, vertexPaintRect);
        }

        public virtual void DrawEdge(Edge edge, Graphics graphics)
        {
            graphics.DrawLine(Pen, Rasterizer.Rasterize(edge.Start.Position), Rasterizer.Rasterize(edge.End.Position));
            graphics.DrawString(edge.RestrictionString, new Font("Arial", 12), Pen.Brush, Rasterizer.Rasterize((edge.Center)));
        }

        public virtual void DrawPolygon(Polygon polygon, Graphics graphics)
        {
            foreach (var e in polygon.Edges)
            {
                DrawEdge(e, graphics);
            }
            foreach (var v in polygon.Vertices)
            {
                DrawVertex(v, graphics);
            }
        }
    }
}
