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
        private Point? _initialPosition;
        private Figure? _movedFigure;

        public void StartMovement(Point point, Figure figure)
        {
            _initialPosition = point;
            _movedFigure = figure;
        }

        public void Move(Point point)
        {

        }

        public void FinishMovement()
        {
            _initialPosition = null;
            _movedFigure = null;
        }
    }
}
