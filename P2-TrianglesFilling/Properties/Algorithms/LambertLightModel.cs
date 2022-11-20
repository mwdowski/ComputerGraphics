using System.Numerics;

namespace P2_TrianglesFilling.Algorithms
{
    public static class LambertLightModel
    {
        public static Color GetLambertColor(Color color, Color I_L, Vector3 normalVector, Vector3 lightVector, int m, float k_d, float k_s)
        {
            return Color.FromArgb(
                ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(color.R), ScaleByteToFloat(I_L.R), normalVector, lightVector, m, k_d, k_s)),
                ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(color.G), ScaleByteToFloat(I_L.G), normalVector, lightVector, m, k_d, k_s)),
                ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(color.B), ScaleByteToFloat(I_L.B), normalVector, lightVector, m, k_d, k_s))
            );
        }

        private static float GetLambertOneComponent(float objectColor, float lightColor, Vector3 normalVector, Vector3 lightVector, int m, float k_d, float k_s)
        {
            return GetLambertLightComponent(objectColor, lightColor, normalVector, k_d, lightVector)
                 + GetLambertReflectionComponent(objectColor, lightColor, normalVector, k_s, m, lightVector);
        }

        private static float ScaleByteToFloat(byte b)
        {
            return b / 255f;
        }

        private static byte ScaleFloatToByte(float f)
        {
            return (byte)(PositiveOrZero(f > 1 ? 1 : f) * 255);
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
