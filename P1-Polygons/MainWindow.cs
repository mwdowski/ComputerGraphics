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
                        break;
                    case ClickModes.AddPolygon:
                        this.pictureBox.Cursor = Cursors.Cross;
                        this.addPolygonButton.Enabled = false;
                        this.deletePolygonButton.Enabled = false;
                        break;
                    case ClickModes.DeletePolygon:
                        this.pictureBox.Cursor = Cursors.No;
                        this.addPolygonButton.Enabled = false;
                        this.deletePolygonButton.Enabled = false;
                        break;
                    case ClickModes.AddingPolygon:
                        this.pictureBox.Cursor = Cursors.Cross;
                        this.addPolygonButton.Enabled = false;
                        this.deletePolygonButton.Enabled = false;
                        break;
                    case ClickModes.MovingFigure:
                        this.pictureBox.Cursor = Cursors.SizeAll;
                        break;
                    case ClickModes.SelectingPerpendicularEdge:
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
                                Logic.FigureMover.StartMovement(e.Location, Logic.FigureSelector.SelectedFigure);
                                ClickMode = ClickModes.MovingFigure;
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
                            ClickMode = ClickModes.Default;
                            break;
                        case ClickModes.DeletePolygon:
                            ClickMode = ClickModes.Default;
                            break;
                        case ClickModes.AddingPolygon:
                            Logic.PolygonCreator.Restart();
                            ClickMode = ClickModes.Default;
                            break;
                        case ClickModes.SelectingPerpendicularEdge:
                            Logic.FigureSelector.ClearSelection();
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
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            Logic.DrawPolygons();
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
                default:
                    break;
            }
            Logic.DrawPolygons();
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
            Logic.DrawPolygons();
        }

        private void lineDrawingLibraryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Logic.FigureDrawer = new FigureDrawer(Logic.Rasterizer);
            Logic.DrawPolygons();
        }

        private void lineDrawingOwnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Logic.FigureDrawer = new MyFigureDrawer(Logic.Rasterizer);
            Logic.DrawPolygons();
        }
    }
}