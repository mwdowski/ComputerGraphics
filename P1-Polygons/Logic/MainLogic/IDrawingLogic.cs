using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Logic.LineDrawingMethods;
using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.MainLogic
{
    public interface IDrawingLogic
    {
        public Figure? GetSelectedFigure(Point position);
        public void StartPolygonCreation(Point position);
        public void AddVertexWhileCreatingPolygon(Point position);
        public void FinishCreatingPolygon(Point position);
        public void FinishCreatingPolygon();
        public void AbortCreatingPolygon();
        public void DeletePolygon(Polygon polygon);
        public void MovePolygon(Polygon polygon, Point position);
        public void AddVertexOnEdge(Edge edge);
        public void MoveVertex(Point position);
        public void DeleteVertex(Vertex vertex);
        public void MoveEdge(Edge edge, Point position);
        public void DeleteEdge(Edge edge);
        public void AddEdgeRestriction<T>(Edge edge) where T : IEdgeRestriction;
        public void RemoveEdgeRestriction<T>(Edge edge) where T : IEdgeRestriction;
        public void ChangeLineDrawingMethod(ILineDrawingMethod lineDrawingMethod);
        public void Redraw();
    }
}
