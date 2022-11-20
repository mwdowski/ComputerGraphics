using P2_TrianglesFilling.Logic;
using System.Windows.Forms;

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
                (value) => Console.WriteLine("TODO"),
                (value) => Console.WriteLine("TODO"),
                (value) => Console.WriteLine("TODO"),
                (value) => Console.WriteLine("TODO"),
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
                var image = Image.FromFile(openObjectImageFileDialog.FileName);
                loadObjectImageButton.Text = openObjectImageFileDialog.FileName.Split('\\').Last();
                Logic.LogicSettings.ObjectTexture = (new Bitmap(image));
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
    }
}