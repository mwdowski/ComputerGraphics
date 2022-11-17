using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Drawing.BarycentricInterpolation;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Model;
using P2_TrianglesFilling.Algorithms;

namespace P2_TrianglesFilling.Drawing.ColorProviders
{
    public class LambertWithVerticesColorInterpolationConstantColorProvider : IColorProvider
    {
        private readonly BarycentricTriangleInterpolator<ColorEvaluationChain, Color> _colorInterpolator;

        public LambertWithVerticesColorInterpolationConstantColorProvider(
            Color color,
            FigureDrawerArguments arguments,
            PolygonWithNormals polygonWithNormals,
            Rasterizer rasterizer)
        {
            _colorInterpolator = new(
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[0].Position),
                LambertLightModel.GetLambertColor(color, arguments.I_L, polygonWithNormals.Normals[0].Position,
                    arguments.L - polygonWithNormals.Vertices[0].Position, arguments.m, arguments.k_d, arguments.k_s),
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[1].Position),
                LambertLightModel.GetLambertColor(color, arguments.I_L, polygonWithNormals.Normals[1].Position,
                    arguments.L - polygonWithNormals.Vertices[1].Position, arguments.m, arguments.k_d, arguments.k_s),
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[2].Position),
                LambertLightModel.GetLambertColor(color, arguments.I_L, polygonWithNormals.Normals[2].Position,
                    arguments.L - polygonWithNormals.Vertices[2].Position, arguments.m, arguments.k_d, arguments.k_s)
            );
        }

        public Color GetColor(int x, int y)
        {
            return _colorInterpolator.GetWeightInPoint(new Point(x, y));
        }
    }
}
