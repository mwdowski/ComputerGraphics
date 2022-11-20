using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Algorithms;
using P2_TrianglesFilling.Drawing.NormalMapping;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.ColorProviders
{
    public class LambertWithVerticesColorInterpolationAndNormalMappingColorProvider : LambertWithVerticesColorInterpolationColorProvider
    {
        public LambertWithVerticesColorInterpolationAndNormalMappingColorProvider(
            IColorProvider colorProvider,
            FigureDrawerArguments arguments,
            PolygonWithNormals polygonWithNormals,
            Rasterizer rasterizer,
            INormalMapApplier normalMapApplier) : base(colorProvider, arguments, polygonWithNormals, rasterizer)
        {
            var p1 = rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[0].Position);
            var p2 = rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[1].Position);
            var p3 = rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[2].Position);
            ColorInterpolator = new(
                p1,
                LambertLightModel.GetLambertColor(
                    colorProvider.GetColor(p1.X, p1.Y),
                    arguments.I_L,
                    normalMapApplier.MapNormal(polygonWithNormals.Normals[0].Position, p1.X, p1.Y),
                    arguments.L - polygonWithNormals.Vertices[0].Position,
                    arguments.m,
                    arguments.k_d,
                    arguments.k_s),
                p2,
                LambertLightModel.GetLambertColor(
                    colorProvider.GetColor(p2.X, p2.Y),
                    arguments.I_L,
                    normalMapApplier.MapNormal(polygonWithNormals.Normals[1].Position, p2.X, p2.Y),
                    arguments.L - polygonWithNormals.Vertices[1].Position,
                    arguments.m,
                    arguments.k_d,
                    arguments.k_s),
                p3,
                LambertLightModel.GetLambertColor(
                    colorProvider.GetColor(p3.X, p3.Y),
                    arguments.I_L,
                    normalMapApplier.MapNormal(polygonWithNormals.Normals[2].Position, p3.X, p3.Y),
                    arguments.L - polygonWithNormals.Vertices[2].Position,
                    arguments.m,
                    arguments.k_d,
                    arguments.k_s
                )
            );
        }
    }
}
