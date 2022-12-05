using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Coloring.Model
{
    public class ProfileColorAttributes
    {
        public BindedAttribute<string> Name { get; set; }
        public BindedAttribute<float> Gamma { get; set; }
        public BindedAttribute<PointF> White { get; set; }
        public BindedAttribute<PointF> Red { get; set; }
        public BindedAttribute<PointF> Green { get; set; }
        public BindedAttribute<PointF> Blue { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public static List<ProfileColorAttributes> GetProfileColorAttributes()
        {
            return new List<ProfileColorAttributes>()
            {
                new ProfileColorAttributes
                {
                    Name = "sRGB",
                    Gamma = 2.2f,
                    White = new PointF(0.312730f, 0.329020f),
                    Red = new PointF(0.64f, 0.33f),
                    Green = new PointF(0.3f, 0.6f),
                    Blue = new PointF(0.15f, 0.06f),
                },
                new ProfileColorAttributes
                {
                    Name = "AdobeRGB",
                    Gamma = 2.2f,
                    White = new PointF(0.312730f, 0.329020f),
                    Red = new PointF(0.64f, 0.33f),
                    Green = new PointF(0.21f, 0.71f),
                    Blue = new PointF(0.15f, 0.06f),
                },
                new ProfileColorAttributes
                {
                    Name = "AppleRGB",
                    Gamma = 1.8f,
                    White = new PointF(0.312730f, 0.329020f),
                    Red = new PointF(0.625f, 0.34f),
                    Green = new PointF(0.28f, 0.595f),
                    Blue = new PointF(0.155f, 0.07f),
                },
                new ProfileColorAttributes
                {
                    Name = "Wide Gamut",
                    Gamma = 1.2f,
                    White = new PointF(0.34567f, 0.3585f),
                    Red = new PointF(0.7347f, 0.2653f),
                    Green = new PointF(0.1152f, 0.8264f),
                    Blue = new PointF(0.1566f, 0.017700f),
                }
            };
        }
    }
}
