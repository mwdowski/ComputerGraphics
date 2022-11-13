using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.ColorProviders;
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

        private Figure _figure = new PolygonSet<Polygon>();
        private ICanvas _canvas;

        private const float scale = 1f;

        public ProgramLogic(PictureBox canvasPanel)
        {
            _canvas = new DirectBitmapCanvas(canvasPanel);
            FigureLoader = new ObjFileLoader();
            Rasterizer = new Rasterizer(_canvas.Bitmap, scale);
            FigureDrawer = new LambertOneColorNormalPolygonFillDrawer(Rasterizer, Color.Red);

            LoadDefaultFigure();
            //DrawFigure();
        }

        private void LoadDefaultFigure()
        {
            var loadResult = FigureLoader.LoadFigureFromFile("Resources/proj2_sfera.obj");
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
                _figure?.Draw(graphics, _canvas, FigureDrawer, new FigureDrawerArguments()
                {
                    I_L = Color.Red,
                    k_d = 0.2f,
                    k_s = 0.2f,
                    L = new System.Numerics.Vector3(0, 10f, 10f),
                    m = 100
                });
            }
            _canvas.Refresh();

            Console.WriteLine(DateTime.Now - startTime);

        }
    }
}
