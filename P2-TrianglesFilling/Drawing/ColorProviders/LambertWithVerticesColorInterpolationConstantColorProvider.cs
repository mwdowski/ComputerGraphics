using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Drawing.BarycentricInterpolation;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Model;
using System.Numerics;

namespace P2_TrianglesFilling.Drawing.ColorProviders
{
    public class LambertWithVerticesColorInterpolationConstantColorProvider : ConstantColorProvider
    {
        private readonly FigureDrawerArguments _arguments;
        private readonly PolygonWithNormals _polygonWithNormals;
        private readonly Rasterizer _rasterizer;
        private readonly BarycentricTriangleInterpolator<Color> _colorInterpolator;

        public LambertWithVerticesColorInterpolationConstantColorProvider(
            Color color,
            FigureDrawerArguments arguments,
            PolygonWithNormals polygonWithNormals,
            Rasterizer rasterizer) : base(color)
        {
            _arguments = arguments;
            _polygonWithNormals = polygonWithNormals;
            _rasterizer = rasterizer;
            _colorInterpolator = new BarycentricTriangleInterpolator<Color>(
                _rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[0].Position), Color.AliceBlue,
                _rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[1].Position), Color.AliceBlue,
                _rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[2].Position), Color.AliceBlue,
                new ColorVectorOperationsExecutor()
            );
        }

        public override Color GetColor(int x, int y)
        {
            return _colorInterpolator.GetWeightInPoint(new Point(x, y));
        }
    }
}
