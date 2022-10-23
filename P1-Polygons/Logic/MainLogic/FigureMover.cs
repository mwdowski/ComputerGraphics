using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.MainLogic
{
    public class FigureMover
    {
        private Point? _lastClickPosition;
        private Figure? _movedFigure;

        public Rasterizer Rasterizer { get; }

        public FigureMover(Rasterizer rasterizer)
        {
            Rasterizer = rasterizer;
        }

        public void StartMovement(Point point, Figure figure)
        {
            _lastClickPosition = point;
            _movedFigure = figure;
        }

        public void Move(Point point)
        {
            if (!_lastClickPosition.HasValue) return;

            var movementVector = new Point(point.X - _lastClickPosition.Value.X, point.Y - _lastClickPosition.Value.Y);
            _movedFigure?.MoveByConsideringRestrictions(Rasterizer.Derasterize(movementVector));
            _lastClickPosition = point;
        }

        public void FinishMovement()
        {
            _lastClickPosition = null;
            _movedFigure = null;
        }
    }
}
