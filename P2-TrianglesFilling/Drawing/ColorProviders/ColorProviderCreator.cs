using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Logic;
using P2_TrianglesFilling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.ColorProviders
{
    public class ColorProviderCreator
    {
        public Rasterizer Rasterizer { get; }

        public ColorProviderCreator(Rasterizer rasterizer)
        {
            Rasterizer = rasterizer;
        }

        public IColorProvider GetColorProvider(
            FigureDrawerArguments arguments,
            LogicSettings logicSettings,
            PolygonWithNormals polygonWithNormals)
        {
            return GetLambertColorProvider(arguments, logicSettings, polygonWithNormals, Rasterizer, GetObjectColorProvider(logicSettings));
        }

        private static IColorProvider GetObjectColorProvider(LogicSettings logicSettings)
        {
            IColorProvider objectColorProvider;

            if (logicSettings.ObjectBackground == ObjectBackground.ConstantColor)
            {
                objectColorProvider = new ConstantColorProvider(logicSettings.ObjectColor);
            }
            else
            {
                if (logicSettings.ObjectTexture != null)
                {
                    objectColorProvider = new FromBitmapColorProvider(logicSettings.ObjectTexture);
                }
                else
                {
                    objectColorProvider = new ConstantColorProvider(Color.Black);
                }
            }

            return objectColorProvider;
        }

        private static IColorProvider GetLambertColorProvider(
            FigureDrawerArguments arguments,
            LogicSettings logicSettings,
            PolygonWithNormals polygonWithNormals,
            Rasterizer rasterizer,
            IColorProvider objectColorProvider)
        {
            IColorProvider lambertMethodColorProvider;

            if (logicSettings.DrawingMethod == DrawingMethod.ColorInterpolation)
            {
                lambertMethodColorProvider = new LambertWithVerticesColorInterpolationConstantColorProvider(
                    objectColorProvider, arguments, polygonWithNormals, rasterizer);
            }
            else
            {
                lambertMethodColorProvider = new LambertWithNormalsInterpolationConstantColorProvider(
                    objectColorProvider, arguments, polygonWithNormals, rasterizer);
            }

            return lambertMethodColorProvider;
        }
    }
}
