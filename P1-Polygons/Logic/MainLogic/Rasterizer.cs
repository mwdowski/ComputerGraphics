using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.MainLogic
{
    public class Rasterizer
    {
        public readonly Image Image;
        private const float xMin = -100.0f;
        private const float xMax = 100.0f;
        private const float yMin = -100.0f;
        private const float yMax = 100.0f;

        public Rasterizer(PictureBox canvas)
        {
            Image = canvas.Image;
        }

        public PointF Derasterize(Point point)
        {
            return new PointF(
                point.X * (xMax - xMin) / Image.Width,
                point.Y * (yMax - yMin) / Image.Height);
        }

        public Point Rasterize(PointF point)
        {
            return new Point(
                (int)Math.Round(point.X * (Image.Width) / (xMax - xMin)),
                (int)Math.Round(point.Y * (Image.Height) / (yMax - yMin)));
        }

        public bool ArePointsWithinPixelRadius(PointF a, PointF b, float radius)
        {
            return ArePointsWithinPixelRadius(Rasterize(a), Rasterize(b), radius);
        }

        public bool ArePointsWithinPixelRadius(Point aInt, Point bInt, float radius)
        {
            var xDif = aInt.X - bInt.X;
            var yDif = aInt.Y - bInt.Y;

            return xDif * xDif + yDif * yDif < radius * radius;
        }
    }
}
