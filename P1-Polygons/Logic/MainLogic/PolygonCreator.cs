using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.MainLogic
{
    public enum CreatingPolygonState
    {
        Error, PolygonReady, Adding, NotStarted, Finished
    }

    public class PolygonCreator
    {
        private List<Edge> _newPolygonEdges;
        private List<Vertex> _newPolygonVertices;
        public Polygon _newPolygon;

        public CreatingPolygonState LastState { get; private set; } = CreatingPolygonState.NotStarted;
        private CreatingPolygonState SetLastState(CreatingPolygonState lastState)
        {
            LastState = lastState;
            return LastState;
        }

        public Rasterizer Rasterizer { get; }
        public PolygonCreator(Rasterizer rasterizer)
        {
            Rasterizer = rasterizer;
            _newPolygonEdges = new();
            _newPolygonVertices = new();
            _newPolygon = new(_newPolygonEdges, _newPolygonVertices);
        }

        private void InitializePolygonData()
        {
            _newPolygon = new(new(), new());
            _newPolygonEdges = _newPolygon.Edges;
            _newPolygonVertices = _newPolygon.Vertices;
        }

        public CreatingPolygonState StartPolygonCreation(Point position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");

            if (LastState == CreatingPolygonState.NotStarted)
            {
                _newPolygonVertices.Add(new Vertex(Rasterizer.Derasterize(position), _newPolygon));
                return SetLastState(CreatingPolygonState.Adding);
            }
            else
            {
                return CreatingPolygonState.Error;
            }
        }

        private const int pixelRadius = 20;
        public CreatingPolygonState AddVertexWhileCreatingPolygon(Point position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");

            if (LastState != CreatingPolygonState.Adding) {
                return SetLastState(CreatingPolygonState.Error);
            }

            var newVertex = new Vertex(Rasterizer.Derasterize(position), _newPolygon);
            var lastVertex = _newPolygonVertices[_newPolygonVertices.Count - 1];
            var firstVertex = _newPolygonVertices[0];

            if (Rasterizer.ArePointsWithinPixelRadius(position, Rasterizer.Rasterize(firstVertex.Position), pixelRadius))
            {
                if (_newPolygonVertices.Count <= 2)
                {
                    return SetLastState(CreatingPolygonState.Adding);
                }

                var newEdge = new Edge(lastVertex, firstVertex, _newPolygon);
                _newPolygonEdges.Add(newEdge);

                return SetLastState(CreatingPolygonState.PolygonReady);
            }
            else
            {
                var newEdge = new Edge(lastVertex, newVertex, _newPolygon);
                _newPolygonEdges.Add(newEdge);
                _newPolygonVertices.Add(newVertex);

                return SetLastState(CreatingPolygonState.Adding);
            }
        }

        public Polygon GetCreatedPolygon()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            if (LastState == CreatingPolygonState.PolygonReady)
            {
                SetLastState(CreatingPolygonState.Finished);
                return _newPolygon;
            }

            throw new Exception("Cannot retrieve not finished polygon");
        }

        public void Restart()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            SetLastState(CreatingPolygonState.NotStarted);
            InitializePolygonData();
        }

        public void DrawCurrentPolygon(FigureDrawer drawer, Graphics graphics)
        {
            if (LastState == CreatingPolygonState.Adding)
            {
                drawer.DrawPolygon(_newPolygon, graphics);
            }
        }
    }
}
