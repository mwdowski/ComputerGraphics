using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.ColorProviders;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Logic;
using P2_TrianglesFilling.Model;

namespace P2_TrianglesFilling.Drawing.FigureDrawers
{
    public class LambertNormalPolygonFillDrawer : IFigureDrawer
    {
        protected Rasterizer Rasterizer;
        private readonly LogicSettings logicSettings;

        public ColorProviderCreator ColorProviderCreator { get; set; }

        public LambertNormalPolygonFillDrawer(Rasterizer rasterizer, ColorProviderCreator colorProviderCreator, LogicSettings logicSettings)
        {
            Rasterizer = rasterizer;
            ColorProviderCreator = colorProviderCreator;
            this.logicSettings = logicSettings;
        }

        public void DrawPolygon(Graphics graphics, ICanvas canvas, Polygon polygon, FigureDrawerArguments argument)
        {
            throw new NotImplementedException();
        }

        public void DrawPolygonSet<TPolygon>(Graphics graphics, ICanvas canvas, PolygonSet<TPolygon> polygonSet, FigureDrawerArguments argument) where TPolygon : Polygon
        {
            throw new NotImplementedException();
        }

        public void DrawPolygonSetWithNormals(Graphics graphics, ICanvas canvas, PolygonSetWithNormals polygonSetWithNormals, FigureDrawerArguments argument)
        {
            foreach (var polygon in polygonSetWithNormals.Polygons)
            {
                polygon.Draw(graphics, canvas, this, argument);
            }
        }

        public void DrawPolygonWithNormals(Graphics graphics, ICanvas canvas, PolygonWithNormals polygonWithNormals, FigureDrawerArguments argument)
        {
            Algorithms.PolygonFilling.FillPolygon(
                canvas,
                polygonWithNormals
                    .Vertices
                    .Select(_ => Rasterizer.RasterizeOrthogonaly(_.Position))
                    .ToList(),
                ColorProviderCreator.GetColorProvider(argument, logicSettings, polygonWithNormals)
            );
        }

        public void DrawVertex(Graphics graphics, ICanvas canvas, Vertex vertex, FigureDrawerArguments argument)
        {
            return;
        }
    }
}
