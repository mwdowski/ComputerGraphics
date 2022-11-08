using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Canvases
{
    public interface ICanvas
    {
        Bitmap Bitmap { get; }
        void SetPixel(int x, int y, Color color);
        Color GetPixel(int x, int y);
        void Refresh();
    }
}
