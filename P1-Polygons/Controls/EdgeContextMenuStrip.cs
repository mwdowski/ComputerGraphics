using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Controls
{
    public class EdgeContextMenuStrip : ContextMenuStrip
    {
        public Edge Edge { get; }
        public EdgeContextMenuStrip(Edge edge) : base()
        {
            Edge = edge;
            Items.Add("Edge");
            Items.Add("Remove", null, (_, _) => edge.Remove());
            Items.Add("Add vertex in the middle", null, (_, _) => edge.DivideEdgeWithVertexOnMiddle());

            AddRestrictionsButtons();
        }

        private void AddRestrictionsButtons()
        {
            if (Edge.EdgeRestrictions.Any(_ => _.GetType() == typeof(LengthRestritcion)))
            {
                Items.Add("Remove length restriction", null, (_, _) => RemoveLengthRestriction());
            }
            else
            {
                Items.Add("Add length restriction", null, (_, _) => AddLengthRestriction());
            }
            Items.Add("Clear all perpendicularity restrictions", null, (_, _) => RemovePerpendicularityRestrictions());
        }

        private void RemovePerpendicularityRestrictions()
        {
            foreach (var restriction in Edge.EdgeRestrictions.Where(_ => _ is PerpendicularityRestriction).Cast<PerpendicularityRestriction>())
            {
                restriction.Remove();
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            TextBox textBox = new TextBox();
            textBox.Text = promptText;
            textBox.SetBounds(20, 20, 160, 40);

            Button buttonOk = new Button();
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.SetBounds(20, 50, 70, 30);
            buttonOk.Text = "OK";

            Button buttonCancel = new Button();
            buttonCancel.Text = "Cancel";
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.SetBounds(110, 50, 70, 30);

            Form form = new Form();
            form.Text = title;
            form.ClientSize = new Size(200, 100);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.Controls.AddRange(new Control[] { textBox, buttonOk, buttonCancel });
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;

            return dialogResult;
        }

        private void AddLengthRestriction()
        {
            string result = "";
            if (InputBox("Set length", Edge.Length.ToString("0.0000"), ref result) == DialogResult.OK)
            {
                try
                {
                    float length = float.Parse(result);
                    Edge.AddRestriction(new LengthRestritcion(Edge, length));
                }
                catch
                {
                    MessageBox.Show("Incorrect input. Aborting action.");
                }
            }
        }

        private void RemoveLengthRestriction()
        {
            Edge.EdgeRestrictions = Edge.EdgeRestrictions.Where(_ => _.GetType() != typeof(LengthRestritcion)).ToList();
        }
    }
}
