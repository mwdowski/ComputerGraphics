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

        public ProgramLogic(PictureBox canvasPanel, LogicSettings logicSettings)
        {
            LogicSettings = logicSettings;
            _canvas = new DirectBitmapCanvas(canvasPanel);
            FigureLoader = new ObjFileLoader();
            Rasterizer = new Rasterizer(_canvas.Bitmap, scale);
            ColorProviderCreator = new(Rasterizer);
            FigureDrawer = new LambertNormalPolygonFillDrawer(Rasterizer, ColorProviderCreator, logicSettings);
        }

        public void LoadFigureFromObj(string path)
        {
            var loadResult = FigureLoader.LoadFigureFromFile(path);
            if (loadResult == null)
            {
                MessageBox.Show("Could not load default figure", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _figure = loadResult;
            }

            _figure = new FigureWithCloud(_figure, GetDefaultCloud(), Rasterizer);
        }

        private Polygon GetDefaultCloud()
        {
            var res = new Polygon();

            res.Vertices.AddRange(new Vertex[]
            {
                new Vertex(new Vector3(0.3f, 0.3f, 0)),
                new Vertex(new Vector3(0.5f, 0.3f, 0)),
                new Vertex(new Vector3(0.4f, -0.5f, 0)),
                new Vertex(new Vector3(0.2f, -0.35f, 0)),
                new Vertex(new Vector3(-0.4f, -0.45f, 0)),
                new Vertex(new Vector3(-0.5f, -0.2f, 0)),
                new Vertex(new Vector3(-0.2f, 0.4f, 0)),
            });

            return res;
        }

        private void MoveCloud()
        {

        }

        public void DrawFigure()
        {
            var startTime = DateTime.Now;
            using (var graphics = Graphics.FromImage(_canvas.Bitmap))
            {
                graphics.Clear(Color.White);
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
                m = settings.M,
                cloud_offset = settings.CloudOffset,
            };
        } 
    }
}
