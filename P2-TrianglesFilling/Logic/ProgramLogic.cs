using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.ColorProviders;
using P2_TrianglesFilling.Drawing.ColorProviders.OuterColorProviders;
using P2_TrianglesFilling.Drawing.FigureDrawers;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Loaders;
using P2_TrianglesFilling.Model;

namespace P2_TrianglesFilling.Logic
{
    public class ProgramLogic
    {
        public IFileFigureLoader FigureLoader { get; private set; }
        public Rasterizer Rasterizer { get; private set; }
        public IFigureDrawer FigureDrawer { get; private set; }
        public IOuterColorProvider ColorProvider { get; private set; }
        public IColorProvider InnerColorProvider { get; private set; }

        private Figure _figure = new PolygonSet<Polygon>();
        private ICanvas _canvas;
        public FigureDrawerArguments FigureDrawerArguments { get; private set; } = new FigureDrawerArguments()
        {
            I_L = Color.White,
            k_d = 0.5f,
            k_s = 0.5f,
            L = new System.Numerics.Vector3(10f, 10f, 20f),
            m = 5
        };

        private const float scale = 1f;

        public Color ObjectColor { get; set; } = Color.Orange;

        public ProgramLogic(PictureBox canvasPanel)
        {
            _canvas = new DirectBitmapCanvas(canvasPanel);
            FigureLoader = new ObjFileLoader();
            Rasterizer = new Rasterizer(_canvas.Bitmap, scale);
            InnerColorProvider = new ConstantColorProvider(Color.Orange);
            ColorProvider = new LambertWithVerticesColorInterpolationConstantColorProvider(InnerColorProvider, )
            FigureDrawer = new LambertNormalPolygonFillDrawer(Rasterizer, ColorProvider);

            LoadDefaultFigure();
            DrawFigure();
        }

        private void LoadTriangle()
        {
            var polygon = new PolygonWithNormals();
            polygon.Vertices.AddRange(new List<Vertex>() { new Vertex(new System.Numerics.Vector3(-1, -0.5f, 0)), new Vertex(new System.Numerics.Vector3(1, -0.5f, 0)), new Vertex(new System.Numerics.Vector3(0, 1, 0)) });
            _figure = polygon;
        }

        private void LoadDefaultFigure()
        {
            var loadResult = FigureLoader.LoadFigureFromFile("Resources/Sphere.obj");
            if (loadResult == null)
            {
                MessageBox.Show("Could not load default figure", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _figure = loadResult;
            }
        }

        public void DrawFigure()
        {
            var startTime = DateTime.Now;
            using (var graphics = Graphics.FromImage(_canvas.Bitmap))
            {
                _figure?.Draw(graphics, _canvas, FigureDrawer, FigureDrawerArguments);
            }
            _canvas.Refresh();

            Console.WriteLine(DateTime.Now - startTime);
        }

        public void SetObjectColor(Color color)
        {
            ColorProvider = new LambertNormalPolygonFillDrawer(Rasterizer, new ConstantColorProvider(color));
        }

        public void SetObjectImage(Bitmap bitmap)
        {
            FigureDrawer = new LambertNormalPolygonFillDrawer(Rasterizer, new FromBitmapColorProvider(bitmap));
        }
    }
}
