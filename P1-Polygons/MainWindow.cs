using P1_Polygons.Logic.MainLogic;

namespace P1_Polygons
{
    public partial class MainWindow : Form
    {
        private IDrawingLogic _logic;

        private ClickMode _clickMode;
        private ClickMode clickMode { get => _clickMode; set
            {
                switch (value)
                {
                    case ClickMode.Default:
                        this.pictureBox.Cursor = Cursors.Default;
                        break;
                    case ClickMode.AddPolygon:
                        this.pictureBox.Cursor = Cursors.Cross;
                        break;
                    case ClickMode.DeletePolygon:
                        this.pictureBox.Cursor = Cursors.No;
                        break;
                    case ClickMode.CreatingPolygon:
                        this.pictureBox.Cursor = Cursors.Cross;
                        break;
                    default:
                        throw new NotImplementedException();
                }
                this.helperGroupBox.Text = ClickModeText.GetModeName(value);
                this.helperTextBox.Lines = ClickModeText.GetModeControlDescription(value);
                this._clickMode = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            _logic = new DrawingLogic(pictureBox);
            clickMode = ClickMode.Default;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (this.clickMode)
                    {
                        case ClickMode.Default:
                            _logic.GetSelectedFigure(e.Location)?.ProcessLeftClick();
                            break;
                        case ClickMode.AddPolygon:
                            _logic.StartPolygonCreation(e.Location);
                            clickMode = ClickMode.CreatingPolygon;
                            break;
                        case ClickMode.DeletePolygon:
                            var polygon = _logic.GetSelectedFigure(e.Location)?.GetPolygon();
                            if (polygon != null) _logic.DeletePolygon(polygon);
                            break;
                        case ClickMode.CreatingPolygon:
                            _logic.AddVertexWhileCreatingPolygon(e.Location);
                            break;
                        default:
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (this.clickMode)
                    {
                        case ClickMode.Default:
                            _logic.GetSelectedFigure(e.Location)?.ProcessRightClick();
                            break;
                        case ClickMode.AddPolygon:
                            clickMode = ClickMode.Default;
                            break;
                        case ClickMode.DeletePolygon:
                            clickMode = ClickMode.Default;
                            break;
                        case ClickMode.CreatingPolygon:
                            _logic.AbortCreatingPolygon();
                            clickMode = ClickMode.Default;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void addPolygonButton_Click(object sender, EventArgs e)
        {
            clickMode = ClickMode.AddPolygon;
        }

        private void deletePolygonButton_Click(object sender, EventArgs e)
        {
            clickMode = ClickMode.DeletePolygon;
        }
    }
}