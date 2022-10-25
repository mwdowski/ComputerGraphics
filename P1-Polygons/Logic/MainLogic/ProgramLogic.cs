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
        public List<Circle> Circles { get; private set; } = new List<Circle>();
        public CircleCreator CircleCreator { get; }

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
            CircleCreator = new(Rasterizer);

            CreatePredefinedScene();
            DrawScene();
        }

        private void CreatePredefinedScene()
        {
            PolygonCreator.StartPolygonCreation(new Point(100, 100));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(200, 150));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(200, 300));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(250, 400));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(400, 300));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(500, 200));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(300, 100));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(100, 100));
            Polygons.Add(PolygonCreator.GetCreatedPolygon());
            PolygonCreator.Restart();
            
            PolygonCreator.StartPolygonCreation(new Point(800, 100));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(750, 400));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(700, 450));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(500, 300));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(400, 250));
            PolygonCreator.AddVertexWhileCreatingPolygon(new Point(800, 100));
            Polygons.Add(PolygonCreator.GetCreatedPolygon());
            PolygonCreator.Restart();

            new LengthRestritcion(Polygons[0].Edges[0], 300).Initialize();
            new LengthRestritcion(Polygons[0].Edges[1], 700).Initialize();
            new LengthRestritcion(Polygons[1].Edges[1], 700).Initialize();
            new PerpendicularityRestriction(Polygons[0].Edges[4], Polygons[0].Edges[5]).Initialize();
            new PerpendicularityRestriction(Polygons[0].Edges[1], Polygons[1].Edges[3]).Initialize();
        }

        public void DrawScene()
        {
            using (var graphics = Graphics.FromImage(Rasterizer.Image))
            {
                graphics.Clear(Color.White);

                foreach (var polygon in Polygons)
                {
                    FigureDrawer.DrawPolygon(polygon, graphics);
                }
                PolygonCreator.DrawCurrentPolygon(FigureDrawer, graphics);
                
                foreach (var circle in Circles)
                {
                    FigureDrawer.DrawCircle(circle, graphics);
                }

                CircleCreator.Draw(graphics);
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

        public void DeleteCircle(Circle circle)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            Circles.Remove(circle);
        }
    }
}
