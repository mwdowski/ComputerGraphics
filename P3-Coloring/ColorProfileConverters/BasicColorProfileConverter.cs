using MathNet.Numerics.LinearAlgebra;
using P3_Coloring.Model;
using static P3_Coloring.Algorithms.ColorProfiles;

namespace P3_Coloring.ColorProfileConverter
{
    public class BasicColorProfileConverter : IColorProfileConverter
    {

        public Image Convert(Image image, ProfileColorAttributes sourceProfile, ProfileColorAttributes targetProfile)
        {
            using (var source = new Bitmap(image))
            {
                var result = new Bitmap(image.Width, image.Height);
                var sourceTranformMatrix = GetToXYZTranformMatrix(sourceProfile);
                var targetTranformMatrix = GetToXYZTranformMatrix(targetProfile);
                var bradfordTransform = GetBradfordTransform(sourceProfile.White, targetProfile.White);

                for (int i = 0; i < result.Width; i++)
                {
                    for (int j = 0; j < result.Height; j++)
                    {
                        var pixel = source.GetPixel(i, j);
                        var colorVector = Vector<float>.Build.DenseOfArray(new float[]
                        {
                            pixel.R / 255f,
                            pixel.G / 255f,
                            pixel.B / 255f,
                        });

                        var colorInXYZ = RGB2XYZ(colorVector, sourceTranformMatrix);

                        var targetcolorVector = ApplyGammaCorrection(
                            bradfordTransform.Multiply(XYZ2RGB(colorInXYZ, targetTranformMatrix)),
                            sourceProfile.Gamma,
                            targetProfile.Gamma
                        );
                        //var targetcolorVector = XYZ2RGB(colorInXYZ, targetTranformMatrix);
                        var targetPixel = Color.FromArgb(
                            ScaleFloatToByte(targetcolorVector.At(0)),
                            ScaleFloatToByte(targetcolorVector.At(1)),
                            ScaleFloatToByte(targetcolorVector.At(2))
                        );

                        result.SetPixel(i, j, targetPixel);
                    }
                }

                return result;
            }
        }

    }
}
