using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.ColorProviders;
using P2_TrianglesFilling.Drawing.FigureDrawers;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Loaders;
using P2_TrianglesFilling.Model;
using System.Numerics;

namespace P2_TrianglesFilling.Logic
{
    public class ProgramLogic
    {
        public IFileFigureLoader FigureLoader { get; private set; }
        public Rasterizer Rasterizer { get; private set; }
        public IFigureDrawer FigureDrawer { get; private set; }
        public ColorProviderCreator ColorProviderCreator { get; private set; }
        public LogicSettings LogicSettings { get; private set; }

        private Figure _figure = new PolygonSet<Polygon>();
        private ICanvas _canvas;
        public FigureDrawerArguments FigureDrawerArguments { get => SettingsToDrawingArguments(LogicSettings); }

        private const float scale = 1f;

        public Color ObjectColor { get; set; } = Color.Orange;

        public ProgramLogic(PictureBox canvasPanel, LogicSettings logicSettings)
        {
            LogicSettings = logicSettings;
            _canvas = new DirectBitmapCanvas(canvasPanel);
            FigureLoader = new ObjFileLoader();
            Rasterizer = new Rasterizer(_canvas.Bitmap, scale);
            ColorProviderCreator = new(Rasterizer);
            FigureDrawer = new LambertNormalPolygonFillDrawer(Rasterizer, ColorProviderCreator, logicSettings);

            LoadDefaultFigure();
            DrawFigure();
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

        private static FigureDrawerArguments SettingsToDrawingArguments(LogicSettings settings)
        {
            return new FigureDrawerArguments()
            {
                I_L = settings.LightColor,
                k_d = settings.KD,
                k_s = settings.KS,
                L = new Vector3(
                    (float)Math.Sin(settings.LightSourcePositionAngle) * settings.LightSourcePositionRadius,
                    (float)Math.Cos(settings.LightSourcePositionAngle) * settings.LightSourcePositionRadius, 
                    settings.LightSourcePositionHeight
                ),
                m = settings.M
            };
        } 
    }
}
