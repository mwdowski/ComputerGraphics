using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.MainLogic
{
    public class FigureDrawer
    {
        public Rasterizer Rasterizer { get; }

        public FigureDrawer(Rasterizer rasterizer)
        {
            Rasterizer = rasterizer;
        }

        void DrawVertex(Vertex vertex)
        {
            // using drawing draw circle
        }

        void DrawEdge(Edge edge)
        {
            // using drawing draw circle
        }

        void DrawPolygon(Polygon polygon)
        {
            // draw vertices then edges
        }
    }
}
