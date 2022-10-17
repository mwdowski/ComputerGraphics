using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Logic.LineDrawingMethods;
using P1_Polygons.Model;
using System.Diagnostics;

namespace P1_Polygons.Logic.MainLogic
{
    public class ProgramLogic
    {
        private Figure? _selectedFigure;
        private const int searchRadius = 20;
        public Rasterizer Rasterizer { get; }
        public FigureDrawer FigureDrawer { get; }
        public PolygonCreator PolygonCreator { get; }
        public List<Polygon> Polygons { get; private set; }

        public ProgramLogic(PictureBox canvas)
        {
            Rasterizer = new(canvas);
            FigureDrawer = new(Rasterizer);
            PolygonCreator = new(Rasterizer);
            Polygons = new List<Polygon>();
        }

        public void AddVertexOnEdge(Edge edge)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public void ChangeLineDrawingMethod(ILineDrawingMethod lineDrawingMethod)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public void DeleteEdge(Edge edge)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public void DeletePolygon(Polygon polygon)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public void DeleteVertex(Vertex vertex)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public Figure? GetPointedFigure(Point position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            return null;
        }

        public void Redraw()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public void FinishCreatingPolygon(Point position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public void FinishCreatingPolygon()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public void AddEdgeRestriction<T>(Edge edge) where T : IEdgeRestriction
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public void RemoveEdgeRestriction<T>(Edge edge) where T : IEdgeRestriction
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public void SetSelectedFigure(Figure? figure)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            _selectedFigure = figure;
        }

        public void MoveSelectedFigureBy(Point vector)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}: {vector}");
            _selectedFigure?.MoveBy(vector);
        }

        public void MoveSelectedFigureTo(Point position)
        {
            throw new NotImplementedException();
        }
    }
}
