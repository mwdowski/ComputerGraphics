using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Logic.LineDrawingMethods;
using P1_Polygons.Logic.MainLogic.FigureDrawers;
using P1_Polygons.Model;
using System.Diagnostics;

namespace P1_Polygons.Logic.MainLogic
{
    public class ProgramLogic
    {
        public Rasterizer Rasterizer { get; }
        public FigureDrawer FigureDrawer { get; set; }
        public PolygonCreator PolygonCreator { get; }
        public FigureSelector FigureSelector { get; }
        public FigureMover FigureMover { get; }
        public List<Polygon> Polygons { get; private set; }

        private PictureBox _pictureBox;

        public ProgramLogic(PictureBox canvas)
        {
            canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            Rasterizer = new(canvas);
            FigureDrawer = new(Rasterizer);
            FigureSelector = new(Rasterizer, this);
            PolygonCreator = new(Rasterizer);
            FigureMover = new(Rasterizer);
            Polygons = new List<Polygon>();
            _pictureBox = canvas;
        }

        public void DrawPolygons()
        {
            using (var graphics = Graphics.FromImage(Rasterizer.Image))
            {
                graphics.Clear(Color.White);

                foreach (var polygon in Polygons)
                {
                    FigureDrawer.DrawPolygon(polygon, graphics);
                }
                PolygonCreator.DrawCurrentPolygon(FigureDrawer, graphics);
            }

            _pictureBox.Refresh();
        }

        public void GetPolygonFromCreator()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            if (PolygonCreator.LastState == CreatingPolygonState.PolygonReady)
            {
                Polygons.Add(PolygonCreator.GetCreatedPolygon());
            }
        }

        public void DeletePolygon(Polygon polygon)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            Polygons.Remove(polygon);
        
        }
    }
}
