using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Drawing.BarycentricInterpolation;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Model;
using P2_TrianglesFilling.Algorithms;
using System.Numerics;

namespace P2_TrianglesFilling.Drawing.ColorProviders
{
    public class LambertWithNormalsInterpolationColorProvider : IColorProvider
    {
        protected readonly BarycentricTriangleInterpolator<Vector3EvaluationChain, Vector3> NormalsInterpolator;
        protected readonly BarycentricTriangleInterpolator<Vector3EvaluationChain, Vector3> PositionInterpolator;
        protected readonly IColorProvider ColorProvider;
        protected readonly FigureDrawerArguments Arguments;
        protected readonly Rasterizer Rasterizer;

        public LambertWithNormalsInterpolationColorProvider(
            IColorProvider colorProvider,
            FigureDrawerArguments arguments,
            PolygonWithNormals polygonWithNormals,
            Rasterizer rasterizer)
        {
            NormalsInterpolator = new(
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[0].Position), polygonWithNormals.Normals[0].Position,
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[1].Position), polygonWithNormals.Normals[1].Position,
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[2].Position), polygonWithNormals.Normals[2].Position
            );
            PositionInterpolator = new(
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[0].Position), polygonWithNormals.Vertices[0].Position,
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[1].Position), polygonWithNormals.Vertices[1].Position,
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[2].Position), polygonWithNormals.Vertices[2].Position
            );
            ColorProvider = colorProvider;
            Arguments = arguments;
            Rasterizer = rasterizer;
        }

        public virtual Color GetColor(int x, int y)
        {
            return LambertLightModel.GetLambertColor(
                ColorProvider.GetColor(x, y),
                Arguments.I_L,
                NormalsInterpolator.GetWeightInPoint(new Point(x, y)),
                Arguments.L - PositionInterpolator.GetWeightInPoint(new Point(x, y)),
                Arguments.m,
                Arguments.k_d,
                Arguments.k_s
            );

        }
    }
}
