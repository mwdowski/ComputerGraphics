using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Logic.LineDrawingMethods;
using P1_Polygons.Model;
using System.Diagnostics;

namespace P1_Polygons.Logic.MainLogic
{
    public class DrawingLogic : IDrawingLogic
    {
        private readonly PictureBox _canvas;
        private Figure? _selectedFigure;
        private const float xMin = -100.0f;
        private const float xMax = 100.0f;
        private const float yMin = -100.0f;
        private const float yMax = 100.0f;
        private const int searchRadius = 20;

        public List<Polygon> Polygons { get; private set; }

        public DrawingLogic(PictureBox canvas)
        {
            _canvas = canvas;
            Polygons = new List<Polygon>();
        }

        private PointF Derasterize(Point point)
        {
            return new PointF(
                point.X * (xMax - xMin) / _canvas.Image.Width,
                point.Y * (yMax - yMin) / _canvas.Image.Height);
        }

        private Point Rasterize(PointF point)
        {
            return new Point(
                (int)Math.Round(point.X * (_canvas.Image.Width) / (xMax - xMin)),
                (int)Math.Round(point.Y * (_canvas.Image.Height) / (yMax - yMin)));
        }

        private bool AreWithinSearchRange(PointF a, PointF b)
        {
            var aInt = Rasterize(a);
            var bInt = Rasterize(b);
            var xDif = aInt.X - bInt.X;
            var yDif = aInt.Y - bInt.Y;

            return xDif * xDif + yDif * yDif < searchRadius * searchRadius;
        }

        public void AddVertexOnEdge(Edge edge)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        public void ChangeLineDrawingMethod(ILineDrawingMethod lineDrawingMethod)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
        }

        private List<Edge>? _newPolygonEdges;
        private List<Vertex>? _newPolygonVertices;
        private Polygon? _newPolygon;

        public void StartPolygonCreation(Point position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            _newPolygonEdges = new List<Edge>();
            _newPolygonVertices = new List<Vertex>();
            _newPolygon = new Polygon(_newPolygonEdges, _newPolygonVertices);

            _newPolygonVertices.Add(new Vertex(position));
        }

        CreatingPolygonState IDrawingLogic.AddVertexWhileCreatingPolygon(Point position)
        {
            if (_newPolygon == null || _newPolygonEdges == null || _newPolygonVertices == null || _newPolygonVertices.Count < 1) {
                return CreatingPolygonState.FinishedWithError;
            }
            var newVertex = new Vertex(position);
            var lastVertex = _newPolygonVertices[_newPolygonVertices.Count - 1];

            if (AreWithinSearchRange(newVertex.RasterizedPosition, lastVertex.RasterizedPosition))
            {
                if (_newPolygonVertices.Count <= 2)
                {
                    return CreatingPolygonState.Adding;
                }

                var newEdge = new Edge(lastVertex, _newPolygonVertices[0], _newPolygon);
                _newPolygonEdges.Add(newEdge);

                Polygons.Add(_newPolygon);
                _newPolygon = null;
                _newPolygonEdges = null;
                _newPolygonVertices = null;

                return CreatingPolygonState.FinishedWithSuccess;
            }
            else
            {

                var newEdge = new Edge(lastVertex, newVertex, _newPolygon);
                _newPolygonEdges.Add(newEdge);
                _newPolygonVertices.Add(newVertex);

                return CreatingPolygonState.Adding;
            }
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

        public void AbortCreatingPolygon()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            _newPolygon = null;
            _newPolygonEdges = null;
            _newPolygonVertices = null;
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
