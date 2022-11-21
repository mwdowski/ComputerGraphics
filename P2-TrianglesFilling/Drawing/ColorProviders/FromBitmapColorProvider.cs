using P2_TrianglesFilling.Canvases;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.ColorProviders
{
    public class FromBitmapColorProvider : IColorProvider
    {
        private DirectParallelBitmap _bitmap;

        public FromBitmapColorProvider(DirectParallelBitmap bitmap)
        {
            _bitmap = bitmap;
        }

        public Color GetColor(int x, int y)
        {
            Color res;
            {
                if (x < _bitmap.Width && y < _bitmap.Height)
                {
                    res = _bitmap.GetPixel(x, y);
                }
                else res = Color.Black;
            }

            return res;
        }
    }
}
