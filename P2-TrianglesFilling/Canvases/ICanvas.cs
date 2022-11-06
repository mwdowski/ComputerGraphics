using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Canvases
{
    public interface ICanvas
    {
        public Bitmap Bitmap { get; }
        public void SetPixel(int x, int y, Color color);
        public Color GetPixel(int x, int y);
    }
}
