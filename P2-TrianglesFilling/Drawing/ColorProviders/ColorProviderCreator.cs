using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Drawing.NormalMapping;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Logic;
using P2_TrianglesFilling.Model;

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
            return GetLambertColorProvider(
                arguments,
                logicSettings,
                polygonWithNormals,
                Rasterizer,
                GetObjectColorProvider(logicSettings),
                GetNormalMapApplier(logicSettings));
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
                if (logicSettings.ObjectTextureParallel != null)
                {
                    objectColorProvider = new FromBitmapColorProvider(logicSettings.ObjectTextureParallel);
                }
                else
                {
                    objectColorProvider = new ConstantColorProvider(Color.Black);
                }
            }

            return objectColorProvider;
        }

        private static INormalMapApplier GetNormalMapApplier(LogicSettings logicSettings)
        {
            if (logicSettings.NormalMappingMethod == NormalMappingMethod.NoMapping)
            {
                return new IdentityNormalMapApplier();
            }
            else
            {
                if (logicSettings.NormalMapTextureParallel == null)
                {
                    return new IdentityNormalMapApplier();
                }
                else
                {
                    return new FromFileNormalMapApplier(logicSettings.NormalMapTextureParallel);
                }
            }
        }

        private static IColorProvider GetLambertColorProvider(
            FigureDrawerArguments arguments,
            LogicSettings logicSettings,
            PolygonWithNormals polygonWithNormals,
            Rasterizer rasterizer,
            IColorProvider objectColorProvider,
            INormalMapApplier normalMapApplier)
        {
            IColorProvider lambertMethodColorProvider;

            if (logicSettings.DrawingMethod == DrawingMethod.ColorInterpolation)
            {
                lambertMethodColorProvider = new LambertWithVerticesColorInterpolationAndNormalMappingColorProvider(
                    objectColorProvider, arguments, polygonWithNormals, rasterizer, normalMapApplier);
            }
            else
            {
                lambertMethodColorProvider = new LambertWithNormalsInterpolationAndMappingColorProvider(
                    objectColorProvider, arguments, polygonWithNormals, rasterizer, normalMapApplier);
            }

            return lambertMethodColorProvider;
        }
    }
}
