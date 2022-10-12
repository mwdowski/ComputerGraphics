using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Logic.LineDrawingMethods;
using P1_Polygons.Model;

namespace P1_Polygons.Logic.MainLogic
{
    public interface IDrawingLogic
    {
        public Figure? GetPointedFigure(Point position);
        public void SetSelectedFigure(Figure? figure);
        public void StartPolygonCreation(Point position);
        public CreatingPolygonState AddVertexWhileCreatingPolygon(Point position);
        public void FinishCreatingPolygon(Point position);
        public void FinishCreatingPolygon();
        public void AbortCreatingPolygon();
        public void DeletePolygon(Polygon polygon);
        public void AddVertexOnEdge(Edge edge);
        public void DeleteVertex(Vertex vertex);
        public void MoveSelectedFigureBy(Point vector);
        public void MoveSelectedFigureTo(Point position);
        public void DeleteEdge(Edge edge);
        public void AddEdgeRestriction<T>(Edge edge) where T : IEdgeRestriction;
        public void RemoveEdgeRestriction<T>(Edge edge) where T : IEdgeRestriction;
        public void ChangeLineDrawingMethod(ILineDrawingMethod lineDrawingMethod);
        public void Redraw();
    }
}
