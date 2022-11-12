using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.ColorProviders;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.FigureDrawers
{
    public class OrthogonalRandomColorFillDrawer : BaseOrthogonalWithoutNormalsFigureDrawer
    {
        public OrthogonalRandomColorFillDrawer(Rasterizer rasterizer) : base(rasterizer)
        {
        }

        public override void DrawPolygon(Graphics graphics, ICanvas canvas, Polygon polygon, FigureDrawerArguments _)
        {
            Algorithms.FillPolygon(
                canvas,
                polygon
                    .Vertices
                    .Select(_ => Rasterizer.Rasterize(Orthogonal(_.Position)))
                    .ToList(),
                new ConstantColorProvider(GetRandomColor())
            );
        }

        private Random random = new();
        private Color GetRandomColor()
        {
            return Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }
    }
}
