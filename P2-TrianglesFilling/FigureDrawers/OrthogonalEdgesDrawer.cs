using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Model;
using System.Numerics;

namespace P2_TrianglesFilling.FigureDrawers
{
    public class OrthogonalEdgesDrawer : BaseOrthogonalWithoutNormalsFigureDrawer
    {
        public OrthogonalEdgesDrawer(Rasterizer rasterizer) : base(rasterizer)
        {
        }

        public override void DrawPolygon(Graphics graphics, ICanvas canvas, Polygon polygon, FigureDrawerArgument _)
        {
            graphics.DrawPolygon(
                Pen,
                polygon
                    .Vertices
                    .Select(vertex => Rasterizer.Rasterize(Orthogonal(vertex.Position)))
                    .ToArray()
            );
        }
    }
}
