using ObjLoader.Loader.Data.VertexData;
using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Algorithms;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.ColorProviders;
using P2_TrianglesFilling.Drawing.FigureDrawers;
using P2_TrianglesFilling.FigureDrawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Model
{
    public class FigureWithCloud : Figure
    {
        private Figure _innerFigure;
        private Polygon _cloud;
        private readonly Rasterizer rasterizer;
        private const float scale = 0.2f;
        private const float homothetyScale = (1 - scale);

        public FigureWithCloud(Figure innerFigure, Polygon cloud, Rasterizer rasterizer)
        {
            _innerFigure = innerFigure;
            _cloud = cloud;
            this.rasterizer = rasterizer;
        }

        public override void Draw(Graphics graphics, ICanvas canvas, IFigureDrawer drawer, FigureDrawerArguments argument)
        {
            _innerFigure.Draw(graphics, canvas, drawer, argument);

            var cloudHeight = argument.L.Z * scale;

            var tempCloud = new Polygon();
            tempCloud.Vertices.AddRange(_cloud.Vertices.Select(v => new Vertex(new Vector3(v.Position.X + argument.cloud_offset, v.Position.Y, cloudHeight))));

            var cloudShadow = new Polygon();
            cloudShadow.Vertices.AddRange(
                tempCloud
                    .Vertices
                    .Select(v => new Vertex(
                        new Vector3(
                            Homothety(v.Position.X, homothetyScale, argument.L.X),
                            Homothety(v.Position.Y, homothetyScale, argument.L.Y),
                            0)))
            );

            cloudShadow.Draw(graphics, canvas, drawer, argument);

            PolygonFilling.FillPolygon(canvas, cloudShadow.Vertices.Select(_ => rasterizer.RasterizeOrthogonaly(_.Position)).ToList(), new ConstantColorProvider(Color.FromArgb(255, 10, 10, 10)));

            tempCloud.Draw(graphics, canvas, drawer, argument);
        }

        private static float Homothety(float point, float scale, float anchor)
        {
            return (point - anchor) * 1/scale + anchor;
        }
    }
}
