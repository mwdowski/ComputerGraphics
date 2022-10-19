using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.MainLogic
{
    public class FigureSelector
    {
        public Figure? SelectedFigure { get; private set; }
        public Rasterizer Rasterizer { get; }
        private ProgramLogic _logic;

        public const int SearchRadius = 20;

        public FigureSelector(Rasterizer rasterizer, ProgramLogic logic)
        {
            Rasterizer = rasterizer;
            _logic = logic;
        }

        public void SelectByClick(Point position)
        {
            var closestVertex = _logic.Polygons
                .SelectMany(_ => _.Vertices)
                .Where(_ => _.GetPixelDistanceSquared(position, Rasterizer) <= SearchRadius * SearchRadius)
                .Min(new VertexPixelDistanceComparer(position, Rasterizer));
            
            var closestEdge = _logic.Polygons
                .SelectMany(_ => _.Edges)
                .Where(_ => _.GetPixelDistanceSquared(position, Rasterizer) <= SearchRadius * SearchRadius)
                .Min(new EdgePixelDistanceComparer(position, Rasterizer));

            SelectedFigure = (Figure?)closestVertex ?? closestEdge;
        }

        public void ClearSelection()
        {
            SelectedFigure = null;
        }
    }
}
