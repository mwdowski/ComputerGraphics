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
            yMax = scale ;
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

        public int PixelDistanceSquared(Point aInt, Point bInt)
        {
            var xDif = aInt.X - bInt.X;
            var yDif = aInt.Y - bInt.Y;

            return xDif * xDif + yDif * yDif;
        }

        public int DistanceSquared(PointF a, PointF b)
        {
            return PixelDistanceSquared(Rasterize(a), Rasterize(b));
        }
    }
}
