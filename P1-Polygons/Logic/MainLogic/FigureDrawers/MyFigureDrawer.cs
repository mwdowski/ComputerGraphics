using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P1_Polygons.Logic.MainLogic.FigureDrawers
{
    public class MyFigureDrawer : FigureDrawer
    {
        public MyFigureDrawer(Rasterizer rasterizer) : base(rasterizer)
        {
        }

        public override void DrawEdge(Edge edge, Graphics graphics)
        {
            var rasterizedStart = Rasterizer.Rasterize(edge.Start.Position);
            var rasterizedEnd = Rasterizer.Rasterize(edge.End.Position);
            int x = rasterizedStart.X;
            int y = rasterizedStart.Y;
            int dx = rasterizedEnd.X - rasterizedStart.X;
            int dy = rasterizedEnd.Y - rasterizedStart.Y;

            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (dx < 0) dx1 = -1; else if (dx > 0) dx1 = 1;
            if (dy < 0) dy1 = -1; else if (dy > 0) dy1 = 1;
            if (dx < 0) dx2 = -1; else if (dx > 0) dx2 = 1;

            int longest = Math.Abs(dx);
            int shortest = Math.Abs(dy);
            if (!(longest > shortest))
            {
                longest = Math.Abs(dy);
                shortest = Math.Abs(dx);
                if (dy < 0) dy2 = -1; else if (dy > 0) dy2 = 1;
                dx2 = 0;
            }
            int d = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                graphics.FillRectangle(Pen.Brush, x, y, 1, 1);
                d += shortest;
                if (!(d < longest))
                {
                    d -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }
    }
}
