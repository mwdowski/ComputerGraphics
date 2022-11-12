using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Model;
using System.Numerics;

namespace P2_TrianglesFilling.Drawing.ColorProviders
{
    public class LambertConstantColorProvider : ConstantColorProvider
    {
        private readonly FigureDrawerArguments _arguments;
        private readonly PolygonWithNormals _polygonWithNormals;

        public LambertConstantColorProvider(Color color, FigureDrawerArguments arguments, PolygonWithNormals polygonWithNormals) : base(color)
        {
            _arguments = arguments;
            _polygonWithNormals = polygonWithNormals;
        }

        public override Color GetColor(int x, int y)
        {
            return GetLambertColor(Color);
        }

        private Color GetLambertColor(Color color)
        {
            // TODO: use normal vectors
            return Color.FromArgb(
                ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(color.R), ScaleByteToFloat(_arguments.I_L.R), new Vector3())),
                ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(color.G), ScaleByteToFloat(_arguments.I_L.G), new Vector3())),
                ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(color.B), ScaleByteToFloat(_arguments.I_L.B), new Vector3()))
            );
        }

        private static float ScaleByteToFloat(byte b)
        {
            return b / 255f;
        }

        private static byte ScaleFloatToByte(float f)
        {
            return (byte)((f > 1 ? 1 : f) * 255);
        }

        private float GetLambertOneComponent(float objectColor, float lightColor, Vector3 normalVector)
        {
            return GetLambertLightComponent(objectColor, lightColor, normalVector, _arguments.k_d, _arguments.L)
                 + GetLambertReflectionComponent(objectColor, lightColor, normalVector, _arguments.k_d, _arguments.m, _arguments.L);
        }

        private static float GetLambertLightComponent(float objectColor, float lightColor, Vector3 normalVector, float k_d, Vector3 lightVector)
        {
            return k_d * objectColor * lightColor * PositiveOrZero(CosAngle(normalVector, lightVector));
        }

        private static float GetLambertReflectionComponent(float objectColor, float lightColor, Vector3 normalVector, float k_s, int m, Vector3 lightVector)
        {
            var reflectionVector = 2 * Vector3.Dot(normalVector, lightVector) * normalVector - lightVector;
            return k_s * objectColor * lightColor * PositiveOrZero((float)Math.Pow(CosAngle(normalVector, reflectionVector), m));
        }

        private static float CosAngle(Vector3 a, Vector3 b)
        {
            return Vector3.Dot(a, b) / a.Length() / b.Length();
        }

        private static float PositiveOrZero(float value)
        {
            return value > 0 ? value : 0;
        }
    }
}
