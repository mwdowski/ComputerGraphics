using P1_Polygons.Logic.MainLogic;
using P1_Polygons.Model;

namespace P1_Polygons
{
    public partial class MainWindow : Form
    {
        private IDrawingLogic _logic;

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
            _logic = new DrawingLogic(pictureBox);
            ClickMode = ClickModes.Default;
        }

        /*
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (this.clickMode)
                    {
                        case ClickMode.Default:
                            var figure = _logic.GetPointedFigure(e.Location);
                            _logic.SetSelectedFigure(figure);
                            break;
                        case ClickMode.AddPolygon:
                            _logic.StartPolygonCreation(e.Location);
                            clickMode = ClickMode.AddingPolygon;
                            break;
                        case ClickMode.DeletePolygon:
                            var polygon = _logic.GetPointedFigure(e.Location)?.GetPolygon();
                            if (polygon != null) _logic.DeletePolygon(polygon);
                            break;
                        case ClickMode.AddingPolygon:
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
                            _logic.GetPointedFigure(e.Location)?.ProcessRightClick();
                            break;
                        case ClickMode.AddPolygon:
                            clickMode = ClickMode.Default;
                            break;
                        case ClickMode.DeletePolygon:
                            clickMode = ClickMode.Default;
                            break;
                        case ClickMode.AddingPolygon:
                            _logic.AbortCreatingPolygon();
                            clickMode = ClickMode.Default;
                            break;
                        default:
                            break;
                    }
                    break;
                case MouseButtons.Middle:
                    switch (this.clickMode)
                    {
                        case ClickMode.Default:
                            var polygon = _logic.GetPointedFigure(e.Location)?.GetPolygon();
                            if (polygon != null) _logic.MovePolygon(polygon, e.Location);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        */

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
                            var figure = _logic.GetPointedFigure(e.Location);
                            if (figure != null)
                            {
                                _logic.SetSelectedFigure(figure);
                                ClickMode = ClickModes.MovingFigure;
                                startingMovingPosition = e.Location;
                            }
                            break;
                        case ClickModes.AddPolygon:
                            _logic.StartPolygonCreation(e.Location);
                            ClickMode = ClickModes.AddingPolygon;
                            break;
                        case ClickModes.DeletePolygon:
                            var polygon = _logic.GetPointedFigure(e.Location)?.GetPolygon();
                            if (polygon != null) _logic.DeletePolygon(polygon);
                            break;
                        case ClickModes.AddingPolygon:
                            switch (_logic.AddVertexWhileCreatingPolygon(e.Location))
                            {
                                case CreatingPolygonState.FinishedWithError:
                                    ClickMode = ClickModes.Default;
                                    _logic.AbortCreatingPolygon();
                                    break;
                                case CreatingPolygonState.FinishedWithSuccess:
                                    ClickMode = ClickModes.Default;
                                    _logic.AbortCreatingPolygon();
                                    break;
                                case CreatingPolygonState.Adding:
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
                            _logic.GetPointedFigure(e.Location)?.ProcessRightClick();
                            break;
                        case ClickModes.AddPolygon:
                            ClickMode = ClickModes.Default;
                            break;
                        case ClickModes.DeletePolygon:
                            ClickMode = ClickModes.Default;
                            break;
                        case ClickModes.AddingPolygon:
                            _logic.AbortCreatingPolygon();
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
                            var figure = _logic.GetPointedFigure(e.Location);
                            var polygon = figure?.GetPolygon();
                            if (polygon != null)
                            {
                                _logic.SetSelectedFigure(polygon);
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
                            _logic.MoveSelectedFigureBy(new Point(startingMovingPosition.X - e.Location.X, startingMovingPosition.Y - e.Location.Y));
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
                            _logic.MoveSelectedFigureBy(new Point(startingMovingPosition.X - e.Location.X, startingMovingPosition.Y - e.Location.Y));
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
                            _logic.SetSelectedFigure(null);
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
                            _logic.SetSelectedFigure(null);
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