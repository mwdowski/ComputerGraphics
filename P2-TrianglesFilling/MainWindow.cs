using P2_TrianglesFilling.Logic;

namespace P2_TrianglesFilling
{
    public partial class MainWindow : Form
    {
        public ProgramLogic Logic { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Logic = new ProgramLogic(pictureBox, new LogicSettings(
                (value) => objectColorPanel.BackColor = value,
                (value) => lightColorPanel.BackColor = value,
                (value) =>
                {
                    lightHeightTrackBar.Value = (int)value;
                    m_trackBar.Refresh();
                },
                (value) =>
                {
                    lightRadiusTrackBar.Value = (int)value;
                    m_trackBar.Refresh();
                },
                (value) =>
                {
                    lightAngleTrackBar.Value = (int)((lightAngleTrackBar.Maximum + 1) * value / 2 / Math.PI);
                    m_trackBar.Refresh();
                },
                (value) =>
                {
                    oneColorObjectRadioButton.Checked = value == ObjectBackground.ConstantColor;
                    oneColorObjectRadioButton.Refresh();
                    imageColorObjectRadioButton.Checked = value == ObjectBackground.TextureBitmap;
                    imageColorObjectRadioButton.Refresh();
                },
                (value) =>
                {
                    colorInterpolationRadioButton.Checked = value == DrawingMethod.ColorInterpolation;
                    colorInterpolationRadioButton.Refresh();
                    normalsInterpolationRadioButton.Checked = value == DrawingMethod.NormalsInterpolation;
                    normalsInterpolationRadioButton.Refresh();
                },
                (value) =>
                {
                    m_textBox.Text = value.ToString();
                    m_textBox.Refresh();
                    m_trackBar.Value = value;
                    m_trackBar.Refresh();
                },
                (value) =>
                {
                    k_s_textBox.Text = value.ToString("0.00");
                    k_s_textBox.Refresh();
                    k_s_trackBar.Value = (int)(value * 100);
                    k_s_trackBar.Refresh();
                },
                (value) =>
                {
                    k_d_textBox.Text = value.ToString("0.00");
                    k_d_textBox.Refresh();
                    k_d_trackBar.Value = (int)(value * 100);
                    k_d_trackBar.Refresh();
                },
                (value) =>
                {
                    noNormalMappingRadioButton.Checked = value == NormalMappingMethod.NoMapping;
                    noNormalMappingRadioButton.Refresh();
                    normalMappingFromFileRadioButton.Checked = value == NormalMappingMethod.MapFromFile;
                    normalMappingFromFileRadioButton.Refresh();
                }
            ));

            Refresh();
        }

        private void m_trackBar_Scroll(object sender, EventArgs e)
        {
            Logic.LogicSettings.M = ((TrackBar)sender).Value;
            Logic.DrawFigure();
        }

        private void k_s_trackBar_Scroll(object sender, EventArgs e)
        {
            Logic.LogicSettings.KS = ((TrackBar)sender).Value / 100f;
            Logic.DrawFigure();
        }

        private void k_d_trackBar_Scroll(object sender, EventArgs e)
        {
            Logic.LogicSettings.KD = ((TrackBar)sender).Value / 100f;
            Logic.DrawFigure();
        }

        private void objectColorPanel_Click(object sender, EventArgs e)
        {
            if (objectColorDialog.ShowDialog() == DialogResult.OK)
            {
                Logic.LogicSettings.ObjectColor = objectColorDialog.Color;
                Logic.DrawFigure();
            }
        }

        private void loadObjectImageButton_Click(object sender, EventArgs e)
        {
            if (openObjectImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(openObjectImageFileDialog.FileName);
                loadObjectImageButton.Text = openObjectImageFileDialog.FileName.Split('\\').Last();
                Logic.LogicSettings.ObjectTexture = ResizeImageProportional(image, pictureBox.Width, pictureBox.Height);
                Logic.DrawFigure();
            }
        }

        private void oneColorObjectRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Logic.LogicSettings.ObjectBackground = ObjectBackground.ConstantColor;
                Logic.DrawFigure();
            }
        }

        private void imageColorObjectRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Logic.LogicSettings.ObjectBackground = ObjectBackground.TextureBitmap;
                Logic.DrawFigure();
            }
        }

        private void colorInterpolationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Logic.LogicSettings.DrawingMethod = DrawingMethod.ColorInterpolation;
                Logic.DrawFigure();
            }
        }

        private void normalsInterpolationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Logic.LogicSettings.DrawingMethod = DrawingMethod.NormalsInterpolation;
                Logic.DrawFigure();
            }
        }

        private static Bitmap ResizeImageProportional(Bitmap bitmap, int width, int height)
        {
            var destImage = new Bitmap(width, height);

            var destWidth = height * bitmap.Width / bitmap.Height;
            var destHeight = destImage.Height;
            var destX = (width - destWidth) / 2;
            var destY = 0;

            var scaledImage = new Bitmap(bitmap, destWidth, destHeight);
            using (var g = Graphics.FromImage(destImage))
            {
                g.Clear(Color.Black);
                g.DrawImage(scaledImage, destX, destY);
            }

            scaledImage.Dispose();

            return destImage;
        }

        private void lightColorPanel_click(object sender, EventArgs e)
        {
            if (lightColorDialog.ShowDialog() == DialogResult.OK)
            {
                Logic.LogicSettings.LightColor = lightColorDialog.Color;
                Logic.DrawFigure();
            }
        }

        private void lightHeightTrackBar_Scroll(object sender, EventArgs e)
        {
            Logic.LogicSettings.LightSourcePositionHeight = ((TrackBar)sender).Value;
            Logic.DrawFigure();
        }

        private void lightRadiusTrackBar_Scroll(object sender, EventArgs e)
        {
            Logic.LogicSettings.LightSourcePositionRadius = ((TrackBar)sender).Value;
            Logic.DrawFigure();
        }

        private void lightAngleTrackBar_Scroll(object sender, EventArgs e)
        {
            var trackBar = (TrackBar)sender;
            Logic.LogicSettings.LightSourcePositionAngle = (float)(2 * Math.PI * trackBar.Value / (trackBar.Maximum + 1));
            Logic.DrawFigure();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Logic.LogicSettings.LightSourcePositionAngle += (float)(2 * Math.PI / (lightAngleTrackBar.Maximum + 1));
            Logic.DrawFigure();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            timer.Start();
            pauseButton.Enabled = true;
            playButton.Enabled = false;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            pauseButton.Enabled = false;
            playButton.Enabled = true;
        }

        private void noNormalMappingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Logic.LogicSettings.NormalMappingMethod = NormalMappingMethod.NoMapping;
                Logic.DrawFigure();
            }
        }

        private void normalMappingFromFileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Logic.LogicSettings.NormalMappingMethod = NormalMappingMethod.MapFromFile;
                Logic.DrawFigure();
            }
        }

        private void loadNormalsMapButton_Click(object sender, EventArgs e)
        {
            if (openNormalMapFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(openNormalMapFileDialog.FileName);
                loadNormalsMapButton.Text = openNormalMapFileDialog.FileName.Split('\\').Last();
                Logic.LogicSettings.NormalMapTexture = ResizeImageProportional(image, pictureBox.Width, pictureBox.Height);
                Logic.DrawFigure();
            }
        }
    }
}