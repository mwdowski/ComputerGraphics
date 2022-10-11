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
            this.polygonGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addPolygonButton = new System.Windows.Forms.Button();
            this.deletePolygonButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.mainTableLayoutPanel.SuspendLayout();
            this.controlsTableLayoutPanel.SuspendLayout();
            this.polygonGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.mainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(3);
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1008, 537);
            this.mainTableLayoutPanel.TabIndex = 0;
            this.mainTableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainTableLayoutPanel_Paint);
            // 
            // controlsTableLayoutPanel
            // 
            this.controlsTableLayoutPanel.AutoSize = true;
            this.controlsTableLayoutPanel.ColumnCount = 1;
            this.controlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.controlsTableLayoutPanel.Controls.Add(this.polygonGroupBox, 0, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.groupBox2, 0, 1);
            this.controlsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsTableLayoutPanel.Location = new System.Drawing.Point(855, 3);
            this.controlsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlsTableLayoutPanel.Name = "controlsTableLayoutPanel";
            this.controlsTableLayoutPanel.RowCount = 2;
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlsTableLayoutPanel.Size = new System.Drawing.Size(150, 531);
            this.controlsTableLayoutPanel.TabIndex = 0;
            // 
            // polygonGroupBox
            // 
            this.polygonGroupBox.AutoSize = true;
            this.polygonGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.polygonGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonGroupBox.Location = new System.Drawing.Point(0, 0);
            this.polygonGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.polygonGroupBox.Name = "polygonGroupBox";
            this.polygonGroupBox.Size = new System.Drawing.Size(150, 84);
            this.polygonGroupBox.TabIndex = 0;
            this.polygonGroupBox.TabStop = false;
            this.polygonGroupBox.Text = "Polygons";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.addPolygonButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.deletePolygonButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(144, 62);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // addPolygonButton
            // 
            this.addPolygonButton.AutoSize = true;
            this.addPolygonButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addPolygonButton.Location = new System.Drawing.Point(3, 3);
            this.addPolygonButton.Name = "addPolygonButton";
            this.addPolygonButton.Size = new System.Drawing.Size(138, 25);
            this.addPolygonButton.TabIndex = 0;
            this.addPolygonButton.Text = "Add new polygon";
            this.addPolygonButton.UseVisualStyleBackColor = true;
            // 
            // deletePolygonButton
            // 
            this.deletePolygonButton.AutoSize = true;
            this.deletePolygonButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deletePolygonButton.Location = new System.Drawing.Point(3, 34);
            this.deletePolygonButton.Name = "deletePolygonButton";
            this.deletePolygonButton.Size = new System.Drawing.Size(138, 25);
            this.deletePolygonButton.TabIndex = 1;
            this.deletePolygonButton.Text = "Delete polygon";
            this.deletePolygonButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 84);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 447);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(6, 6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(846, 525);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
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
            this.polygonGroupBox.ResumeLayout(false);
            this.polygonGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel mainTableLayoutPanel;
        private TableLayoutPanel controlsTableLayoutPanel;
        private GroupBox polygonGroupBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Button addPolygonButton;
        private Button deletePolygonButton;
        private GroupBox groupBox2;
        private PictureBox pictureBox;
    }
}