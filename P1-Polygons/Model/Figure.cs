using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Model
{
    public abstract class Figure
    {
        public abstract void ProcessLeftClick();

        public abstract void ProcessRightClick();

        public abstract Polygon GetPolygon();
    }
}
