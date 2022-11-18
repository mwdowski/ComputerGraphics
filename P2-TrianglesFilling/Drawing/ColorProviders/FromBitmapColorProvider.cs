using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.ColorProviders
{
    public class FromBitmapColorProvider : IColorProvider
    {
        private Bitmap _bitmap;

        public FromBitmapColorProvider(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        public Color GetColor(int x, int y)
        {
            if (x < _bitmap.Width && y < _bitmap.Height)
            {
                return _bitmap.GetPixel(x, y);
            }
            else return Color.Black;
        }
    }
}
