using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Algorithms;
using P2_TrianglesFilling.Drawing.NormalMapping;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Model;

namespace P2_TrianglesFilling.Drawing.ColorProviders
{
    internal class LambertWithNormalsInterpolationAndMappingColorProvider : LambertWithNormalsInterpolationColorProvider
    {
        private readonly INormalMapApplier normalMapApplier;

        public LambertWithNormalsInterpolationAndMappingColorProvider(
            IColorProvider colorProvider,
            FigureDrawerArguments arguments,
            PolygonWithNormals polygonWithNormals,
            Rasterizer rasterizer,
            INormalMapApplier normalMapApplier) : base(colorProvider, arguments, polygonWithNormals, rasterizer)
        {
            this.normalMapApplier = normalMapApplier;
        }

        public override Color GetColor(int x, int y)
        {
            return LambertLightModel.GetLambertColor(
                ColorProvider.GetColor(x, y),
                Arguments.I_L,
                normalMapApplier.MapNormal(NormalsInterpolator.GetWeightInPoint(new Point(x, y)), x, y),
                Arguments.L - PositionInterpolator.GetWeightInPoint(new Point(x, y)),
                Arguments.m,
                Arguments.k_d,
                Arguments.k_s
            );
        }
    }
}
