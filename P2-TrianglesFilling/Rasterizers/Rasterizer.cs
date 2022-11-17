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
            return new PointF(
                point.X * (xMax - xMin) / Image.Width,
                point.Y * (yMax - yMin) / Image.Height);
        }

        public Point Rasterize(PointF point)
        {
            return new Point(
                (int)Math.Round((point.X - xMin) * (Image.Width) / (xMax - xMin)),
                (int)Math.Round((point.Y - yMin) * (Image.Height) / (yMax - yMin)));
        }

        public Point RasterizeOrthogonaly(Vector3 point)
        {
            return Rasterize(new PointF(point.X, point.Y));
        }
    }
}
