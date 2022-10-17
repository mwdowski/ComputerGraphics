using P1_Polygons.Logic.MainLogic;

namespace P1_Polygons
{
    public partial class MainWindow : Form
    {
        private ProgramLogic Logic;

        private ClickModes _clickMode;
        private ClickModes ClickMode { get => _clickMode; set
            {
                switch (value)
                {
                    case ClickModes.Default:
                        this.pictureBox.Cursor = Cursors.Default;
                        break;
                    case ClickModes.AddPolygon:
                        this.pictureBox.Cursor = Cursors.Cross;
                        break;
                    case ClickModes.DeletePolygon:
                        this.pictureBox.Cursor = Cursors.No;
                        break;
                    case ClickModes.AddingPolygon:
                        this.pictureBox.Cursor = Cursors.Cross;
                        break;
                    case ClickModes.MovingFigure:
                        this.pictureBox.Cursor = Cursors.SizeAll;
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
            Logic = new ProgramLogic(pictureBox);
            ClickMode = ClickModes.Default;
        }

        private void addPolygonButton_Click(object sender, EventArgs e)
        {
            ClickMode = ClickModes.AddPolygon;
        }

        private void deletePolygonButton_Click(object sender, EventArgs e)
        {
            ClickMode = ClickModes.DeletePolygon;
        }

        private Point startingMovingPosition;

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (this.ClickMode)
                    {
                        case ClickModes.Default:
                            var figure = Logic.GetPointedFigure(e.Location);
                            if (figure != null)
                            {
                                Logic.SetSelectedFigure(figure);
                                ClickMode = ClickModes.MovingFigure;
                                startingMovingPosition = e.Location;
                            }
                            break;
                        case ClickModes.AddPolygon:
                            Logic.PolygonCreator.StartPolygonCreation(e.Location);
                            ClickMode = ClickModes.AddingPolygon;
                            break;
                        case ClickModes.DeletePolygon:
                            var polygon = Logic.GetPointedFigure(e.Location)?.GetPolygon();
                            if (polygon != null) Logic.DeletePolygon(polygon);
                            break;
                        case ClickModes.AddingPolygon:
                            switch (Logic.PolygonCreator.AddVertexWhileCreatingPolygon(e.Location))
                            {
                                case CreatingPolygonState.Adding:
                                    break;
                                case CreatingPolygonState.PolygonReady:
                                    ClickMode = ClickModes.Default;
                                    Logic.PolygonCreator.Restart();
                                    break;
                                default:
                                    throw new NotImplementedException();
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (this.ClickMode)
                    {
                        case ClickModes.Default:
                            Logic.GetPointedFigure(e.Location)?.ProcessRightClick();
                            break;
                        case ClickModes.AddPolygon:
                            ClickMode = ClickModes.Default;
                            break;
                        case ClickModes.DeletePolygon:
                            ClickMode = ClickModes.Default;
                            break;
                        case ClickModes.AddingPolygon:
                            Logic.PolygonCreator.Restart();
                            ClickMode = ClickModes.Default;
                            break;
                        default:
                            break;
                    }
                    break;
                case MouseButtons.Middle:
                    switch (this.ClickMode)
                    {
                        case ClickModes.Default:
                            var figure = Logic.GetPointedFigure(e.Location);
                            var polygon = figure?.GetPolygon();
                            if (polygon != null)
                            {
                                Logic.SetSelectedFigure(polygon);
                                ClickMode = ClickModes.MovingFigure;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (this.ClickMode)
                    {
                        case ClickModes.MovingFigure:
                            Logic.MoveSelectedFigureBy(new Point(startingMovingPosition.X - e.Location.X, startingMovingPosition.Y - e.Location.Y));
                            break;
                        default:
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (this.ClickMode)
                    {
                        default:
                            break;
                    }
                    break;
                case MouseButtons.Middle:
                    switch (this.ClickMode)
                    {
                        case ClickModes.MovingFigure:
                            Logic.MoveSelectedFigureBy(new Point(startingMovingPosition.X - e.Location.X, startingMovingPosition.Y - e.Location.Y));
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (this.ClickMode)
                    {
                        case ClickModes.MovingFigure:
                            Logic.SetSelectedFigure(null);
                            ClickMode = ClickModes.Default;
                            break;
                        default:
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (this.ClickMode)
                    {
                        default:
                            break;
                    }
                    break;
                case MouseButtons.Middle:
                    switch (this.ClickMode)
                    {
                        case ClickModes.MovingFigure:
                            Logic.SetSelectedFigure(null);
                            ClickMode = ClickModes.Default;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}