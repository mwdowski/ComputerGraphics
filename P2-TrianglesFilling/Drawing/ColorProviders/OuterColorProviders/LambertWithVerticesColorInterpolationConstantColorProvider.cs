using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Drawing.BarycentricInterpolation;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Model;
using P2_TrianglesFilling.Algorithms;

namespace P2_TrianglesFilling.Drawing.ColorProviders.OuterColorProviders
{
    public class LambertWithVerticesColorInterpolationConstantColorProvider : IOuterColorProvider
    {
        private readonly BarycentricTriangleInterpolator<ColorEvaluationChain, Color> _colorInterpolator;

        public LambertWithVerticesColorInterpolationConstantColorProvider(
            IColorProvider colorProvider,
            FigureDrawerArguments arguments,
            PolygonWithNormals polygonWithNormals,
            Rasterizer rasterizer)
        {
            var p1 = rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[0].Position);
            var p2 = rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[1].Position);
            var p3 = rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[2].Position);
            _colorInterpolator = new(
                p1, LambertLightModel.GetLambertColor(colorProvider.GetColor(p1.X, p1.Y), arguments.I_L, polygonWithNormals.Normals[0].Position,
                arguments.L - polygonWithNormals.Vertices[0].Position, arguments.m, arguments.k_d, arguments.k_s),
                p2, LambertLightModel.GetLambertColor(colorProvider.GetColor(p2.X, p2.Y), arguments.I_L, polygonWithNormals.Normals[1].Position,
                arguments.L - polygonWithNormals.Vertices[1].Position, arguments.m, arguments.k_d, arguments.k_s),
                p3, LambertLightModel.GetLambertColor(colorProvider.GetColor(p3.X, p3.Y), arguments.I_L, polygonWithNormals.Normals[2].Position,
                arguments.L - polygonWithNormals.Vertices[2].Position, arguments.m, arguments.k_d, arguments.k_s)
            );
        }

        public Color GetColor(int x, int y)
        {
            return _colorInterpolator.GetWeightInPoint(new Point(x, y));
        }

        public void SetInnerColorProvider(IColorProvider colorProvider)
        {
            throw new NotImplementedException();
        }
    }
}
