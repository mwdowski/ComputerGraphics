using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.MainLogic
{
    public class FigureDrawer
    {
        private static Pen pen = new Pen(Color.Black, 1);
        private static int radius = 4;
        public Rasterizer Rasterizer { get; }

        public FigureDrawer(Rasterizer rasterizer)
        {
            Rasterizer = rasterizer;
        }

        public void DrawVertex(Vertex vertex, Graphics graphics)
        {
            var rasterizedPosition = Rasterizer.Rasterize(vertex.Position);
            var vertexPaintRect = new Rectangle(
                rasterizedPosition.X - radius,
                rasterizedPosition.Y - radius,
                radius * 2,
                radius * 2);

            graphics.FillEllipse(pen.Brush, vertexPaintRect);
        }

        public void DrawEdge(Edge edge, Graphics graphics)
        {
            graphics.DrawLine(pen, Rasterizer.Rasterize(edge.Start.Position), Rasterizer.Rasterize(edge.End.Position));
        }

        public void DrawPolygon(Polygon polygon, Graphics graphics)
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
