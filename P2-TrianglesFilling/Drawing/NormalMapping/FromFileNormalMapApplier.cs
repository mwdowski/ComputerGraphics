using System.Numerics;

namespace P2_TrianglesFilling.Drawing.NormalMapping
{
    public class FromFileNormalMapApplier : INormalMapApplier
    {
        private Bitmap _bitmap;

        public FromFileNormalMapApplier(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        public Vector3 MapNormal(Vector3 normal, int x, int y)
        {
            var textureNormal = ColorToVector(x < _bitmap.Width && y < _bitmap.Height ? _bitmap.GetPixel(x, y) : Color.Black);
            var tangential = Tangential(normal);
            var binormal = Binormal(normal);
            return new Vector3(
                tangential.X * textureNormal.X + binormal.X * textureNormal.Y + normal.X * textureNormal.Z,
                tangential.Y * textureNormal.X + binormal.Y * textureNormal.Y + normal.Y * textureNormal.Z,
                tangential.Z * textureNormal.X + binormal.Z * textureNormal.Y + normal.Z * textureNormal.Z
            );
        }

        private static Vector3 ColorToVector(Color color)
        {
            return new Vector3(
                (color.R - 128) / 127.5f,
                (color.G - 128) / 127.5f,
                color.B >= 128 ? color.B / 127f : 0);
        }

        private static Vector3 Binormal(Vector3 vector)
        {
            return Vector3.Cross(vector, new Vector3(0, 0, 1));
        }

        private static Vector3 Tangential(Vector3 vector)
        {
            return Vector3.Cross(Binormal(vector), vector);
        }
    }
}
