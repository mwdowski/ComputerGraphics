using MathNet.Numerics.LinearAlgebra;
using P3_Coloring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Coloring.Algorithms
{
    public static class ColorProfiles
    {
        public static Matrix<float> GetIluminantsPositionMatrix(ProfileColorAttributes profile)
        {
            var matrix = Matrix<float>.Build.DenseOfColumnVectors(new Vector<float>[]
            {
                GetIluminant3DPosition(profile.Red),
                GetIluminant3DPosition(profile.Green),
                GetIluminant3DPosition(profile.Blue)
            });

            return matrix;
        }

        public static Vector<float> GetIluminant3DPosition(PointF position)
        {
            var vector = Vector<float>.Build.DenseOfArray(new float[]
            {
                position.X,
                position.Y,
                1 - position.X - position.Y
            });

            return vector;
        }

        public static Vector<float> GetWhiteIluminant3DPosition(PointF position)
        {
            var vector = Vector<float>.Build.DenseOfArray(new float[]
            {
                position.X / position.Y,
                1,
                (1 - position.X - position.Y) / position.Y
            });

            return vector;
        }

        public static Vector<float> GetLightPoint3DPosition(PointF whitePosition)
        {
            var vector = Vector<float>.Build.DenseOfArray(new float[]
            {
                whitePosition.X,
                whitePosition.Y,
                1 - whitePosition.X - whitePosition.Y
            });

            return vector;
        }

        public static Vector<float> GetSValuesOfColors(ProfileColorAttributes profile)
        {
            var colorsPositions = GetIluminantsPositionMatrix(profile);
            var whitePosition = GetWhiteIluminant3DPosition(profile.White);

            return colorsPositions.Solve(whitePosition);
        }

        public static Matrix<float> GetToXYZTranformMatrix(ProfileColorAttributes profile)
        {
            var sValues = Matrix<float>.Build.DenseOfDiagonalVector(GetSValuesOfColors(profile));
            return GetIluminantsPositionMatrix(profile).Multiply(sValues);
        }

        public static Vector<float> RGB2XYZ(Vector<float> rbg, Matrix<float> tranformMatrix)
        {
            return tranformMatrix.Multiply(rbg);
        }

        public static Vector<float> XYZ2RGB(Vector<float> xyz, Matrix<float> tranformMatrix)
        {
            return tranformMatrix.Solve(xyz);
        }

        public static byte ScaleFloatToByte(float f)
        {
            return (byte)(PositiveOrZero(f > 1 ? 1 : f) * 255);
        }

        public static float PositiveOrZero(float value)
        {
            return value > 0 ? value : 0;
        }

        public static Vector<float> ApplyGammaCorrection(Vector<float> color, float sourceGamma, float targetGamma)
        {
            return color
                .Clone()
                .Map(value => (float)Math.Pow(value, 1 / targetGamma));
        }

        public static Matrix<float> GetBradfordTransform(PointF sourceWhite, PointF targetWhite)
        {
            var whiteXYZsource = GetLightPoint3DPosition(sourceWhite);
            var whiteXYZtarget = GetLightPoint3DPosition(targetWhite);

            var rgbSource = Bradford.Multiply(whiteXYZsource);
            var rgbTarget = Bradford.Multiply(whiteXYZtarget);

            var rgbDivided = Matrix<float>.Build.DenseOfDiagonalVector(rgbTarget.PointwiseDivide(rgbSource));

            return BradfordInversed.Multiply(rgbDivided).Multiply(Bradford);
        }

        private static readonly Matrix<float> Bradford = Matrix<float>.Build.DenseOfRowArrays(new float[][]
        {
            new float[] { 0.8951f, 0.2664f, -0.1614f },
            new float[] { -0.7502f, 1.7135f, 0.0367f },
            new float[] { 0.0389f, -0.0685f, 1.0296f },
        });

        private static readonly Matrix<float> BradfordInversed = Bradford.Inverse();
    }
}
