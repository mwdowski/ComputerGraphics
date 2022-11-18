using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Drawing.BarycentricInterpolation;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Model;
using P2_TrianglesFilling.Algorithms;
using System.Numerics;

namespace P2_TrianglesFilling.Drawing.ColorProviders.OuterColorProviders
{
    public class LambertWithNormalsInterpolationConstantColorProvider : IOuterColorProvider
    {
        private readonly BarycentricTriangleInterpolator<Vector3EvaluationChain, Vector3> _normalsInterpolator;
        private readonly BarycentricTriangleInterpolator<Vector3EvaluationChain, Vector3> _positionInterpolator;
        private readonly IColorProvider _colorProvider;
        private readonly FigureDrawerArguments _arguments;
        private readonly Rasterizer _rasterizer;

        public LambertWithNormalsInterpolationConstantColorProvider(
            IColorProvider colorProvider,
            FigureDrawerArguments arguments,
            PolygonWithNormals polygonWithNormals,
            Rasterizer rasterizer)
        {
            _normalsInterpolator = new(
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[0].Position), polygonWithNormals.Normals[0].Position,
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[1].Position), polygonWithNormals.Normals[1].Position,
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[2].Position), polygonWithNormals.Normals[2].Position
            );
            _positionInterpolator = new(
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[0].Position), polygonWithNormals.Vertices[0].Position,
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[1].Position), polygonWithNormals.Vertices[1].Position,
                rasterizer.RasterizeOrthogonaly(polygonWithNormals.Vertices[2].Position), polygonWithNormals.Vertices[2].Position
            );
            _colorProvider = colorProvider;
            _arguments = arguments;
            _rasterizer = rasterizer;
        }

        public Color GetColor(int x, int y)
        {
            return LambertLightModel.GetLambertColor(
                _colorProvider.GetColor(x, y),
                _arguments.I_L,
                _normalsInterpolator.GetWeightInPoint(new Point(x, y)),
                _arguments.L - _positionInterpolator.GetWeightInPoint(new Point(x, y)),
                _arguments.m,
                _arguments.k_d,
                _arguments.k_s
            );

        }

        public void SetInnerColorProvider(IColorProvider colorProvider)
        {
            throw new NotImplementedException();
        }
    }
}
