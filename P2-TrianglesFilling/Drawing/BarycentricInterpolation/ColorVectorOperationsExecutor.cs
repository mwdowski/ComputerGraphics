using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.BarycentricInterpolation
{
    public class ColorVectorOperationsExecutor : IVectorOperationsExecutor<float, Color>
    {
        public Color Add(Color vector1, Color vector2)
        {
            return AddAndCut(vector1, vector2);
        }

        public Color Scale(Color vector, float scale)
        {
            return Color.FromArgb(Cut(vector.R * scale), Cut(vector.G * scale), Cut(vector.B * scale), Cut(vector.A * scale));
        }

        // TODO: cleanup
        private static Color AddAndCut(Color color1, Color color2)
        {
            int r = color1.R + color2.R;
            int g = color1.G + color2.G;
            int b = color1.B + color2.B;
            int a = color1.A + color2.A;

            r = r > 255 ? 255 : r;
            g = g > 255 ? 255 : g;
            b = b > 255 ? 255 : b;
            a = a > 255 ? 255 : a;

            r = r < 0 ? 0 : r;
            g = g < 0 ? 0 : g;
            b = b < 0 ? 0 : b;
            a = a < 0 ? 0 : a;

            return Color.FromArgb(r, g, b, a);
        }

        private static byte Cut(int value)
        {
            value = value > 255 ? 255 : value;
            value = value < 0 ? 0 : value;

            return (byte)value;
        }

        private static byte Cut(float value)
        {
            return Cut((int)value);
        }
    }
}
