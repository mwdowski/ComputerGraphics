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
        private Polygon _newPolygon;

        private CreatingPolygonState _lastState = CreatingPolygonState.NotStarted;
        private CreatingPolygonState SetLastState(CreatingPolygonState lastState)
        {
            _lastState = lastState;
            return _lastState;
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
            _newPolygonEdges = new();
            _newPolygonVertices = new();
            _newPolygon = new(_newPolygonEdges, _newPolygonVertices);
        }

        public CreatingPolygonState StartPolygonCreation(Point position)
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");

            if (_lastState == CreatingPolygonState.NotStarted)
            {
                _newPolygonVertices.Add(new Vertex(Rasterizer.Derasterize(position)));
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
            if (_lastState != CreatingPolygonState.Adding) {
                return SetLastState(CreatingPolygonState.Error);
            }

            var newVertex = new Vertex(Rasterizer.Derasterize(position));
            var lastVertex = _newPolygonVertices[_newPolygonVertices.Count - 1];

            if (Rasterizer.ArePointsWithinPixelRadius(newVertex.Position, lastVertex.Position, pixelRadius))
            {
                if (_newPolygonVertices.Count <= 2)
                {
                    return CreatingPolygonState.Adding;
                }

                var newEdge = new Edge(lastVertex, _newPolygonVertices[0], _newPolygon);
                _newPolygonEdges.Add(newEdge);

                return CreatingPolygonState.PolygonReady;
            }
            else
            {
                var newEdge = new Edge(lastVertex, newVertex, _newPolygon);
                _newPolygonEdges.Add(newEdge);
                _newPolygonVertices.Add(newVertex);

                return CreatingPolygonState.Adding;
            }
        }

        public Polygon GetCreatedPolygon()
        {
            Console.WriteLine($"{this.GetType().Name}.{(new StackFrame())?.GetMethod()?.Name}");
            if (_lastState == CreatingPolygonState.PolygonReady)
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
    }
}
