using P3_Coloring.Algorithms;
using P3_Coloring.Logic;
using P3_Coloring.Model;

namespace P3_Coloring
{
    public partial class MainWindow : Form
    {
        private ProgramLogic Logic;
        public MainWindow()
        {
            InitializeComponent();

            BindProfiles();

            Logic = new()
            {
                SourceImage = new BindedAttribute<Image?>(null, image =>
                {
                    sourcePictureBox.Image = image;
                    return image;
                }),
                TargetImage = new BindedAttribute<Image?>(null, image =>
                {
                    targetPictureBox.Image = image;
                    return image;
                })
            };
        }

        private void BindProfiles()
        {
            sourceComboBox.Items.AddRange(ProfileColorAttributes.GetProfileColorAttributes().Cast<object>().ToArray());
            targetComboBox.Items.AddRange(ProfileColorAttributes.GetProfileColorAttributes().Cast<object>().ToArray());
        }

        private ProfileColorAttributes ApplySourceProfileBindings(ProfileColorAttributes profileColorAttributes)
        {
            ProfileColorAttributes sourceProfile = new ProfileColorAttributes
            {
                Gamma = new BindedAttribute<float>(profileColorAttributes.Gamma, gamma =>
                {
                    sourceGammaTextBox.Text = gamma.ToString();
                    return gamma;
                }),
                White = new BindedAttribute<PointF>(profileColorAttributes.White, white =>
                {
                    sourceWhiteXtextBox.Text = white.X.ToString();
                    sourceWhiteYtextBox.Text = white.Y.ToString();
                    return white;
                }),
                Red = new BindedAttribute<PointF>(profileColorAttributes.Red, red =>
                {
                    sourceRedXtextBox.Text = red.X.ToString();
                    sourceRedYtextBox.Text = red.Y.ToString();
                    return red;
                }),
                Green = new BindedAttribute<PointF>(profileColorAttributes.Green, green =>
                {
                    sourceGreenXtextBox.Text = green.X.ToString();
                    sourceGreenYtextBox.Text = green.Y.ToString();
                    return green;
                }),
                Blue = new BindedAttribute<PointF>(profileColorAttributes.Blue, blue =>
                {
                    sourceBlueXtextBox.Text = blue.X.ToString();
                    sourceBlueYtextBox.Text = blue.Y.ToString();
                    return blue;
                })
            };

            return sourceProfile;
        }

        private ProfileColorAttributes ApplyTargetProfileBindings(ProfileColorAttributes profileColorAttributes)
        {
            ProfileColorAttributes sourceProfile = new ProfileColorAttributes
            {
                Gamma = new BindedAttribute<float>(profileColorAttributes.Gamma, gamma =>
                {
                    targetGammaTextBox.Text = gamma.ToString();
                    return gamma;
                }),
                White = new BindedAttribute<PointF>(profileColorAttributes.White, white =>
                {
                    targetWhiteXtextBox.Text = white.X.ToString();
                    targetWhiteYtextBox.Text = white.Y.ToString();
                    return white;
                }),
                Red = new BindedAttribute<PointF>(profileColorAttributes.Red, red =>
                {
                    targetRedXtextBox.Text = red.X.ToString();
                    targetRedYtextBox.Text = red.Y.ToString();
                    return red;
                }),
                Green = new BindedAttribute<PointF>(profileColorAttributes.Green, green =>
                {
                    targetGreenXtextBox.Text = green.X.ToString();
                    targetGreenYtextBox.Text = green.Y.ToString();
                    return green;
                }),
                Blue = new BindedAttribute<PointF>(profileColorAttributes.Blue, blue =>
                {
                    targetBlueXtextBox.Text = blue.X.ToString();
                    targetBlueYtextBox.Text = blue.Y.ToString();
                    return blue;
                })
            };

            return sourceProfile;
        }

        private void sourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var newProfileIndex = ((ComboBox)sender).SelectedIndex;
            Logic.SourceProfile = ApplySourceProfileBindings((ProfileColorAttributes)sourceComboBox.Items[newProfileIndex]);
        }

        private void targetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var newProfileIndex = ((ComboBox)sender).SelectedIndex;
            Logic.TargetProfile = ApplyTargetProfileBindings((ProfileColorAttributes)targetComboBox.Items[newProfileIndex]);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Logic.SourceImage != null)
                {
                    Logic.SourceImage.Value = new Bitmap(openFileDialog.FileName);
                }
            }
            HSV = false;
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.ComputeTargetImage();
        }

        private void sourceGammaTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void sourceWhiteXtextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void sourceWhiteYtextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void sourceRedXtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sourceRedYtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sourceGreenXtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sourceGreenYtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sourceBlueXtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sourceBlueYtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void targetGammaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void targetWhiteXtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void targetWhiteYtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void targetRedXtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void targetRedYtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void targetGreenXtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void targetGreenYtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void targetBlueXtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void targetBlueYtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private bool HSV = false;
        private float v_tb = 0;

        private void getHSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HSV = true;
            Logic.SourceImage.Value = GenerateHSVImage();
        }

        private Bitmap GenerateHSVImage()
        {

            var v = (float)trackBar1.Value / trackBar1.Maximum;
            const int width = 801;
            const int heigth = 801;

            const int centerX = width / 2;
            const int centerY = heigth / 2;

            const int r = width / 2;


            var bitmap = new Bitmap(width, heigth);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < heigth; y++)
                {
                    var d = (x - centerX) * (x - centerX) + (y - centerY) * (y - centerY);
                    if (d <= r * r)
                    {
                        var s = (float)Math.Sqrt(d) / r;

                        var h_in_radians = (float)Math.Atan2(y - centerY, x - centerX) + (float)Math.PI;
                        var h = h_in_radians / ((float)Math.PI * 2) * 360;
                        h = (h + 180) % 360;

                        h = 360 - h;

                        bitmap.SetPixel(x, y, HSV2RGB(h, s, v));
                    }
                    else
                    {
                        bitmap.SetPixel(x, y, Color.White);
                    }
                }
            }

            return bitmap;
        }

        private static Color HSV2RGB(float h, float s, float v)
        {
            var c = v * s;
            var h_prim = (h % 360) / 60f;
            var x = c * (1 - Math.Abs(h_prim % 2 - 1));

            var rgb_prim = (0f, 0f, 0f);

            if (0 <= h_prim && h_prim < 1)
            {
                rgb_prim = (c, x, 0);
            }
            else if (1 <= h_prim && h_prim < 2)
            {
                rgb_prim = (x, c, 0);
            }
            else if (2 <= h_prim && h_prim < 3)
            {

                rgb_prim = (0, c, x);
            }
            else if (3 <= h_prim && h_prim < 4)
            {

                rgb_prim = (0, x, c);
            }
            else if (4 <= h_prim && h_prim < 5)
            {

                rgb_prim = (x, 0, c);
            }
            else
            {

                rgb_prim = (c, 0, x);
            }

            var m = v - c;

            return Color.FromArgb(
                ColorProfiles.ScaleFloatToByte(rgb_prim.Item1 + m),
                ColorProfiles.ScaleFloatToByte(rgb_prim.Item2 + m),
                ColorProfiles.ScaleFloatToByte(rgb_prim.Item3 + m)
            );
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (HSV) Logic.SourceImage.Value = GenerateHSVImage();
        }
    }
}