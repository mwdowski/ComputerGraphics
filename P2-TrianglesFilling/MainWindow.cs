using P2_TrianglesFilling.Logic;

namespace P2_TrianglesFilling
{
    public partial class MainWindow : Form
    {
        public ProgramLogic Logic { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Logic = new ProgramLogic(pictureBox);

            m_textBox.Text = Logic.FigureDrawerArguments.m.ToString();
            k_s_textBox.Text = Logic.FigureDrawerArguments.k_s.ToString("0.00");
            k_d_textBox.Text = Logic.FigureDrawerArguments.k_s.ToString("0.00");
            Refresh();
        }

        private void m_trackBar_Scroll(object sender, EventArgs e)
        {
            Logic.FigureDrawerArguments.m = ((TrackBar)sender).Value;
            m_textBox.Text = Logic.FigureDrawerArguments.m.ToString();
            m_textBox.Refresh();
            Logic.DrawFigure();
        }

        private void k_s_trackBar_Scroll(object sender, EventArgs e)
        {
            Logic.FigureDrawerArguments.k_s = ((TrackBar)sender).Value / 100f;
            k_s_textBox.Text = Logic.FigureDrawerArguments.k_s.ToString("0.00");
            k_s_textBox.Refresh();
            Logic.DrawFigure();
        }

        private void k_d_trackBar_Scroll(object sender, EventArgs e)
        {
            Logic.FigureDrawerArguments.k_d = ((TrackBar)sender).Value / 100f;
            k_d_textBox.Text = Logic.FigureDrawerArguments.k_d.ToString("0.00");
            k_d_textBox.Refresh();
            Logic.DrawFigure();
        }
    }
}