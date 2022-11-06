using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Canvases
{
    public class BitmapCanvas : IDisposable, ICanvas
    {
        public Bitmap Bitmap { get; private set; }

        public BitmapCanvas(int width, int height)
        {
            Bitmap = new Bitmap(width, height);
        }

        public Color GetPixel(int x, int y)
        {
            return Bitmap.GetPixel(x, y);
        }

        public void SetPixel(int x, int y, Color color)
        {
            Bitmap.SetPixel(x, y, color);
        }

        public bool Disposed { get; private set; } = false;
        public void Dispose()
        {
            if (Disposed) return;
            Bitmap.Dispose();
            Disposed = true;
        }
    }
}
