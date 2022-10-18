using P1_Polygons.Logic.MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Model
{
    public abstract class Figure
    {
        public abstract void ProcessLeftClick();
        public abstract void ProcessRightClick();
        public abstract void MoveBy(PointF vector);
        public abstract void MoveTo(PointF position);
        public abstract Polygon GetPolygon();
        public abstract float GetDistanceSquared(PointF point);
        public abstract int GetPixelDistanceSquared(Point point, Rasterizer rasterizer);
        public float GetDistance(PointF point)
        {
            return (float)Math.Sqrt((double)GetDistanceSquared(point));
        }
    }
}
