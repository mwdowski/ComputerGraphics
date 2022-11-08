using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Canvases;
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
            FigureDrawer = new OrthogonalEdgesDrawer(Rasterizer);

            LoadDefaultFigure();
            DrawFigure();
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

        private void DrawFigure()
        {
            using (var graphics = Graphics.FromImage(_canvas.Bitmap))
            {
                _figure?.Draw(graphics, _canvas, FigureDrawer, new FigureDrawerArgument());
            }
            _canvas.Refresh();
        }
    }
}
