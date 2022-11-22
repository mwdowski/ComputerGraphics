using System.Numerics;

namespace P2_TrainglesFilling.Rasterizers
{
    public class Rasterizer
    {
        public readonly Image Image;
        private readonly float xMin;
        private readonly float xMax;
        private readonly float yMin;
        private readonly float yMax;

        private object _lock = new object();

        public Rasterizer(Image image, float scale)
        {
            Image = image;

            xMin = -scale * image.Width / image.Height;
            xMax = scale * image.Width / image.Height;
            yMin = -scale;
            yMax = scale;
        }

        public PointF Derasterize(Point point)
        {
            PointF res;
            lock (_lock)
            {
                res = new PointF(
                    point.X * (xMax - xMin) / Image.Width,
                    point.Y * (yMax - yMin) / Image.Height);
            }
            return res;
        }

        public Point Rasterize(PointF point)
        {
            Point res;

            lock (_lock)
            {
                res = new Point(
                    (int)Math.Round((point.X - xMin) * (Image.Width) / (xMax - xMin)),
                    (int)Math.Round((point.Y - yMin) * (Image.Height) / (yMax - yMin)));
                if (res.X >= Image.Width) res.X = Image.Width;
                if (res.Y >= Image.Height) res.Y = Image.Height;
            }

            if (res.X < 0) res.X = 0;
            if (res.Y < 0) res.Y = 0;

            return res;
        }

        public Point RasterizeOrthogonaly(Vector3 point)
        {
            return Rasterize(new PointF(point.X, point.Y));
        }
    }
}
