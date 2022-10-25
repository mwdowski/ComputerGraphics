namespace P1_Polygons
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.controlsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.circlesGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addCircleButton = new System.Windows.Forms.Button();
            this.DeleteCircleButton = new System.Windows.Forms.Button();
            this.helperGroupBox = new System.Windows.Forms.GroupBox();
            this.helperTextBox = new System.Windows.Forms.TextBox();
            this.polygonGroupBox = new System.Windows.Forms.GroupBox();
            this.polygonGroupBoxTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.addPolygonButton = new System.Windows.Forms.Button();
            this.deletePolygonButton = new System.Windows.Forms.Button();
            this.lineDrawingGroupBox = new System.Windows.Forms.GroupBox();
            this.lineDrawingGroupBoxTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lineDrawingLibraryRadioButton = new System.Windows.Forms.RadioButton();
            this.lineDrawingOwnRadioButton = new System.Windows.Forms.RadioButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.mainTableLayoutPanel.SuspendLayout();
            this.controlsTableLayoutPanel.SuspendLayout();
            this.circlesGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.helperGroupBox.SuspendLayout();
            this.polygonGroupBox.SuspendLayout();
            this.polygonGroupBoxTableLayoutPanel.SuspendLayout();
            this.lineDrawingGroupBox.SuspendLayout();
            this.lineDrawingGroupBoxTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.AutoSize = true;
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.mainTableLayoutPanel.Controls.Add(this.controlsTableLayoutPanel, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.pictureBox, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1008, 537);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // controlsTableLayoutPanel
            // 
            this.controlsTableLayoutPanel.AutoSize = true;
            this.controlsTableLayoutPanel.ColumnCount = 1;
            this.controlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.controlsTableLayoutPanel.Controls.Add(this.circlesGroupBox, 0, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.helperGroupBox, 0, 3);
            this.controlsTableLayoutPanel.Controls.Add(this.polygonGroupBox, 0, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.lineDrawingGroupBox, 0, 2);
            this.controlsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlsTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.controlsTableLayoutPanel.Location = new System.Drawing.Point(853, 5);
            this.controlsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlsTableLayoutPanel.Name = "controlsTableLayoutPanel";
            this.controlsTableLayoutPanel.RowCount = 5;
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.controlsTableLayoutPanel.Size = new System.Drawing.Size(150, 527);
            this.controlsTableLayoutPanel.TabIndex = 0;
            // 
            // circlesGroupBox
            // 
            this.circlesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circlesGroupBox.AutoSize = true;
            this.circlesGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.circlesGroupBox.Location = new System.Drawing.Point(0, 84);
            this.circlesGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.circlesGroupBox.Name = "circlesGroupBox";
            this.circlesGroupBox.Size = new System.Drawing.Size(156, 84);
            this.circlesGroupBox.TabIndex = 3;
            this.circlesGroupBox.TabStop = false;
            this.circlesGroupBox.Text = "Circles";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.addCircleButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DeleteCircleButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 62);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // addCircleButton
            // 
            this.addCircleButton.AutoSize = true;
            this.addCircleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addCircleButton.Location = new System.Drawing.Point(3, 3);
            this.addCircleButton.Name = "addCircleButton";
            this.addCircleButton.Size = new System.Drawing.Size(144, 25);
            this.addCircleButton.TabIndex = 0;
            this.addCircleButton.Text = "Add new circle";
            this.addCircleButton.UseVisualStyleBackColor = true;
            this.addCircleButton.Click += new System.EventHandler(this.addCircleButton_Click);
            // 
            // DeleteCircleButton
            // 
            this.DeleteCircleButton.AutoSize = true;
            this.DeleteCircleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteCircleButton.Location = new System.Drawing.Point(3, 34);
            this.DeleteCircleButton.Name = "DeleteCircleButton";
            this.DeleteCircleButton.Size = new System.Drawing.Size(144, 25);
            this.DeleteCircleButton.TabIndex = 1;
            this.DeleteCircleButton.Text = "Delete circle";
            this.DeleteCircleButton.UseVisualStyleBackColor = true;
            this.DeleteCircleButton.Click += new System.EventHandler(this.DeleteCircleButton_Click);
            // 
            // helperGroupBox
            // 
            this.helperGroupBox.AutoSize = true;
            this.helperGroupBox.Controls.Add(this.helperTextBox);
            this.helperGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helperGroupBox.Location = new System.Drawing.Point(0, 240);
            this.helperGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.helperGroupBox.Name = "helperGroupBox";
            this.helperGroupBox.Size = new System.Drawing.Size(156, 287);
            this.helperGroupBox.TabIndex = 2;
            this.helperGroupBox.TabStop = false;
            this.helperGroupBox.Text = "Placeholder";
            // 
            // helperTextBox
            // 
            this.helperTextBox.AcceptsReturn = true;
            this.helperTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helperTextBox.Location = new System.Drawing.Point(3, 19);
            this.helperTextBox.MinimumSize = new System.Drawing.Size(0, 200);
            this.helperTextBox.Multiline = true;
            this.helperTextBox.Name = "helperTextBox";
            this.helperTextBox.ReadOnly = true;
            this.helperTextBox.Size = new System.Drawing.Size(147, 200);
            this.helperTextBox.TabIndex = 0;
            this.helperTextBox.Text = "Placeholder";
            // 
            // polygonGroupBox
            // 
            this.polygonGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.polygonGroupBox.AutoSize = true;
            this.polygonGroupBox.Controls.Add(this.polygonGroupBoxTableLayoutPanel);
            this.polygonGroupBox.Location = new System.Drawing.Point(0, 0);
            this.polygonGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.polygonGroupBox.Name = "polygonGroupBox";
            this.polygonGroupBox.Size = new System.Drawing.Size(156, 84);
            this.polygonGroupBox.TabIndex = 0;
            this.polygonGroupBox.TabStop = false;
            this.polygonGroupBox.Text = "Polygons";
            // 
            // polygonGroupBoxTableLayoutPanel
            // 
            this.polygonGroupBoxTableLayoutPanel.AutoSize = true;
            this.polygonGroupBoxTableLayoutPanel.ColumnCount = 1;
            this.polygonGroupBoxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.polygonGroupBoxTableLayoutPanel.Controls.Add(this.addPolygonButton, 0, 0);
            this.polygonGroupBoxTableLayoutPanel.Controls.Add(this.deletePolygonButton, 0, 1);
            this.polygonGroupBoxTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonGroupBoxTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.polygonGroupBoxTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.polygonGroupBoxTableLayoutPanel.Name = "polygonGroupBoxTableLayoutPanel";
            this.polygonGroupBoxTableLayoutPanel.RowCount = 2;
            this.polygonGroupBoxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.polygonGroupBoxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.polygonGroupBoxTableLayoutPanel.Size = new System.Drawing.Size(150, 62);
            this.polygonGroupBoxTableLayoutPanel.TabIndex = 0;
            // 
            // addPolygonButton
            // 
            this.addPolygonButton.AutoSize = true;
            this.addPolygonButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addPolygonButton.Location = new System.Drawing.Point(3, 3);
            this.addPolygonButton.Name = "addPolygonButton";
            this.addPolygonButton.Size = new System.Drawing.Size(144, 25);
            this.addPolygonButton.TabIndex = 0;
            this.addPolygonButton.Text = "Add new polygon";
            this.addPolygonButton.UseVisualStyleBackColor = true;
            this.addPolygonButton.Click += new System.EventHandler(this.addPolygonButton_Click);
            // 
            // deletePolygonButton
            // 
            this.deletePolygonButton.AutoSize = true;
            this.deletePolygonButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deletePolygonButton.Location = new System.Drawing.Point(3, 34);
            this.deletePolygonButton.Name = "deletePolygonButton";
            this.deletePolygonButton.Size = new System.Drawing.Size(144, 25);
            this.deletePolygonButton.TabIndex = 1;
            this.deletePolygonButton.Text = "Delete polygon";
            this.deletePolygonButton.UseVisualStyleBackColor = true;
            this.deletePolygonButton.Click += new System.EventHandler(this.deletePolygonButton_Click);
            // 
            // lineDrawingGroupBox
            // 
            this.lineDrawingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineDrawingGroupBox.AutoSize = true;
            this.lineDrawingGroupBox.Controls.Add(this.lineDrawingGroupBoxTableLayoutPanel);
            this.lineDrawingGroupBox.Location = new System.Drawing.Point(0, 168);
            this.lineDrawingGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.lineDrawingGroupBox.Name = "lineDrawingGroupBox";
            this.lineDrawingGroupBox.Size = new System.Drawing.Size(156, 72);
            this.lineDrawingGroupBox.TabIndex = 1;
            this.lineDrawingGroupBox.TabStop = false;
            this.lineDrawingGroupBox.Text = "Line drawing method";
            // 
            // lineDrawingGroupBoxTableLayoutPanel
            // 
            this.lineDrawingGroupBoxTableLayoutPanel.AutoSize = true;
            this.lineDrawingGroupBoxTableLayoutPanel.ColumnCount = 1;
            this.lineDrawingGroupBoxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lineDrawingGroupBoxTableLayoutPanel.Controls.Add(this.lineDrawingLibraryRadioButton, 0, 0);
            this.lineDrawingGroupBoxTableLayoutPanel.Controls.Add(this.lineDrawingOwnRadioButton, 0, 1);
            this.lineDrawingGroupBoxTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineDrawingGroupBoxTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.lineDrawingGroupBoxTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.lineDrawingGroupBoxTableLayoutPanel.Name = "lineDrawingGroupBoxTableLayoutPanel";
            this.lineDrawingGroupBoxTableLayoutPanel.RowCount = 2;
            this.lineDrawingGroupBoxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.lineDrawingGroupBoxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.lineDrawingGroupBoxTableLayoutPanel.Size = new System.Drawing.Size(150, 50);
            this.lineDrawingGroupBoxTableLayoutPanel.TabIndex = 1;
            // 
            // lineDrawingLibraryRadioButton
            // 
            this.lineDrawingLibraryRadioButton.AutoSize = true;
            this.lineDrawingLibraryRadioButton.Checked = true;
            this.lineDrawingLibraryRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineDrawingLibraryRadioButton.Location = new System.Drawing.Point(3, 3);
            this.lineDrawingLibraryRadioButton.Name = "lineDrawingLibraryRadioButton";
            this.lineDrawingLibraryRadioButton.Size = new System.Drawing.Size(144, 19);
            this.lineDrawingLibraryRadioButton.TabIndex = 0;
            this.lineDrawingLibraryRadioButton.TabStop = true;
            this.lineDrawingLibraryRadioButton.Text = "Library method";
            this.lineDrawingLibraryRadioButton.UseVisualStyleBackColor = true;
            this.lineDrawingLibraryRadioButton.CheckedChanged += new System.EventHandler(this.lineDrawingLibraryRadioButton_CheckedChanged);
            // 
            // lineDrawingOwnRadioButton
            // 
            this.lineDrawingOwnRadioButton.AutoSize = true;
            this.lineDrawingOwnRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineDrawingOwnRadioButton.Location = new System.Drawing.Point(3, 28);
            this.lineDrawingOwnRadioButton.Name = "lineDrawingOwnRadioButton";
            this.lineDrawingOwnRadioButton.Size = new System.Drawing.Size(144, 19);
            this.lineDrawingOwnRadioButton.TabIndex = 1;
            this.lineDrawingOwnRadioButton.Text = "Implemented method";
            this.lineDrawingOwnRadioButton.UseVisualStyleBackColor = true;
            this.lineDrawingOwnRadioButton.CheckedChanged += new System.EventHandler(this.lineDrawingOwnRadioButton_CheckedChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(8, 8);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(842, 521);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 537);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "Computer Grpahics - Polygons";
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.controlsTableLayoutPanel.ResumeLayout(false);
            this.controlsTableLayoutPanel.PerformLayout();
            this.circlesGroupBox.ResumeLayout(false);
            this.circlesGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.helperGroupBox.ResumeLayout(false);
            this.helperGroupBox.PerformLayout();
            this.polygonGroupBox.ResumeLayout(false);
            this.polygonGroupBox.PerformLayout();
            this.polygonGroupBoxTableLayoutPanel.ResumeLayout(false);
            this.polygonGroupBoxTableLayoutPanel.PerformLayout();
            this.lineDrawingGroupBox.ResumeLayout(false);
            this.lineDrawingGroupBox.PerformLayout();
            this.lineDrawingGroupBoxTableLayoutPanel.ResumeLayout(false);
            this.lineDrawingGroupBoxTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel mainTableLayoutPanel;
        private TableLayoutPanel controlsTableLayoutPanel;
        private GroupBox polygonGroupBox;
        private TableLayoutPanel polygonGroupBoxTableLayoutPanel;
        private Button addPolygonButton;
        private Button deletePolygonButton;
        private GroupBox helperGroupBox;
        private GroupBox lineDrawingGroupBox;
        private TableLayoutPanel lineDrawingGroupBoxTableLayoutPanel;
        private RadioButton lineDrawingLibraryRadioButton;
        private RadioButton lineDrawingOwnRadioButton;
        private TextBox helperTextBox;
        public PictureBox pictureBox;
        private GroupBox circlesGroupBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Button addCircleButton;
        private Button DeleteCircleButton;
    }
}