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
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Logic.DrawFigure();
        }
    }
}