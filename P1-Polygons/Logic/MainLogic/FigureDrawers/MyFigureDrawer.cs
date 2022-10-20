using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int dx = rasterizedEnd.X - rasterizedStart.X;
            int dy = rasterizedEnd.Y - rasterizedStart.Y;
            int d = 2 * dy - dx;
            int incrE = 2 * dy;
            int incrNE = 2 * (dy - dx);
            int x = rasterizedStart.X;
            int y = rasterizedStart.Y;

            while (x < rasterizedEnd.X)
            {
                if (d < 0) //choose E
                {
                    d += incrE;
                    x++;
                }
                else //choose NE
                {
                    d += incrNE;
                    x++;
                    y++;
                }
                graphics.FillRectangle(Pen.Brush, x, y, 1, 1);
            }
        }
    }
}
