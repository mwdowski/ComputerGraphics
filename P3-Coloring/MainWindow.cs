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
        }
    }
}