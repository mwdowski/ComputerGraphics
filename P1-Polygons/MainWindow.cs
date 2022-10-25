using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Logic.MainLogic;
using P1_Polygons.Logic.MainLogic.FigureDrawers;
using P1_Polygons.Model;

namespace P1_Polygons
{
    public partial class MainWindow : Form
    {
        private ProgramLogic Logic;

        private ClickModes _clickMode;
        public ClickModes ClickMode { get => _clickMode; set
            {
                switch (value)
                {
                    case ClickModes.Default:
                        this.pictureBox.Cursor = Cursors.Default;
                        this.addPolygonButton.Enabled = true;
                        this.deletePolygonButton.Enabled = true;
                        this.addCircleButton.Enabled = true;
                        this.DeleteCircleButton.Enabled = true;
                        break;
                    case ClickModes.AddPolygon:
                        this.pictureBox.Cursor = Cursors.Cross;
                        this.addPolygonButton.Enabled = false;
                        this.deletePolygonButton.Enabled = false;
                        this.addCircleButton.Enabled = false;
                        this.DeleteCircleButton.Enabled = false;
                        break;
                    case ClickModes.DeletePolygon:
                        this.pictureBox.Cursor = Cursors.No;
                        this.addPolygonButton.Enabled = false;
                        this.deletePolygonButton.Enabled = false;
                        this.addCircleButton.Enabled = false;
                        this.DeleteCircleButton.Enabled = false;
                        break;
                    case ClickModes.AddingPolygon:
                        this.pictureBox.Cursor = Cursors.Cross;
                        this.addPolygonButton.Enabled = false;
                        this.deletePolygonButton.Enabled = false;
                        this.addCircleButton.Enabled = false;
                        this.DeleteCircleButton.Enabled = false;
                        break;
                    case ClickModes.MovingFigure:
                        this.pictureBox.Cursor = Cursors.SizeAll;
                        break;
                    case ClickModes.SelectingPerpendicularEdge:
                        this.pictureBox.Cursor = Cursors.Cross;
                        break;
                    case ClickModes.AddingCircle:
                        this.pictureBox.Cursor = Cursors.Cross;
                        this.addPolygonButton.Enabled = false;
                        this.deletePolygonButton.Enabled = false;
                        this.addCircleButton.Enabled = false;
                        this.DeleteCircleButton.Enabled = false;
                        break;
                    case ClickModes.AddCircle:
                        this.pictureBox.Cursor = Cursors.Cross;
                        this.addPolygonButton.Enabled = false;
                        this.deletePolygonButton.Enabled = false;
                        this.addCircleButton.Enabled = false;
                        this.DeleteCircleButton.Enabled = false;
                        break;
                    case ClickModes.DeleteCircle:
                        this.pictureBox.Cursor = Cursors.No;
                        this.addPolygonButton.Enabled = false;
                        this.deletePolygonButton.Enabled = false;
                        this.addCircleButton.Enabled = false;
                        this.DeleteCircleButton.Enabled = false;
                        break;
                    case ClickModes.ResizeCircle:
                        this.pictureBox.Cursor = Cursors.SizeAll;
                        this.addPolygonButton.Enabled = false;
                        this.deletePolygonButton.Enabled = false;
                        this.addCircleButton.Enabled = false;
                        this.DeleteCircleButton.Enabled = false;
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

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (this.ClickMode)
                    {
                        case ClickModes.Default:
                            Logic.FigureSelector.SelectByClick(e.Location);
                            if (Logic.FigureSelector.SelectedFigure != null)
                            {
                                if (Logic.FigureSelector.SelectedFigure is Circle)
                                {
                                    ClickMode = ClickModes.ResizeCircle;
                                }
                                else
                                {
                                    Logic.FigureMover.StartMovement(e.Location, Logic.FigureSelector.SelectedFigure);
                                    ClickMode = ClickModes.MovingFigure;
                                }
                            }
                            break;
                        case ClickModes.AddPolygon:
                            Logic.PolygonCreator.StartPolygonCreation(e.Location);
                            ClickMode = ClickModes.AddingPolygon;
                            break;
                        case ClickModes.DeletePolygon:
                            Logic.FigureSelector.SelectByClick(e.Location);
                            if (Logic.FigureSelector.SelectedFigure?.GetPolygon() != null)
                            {
                                Logic.DeletePolygon(Logic.FigureSelector.SelectedFigure.GetPolygon());
                                Logic.FigureSelector.ClearSelection();
                                ClickMode = ClickModes.Default;
                            }
                            break;
                        case ClickModes.AddingPolygon:
                            switch (Logic.PolygonCreator.AddVertexWhileCreatingPolygon(e.Location))
                            {
                                case CreatingPolygonState.Adding:
                                    break;
                                case CreatingPolygonState.PolygonReady:
                                    ClickMode = ClickModes.Default;
                                    Logic.GetPolygonFromCreator();
                                    Logic.PolygonCreator.Restart();
                                    break;
                                default:
                                    throw new NotImplementedException();
                            }
                            break;
                        case ClickModes.SelectingPerpendicularEdge:
                            if (Logic.FigureSelector.SelectedFigure is Edge)
                            {
                                Edge potentialEdge = (Edge)Logic.FigureSelector.SelectedFigure!;
                                Logic.FigureSelector.SelectByClick(e.Location);
                                if (Logic.FigureSelector.SelectedFigure != null && Logic.FigureSelector.SelectedFigure is Edge)
                                {
                                    var newRestriction = new PerpendicularityRestriction(potentialEdge, (Edge)Logic.FigureSelector.SelectedFigure!);
                                    newRestriction.Initialize();
                                }
                            }
                            ClickMode = ClickModes.Default;

                            break;

                        case ClickModes.AddCircle:
                            Logic.CircleCreator.SelectStartingPoint(e.Location);
                            ClickMode = ClickModes.AddingCircle;
                            break;

                        case ClickModes.AddingCircle:
                            Logic.CircleCreator.SelectRadiusPoint(e.Location);
                            if (Logic.CircleCreator.GetCreatedCircle() != null)
                            {
                                Logic.Circles.Add(Logic.CircleCreator.GetCreatedCircle()!);
                                Logic.CircleCreator.Restart();
                            }
                            ClickMode = ClickModes.Default;
                            break;

                        case ClickModes.DeleteCircle:
                            Logic.FigureSelector.SelectByClick(e.Location);
                            if (Logic.FigureSelector.SelectedFigure is Circle)
                            {
                                Logic.DeleteCircle((Circle)Logic.FigureSelector.SelectedFigure);
                                Logic.FigureSelector.ClearSelection();
                                ClickMode = ClickModes.Default;
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
                            Logic.FigureSelector.SelectByClick(e.Location);
                            Logic.FigureSelector.SelectedFigure?.ShowContextMenu(this, e.Location);
                            break;
                        case ClickModes.AddPolygon:
                        case ClickModes.AddCircle:
                        case ClickModes.DeletePolygon:
                        case ClickModes.DeleteCircle:
                            ClickMode = ClickModes.Default;
                            break;
                        case ClickModes.AddingPolygon:
                            Logic.CircleCreator.Restart();
                            ClickMode = ClickModes.Default;
                            break;
                        case ClickModes.SelectingPerpendicularEdge:
                            Logic.FigureSelector.ClearSelection();
                            ClickMode = ClickModes.Default;
                            break;
                        case ClickModes.AddingCircle:
                            Logic.CircleCreator.Restart();
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
                            Logic.FigureSelector.SelectByClick(e.Location);
                            if (Logic.FigureSelector.SelectedFigure?.GetPolygon() != null)
                            {
                                Logic.FigureMover.StartMovement(e.Location, Logic.FigureSelector.SelectedFigure.GetPolygon());
                                ClickMode = ClickModes.MovingFigure;
                            }
                            if (Logic.FigureSelector.SelectedFigure is Circle)
                            {
                                Logic.FigureMover.StartMovement(e.Location, (Circle) Logic.FigureSelector.SelectedFigure);
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
            Logic.DrawScene();
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (this.ClickMode)
                    {
                        case ClickModes.MovingFigure:
                            Logic.FigureMover.Move(e.Location);
                            break;
                        case ClickModes.ResizeCircle:
                            ((Circle)Logic.FigureSelector.SelectedFigure).Resize(e.Location, Logic.Rasterizer);
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
                            Logic.FigureMover.Move(e.Location);
                            break;
                        default:
                            break;
                    }
                    break;
                case MouseButtons.None:
                    switch(this.ClickMode)
                    {
                        case ClickModes.AddingCircle:
                            Logic.CircleCreator.SetPotentialPoint(e.Location);
                            break;
                    }
                    break;
                default:
                    break;
            }
            Logic.DrawScene();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (this.ClickMode)
                    {
                        case ClickModes.MovingFigure:
                            Logic.FigureMover.FinishMovement();
                            ClickMode = ClickModes.Default;
                            break;
                        case ClickModes.ResizeCircle:
                            Logic.FigureSelector.ClearSelection();
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
                            Logic.FigureMover.FinishMovement();
                            ClickMode = ClickModes.Default;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            Logic.DrawScene();
        }

        private void lineDrawingLibraryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Logic.FigureDrawer = new FigureDrawer(Logic.Rasterizer);
            Logic.DrawScene();
        }

        private void lineDrawingOwnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Logic.FigureDrawer = new MyFigureDrawer(Logic.Rasterizer);
            Logic.DrawScene();
        }

        private void addCircleButton_Click(object sender, EventArgs e)
        {
            ClickMode = ClickModes.AddCircle;
        }

        private void DeleteCircleButton_Click(object sender, EventArgs e)
        {
            ClickMode = ClickModes.DeleteCircle;
        }
    }
}