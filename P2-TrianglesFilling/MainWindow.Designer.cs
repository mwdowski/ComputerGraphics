﻿namespace P2_TrianglesFilling
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
            this.components = new System.ComponentModel.Container();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.controlsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lightModelGroupBox = new System.Windows.Forms.GroupBox();
            this.lightModelTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.k_s_trackBar = new System.Windows.Forms.TrackBar();
            this.k_d_trackBar = new System.Windows.Forms.TrackBar();
            this.m_trackBar = new System.Windows.Forms.TrackBar();
            this.k_s_textBox = new System.Windows.Forms.TextBox();
            this.k_d_textBox = new System.Windows.Forms.TextBox();
            this.m_textBox = new System.Windows.Forms.TextBox();
            this.objectColorGroupBox = new System.Windows.Forms.GroupBox();
            this.objectColorTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.oneColorObjectRadioButton = new System.Windows.Forms.RadioButton();
            this.imageColorObjectRadioButton = new System.Windows.Forms.RadioButton();
            this.objectColorPanel = new System.Windows.Forms.Panel();
            this.loadObjectImageButton = new System.Windows.Forms.Button();
            this.paintMethodGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.colorInterpolationRadioButton = new System.Windows.Forms.RadioButton();
            this.normalsInterpolationRadioButton = new System.Windows.Forms.RadioButton();
            this.objectColorDialog = new System.Windows.Forms.ColorDialog();
            this.openObjectImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.programLogicBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.programLogicBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.controlsTableLayoutPanel.SuspendLayout();
            this.lightModelGroupBox.SuspendLayout();
            this.lightModelTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k_s_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.k_d_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackBar)).BeginInit();
            this.objectColorGroupBox.SuspendLayout();
            this.objectColorTableLayoutPanel.SuspendLayout();
            this.paintMethodGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programLogicBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programLogicBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.mainTableLayoutPanel.Controls.Add(this.pictureBox, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.controlsTableLayoutPanel, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1350, 729);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1104, 723);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // controlsTableLayoutPanel
            // 
            this.controlsTableLayoutPanel.ColumnCount = 1;
            this.controlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlsTableLayoutPanel.Controls.Add(this.lightModelGroupBox, 0, 0);
            this.controlsTableLayoutPanel.Controls.Add(this.objectColorGroupBox, 0, 1);
            this.controlsTableLayoutPanel.Controls.Add(this.paintMethodGroupBox, 0, 2);
            this.controlsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsTableLayoutPanel.Location = new System.Drawing.Point(1113, 3);
            this.controlsTableLayoutPanel.Name = "controlsTableLayoutPanel";
            this.controlsTableLayoutPanel.RowCount = 5;
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.controlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.controlsTableLayoutPanel.Size = new System.Drawing.Size(234, 723);
            this.controlsTableLayoutPanel.TabIndex = 1;
            // 
            // lightModelGroupBox
            // 
            this.lightModelGroupBox.AutoSize = true;
            this.lightModelGroupBox.Controls.Add(this.lightModelTableLayoutPanel);
            this.lightModelGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightModelGroupBox.Location = new System.Drawing.Point(3, 3);
            this.lightModelGroupBox.Name = "lightModelGroupBox";
            this.lightModelGroupBox.Size = new System.Drawing.Size(228, 112);
            this.lightModelGroupBox.TabIndex = 0;
            this.lightModelGroupBox.TabStop = false;
            this.lightModelGroupBox.Text = "Light model parameters";
            // 
            // lightModelTableLayoutPanel
            // 
            this.lightModelTableLayoutPanel.AutoSize = true;
            this.lightModelTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lightModelTableLayoutPanel.ColumnCount = 3;
            this.lightModelTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.lightModelTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lightModelTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.lightModelTableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.lightModelTableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.lightModelTableLayoutPanel.Controls.Add(this.label3, 0, 2);
            this.lightModelTableLayoutPanel.Controls.Add(this.k_s_trackBar, 1, 0);
            this.lightModelTableLayoutPanel.Controls.Add(this.k_d_trackBar, 1, 1);
            this.lightModelTableLayoutPanel.Controls.Add(this.m_trackBar, 1, 2);
            this.lightModelTableLayoutPanel.Controls.Add(this.k_s_textBox, 2, 0);
            this.lightModelTableLayoutPanel.Controls.Add(this.k_d_textBox, 2, 1);
            this.lightModelTableLayoutPanel.Controls.Add(this.m_textBox, 2, 2);
            this.lightModelTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightModelTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.lightModelTableLayoutPanel.Name = "lightModelTableLayoutPanel";
            this.lightModelTableLayoutPanel.RowCount = 3;
            this.lightModelTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.lightModelTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.lightModelTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.lightModelTableLayoutPanel.Size = new System.Drawing.Size(222, 90);
            this.lightModelTableLayoutPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "k_s";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "k_d";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "m";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // k_s_trackBar
            // 
            this.k_s_trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k_s_trackBar.LargeChange = 10;
            this.k_s_trackBar.Location = new System.Drawing.Point(43, 3);
            this.k_s_trackBar.Maximum = 100;
            this.k_s_trackBar.Name = "k_s_trackBar";
            this.k_s_trackBar.Size = new System.Drawing.Size(136, 24);
            this.k_s_trackBar.TabIndex = 3;
            this.k_s_trackBar.TickFrequency = 10;
            this.k_s_trackBar.Value = 50;
            this.k_s_trackBar.Scroll += new System.EventHandler(this.k_s_trackBar_Scroll);
            // 
            // k_d_trackBar
            // 
            this.k_d_trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k_d_trackBar.LargeChange = 10;
            this.k_d_trackBar.Location = new System.Drawing.Point(43, 33);
            this.k_d_trackBar.Maximum = 100;
            this.k_d_trackBar.Name = "k_d_trackBar";
            this.k_d_trackBar.Size = new System.Drawing.Size(136, 24);
            this.k_d_trackBar.TabIndex = 4;
            this.k_d_trackBar.TickFrequency = 10;
            this.k_d_trackBar.Value = 50;
            this.k_d_trackBar.Scroll += new System.EventHandler(this.k_d_trackBar_Scroll);
            // 
            // m_trackBar
            // 
            this.m_trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trackBar.LargeChange = 10;
            this.m_trackBar.Location = new System.Drawing.Point(43, 63);
            this.m_trackBar.Maximum = 100;
            this.m_trackBar.Minimum = 1;
            this.m_trackBar.Name = "m_trackBar";
            this.m_trackBar.Size = new System.Drawing.Size(136, 24);
            this.m_trackBar.TabIndex = 5;
            this.m_trackBar.TickFrequency = 10;
            this.m_trackBar.Value = 5;
            this.m_trackBar.Scroll += new System.EventHandler(this.m_trackBar_Scroll);
            // 
            // k_s_textBox
            // 
            this.k_s_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k_s_textBox.Enabled = false;
            this.k_s_textBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.k_s_textBox.Location = new System.Drawing.Point(185, 3);
            this.k_s_textBox.Name = "k_s_textBox";
            this.k_s_textBox.Size = new System.Drawing.Size(34, 23);
            this.k_s_textBox.TabIndex = 6;
            this.k_s_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // k_d_textBox
            // 
            this.k_d_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k_d_textBox.Enabled = false;
            this.k_d_textBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.k_d_textBox.Location = new System.Drawing.Point(185, 33);
            this.k_d_textBox.Name = "k_d_textBox";
            this.k_d_textBox.Size = new System.Drawing.Size(34, 23);
            this.k_d_textBox.TabIndex = 7;
            this.k_d_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_textBox
            // 
            this.m_textBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_textBox.Enabled = false;
            this.m_textBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_textBox.Location = new System.Drawing.Point(185, 63);
            this.m_textBox.Name = "m_textBox";
            this.m_textBox.Size = new System.Drawing.Size(34, 23);
            this.m_textBox.TabIndex = 8;
            this.m_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // objectColorGroupBox
            // 
            this.objectColorGroupBox.AutoSize = true;
            this.objectColorGroupBox.Controls.Add(this.objectColorTableLayoutPanel);
            this.objectColorGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectColorGroupBox.Location = new System.Drawing.Point(3, 121);
            this.objectColorGroupBox.Name = "objectColorGroupBox";
            this.objectColorGroupBox.Size = new System.Drawing.Size(228, 100);
            this.objectColorGroupBox.TabIndex = 1;
            this.objectColorGroupBox.TabStop = false;
            this.objectColorGroupBox.Text = "Object color parameters";
            // 
            // objectColorTableLayoutPanel
            // 
            this.objectColorTableLayoutPanel.AutoSize = true;
            this.objectColorTableLayoutPanel.ColumnCount = 2;
            this.objectColorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.objectColorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.objectColorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.objectColorTableLayoutPanel.Controls.Add(this.oneColorObjectRadioButton, 0, 0);
            this.objectColorTableLayoutPanel.Controls.Add(this.imageColorObjectRadioButton, 0, 1);
            this.objectColorTableLayoutPanel.Controls.Add(this.objectColorPanel, 1, 0);
            this.objectColorTableLayoutPanel.Controls.Add(this.loadObjectImageButton, 1, 1);
            this.objectColorTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectColorTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.objectColorTableLayoutPanel.Name = "objectColorTableLayoutPanel";
            this.objectColorTableLayoutPanel.RowCount = 2;
            this.objectColorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.objectColorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.objectColorTableLayoutPanel.Size = new System.Drawing.Size(222, 78);
            this.objectColorTableLayoutPanel.TabIndex = 0;
            // 
            // oneColorObjectRadioButton
            // 
            this.oneColorObjectRadioButton.AutoSize = true;
            this.oneColorObjectRadioButton.Checked = true;
            this.oneColorObjectRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oneColorObjectRadioButton.Location = new System.Drawing.Point(3, 3);
            this.oneColorObjectRadioButton.Name = "oneColorObjectRadioButton";
            this.oneColorObjectRadioButton.Size = new System.Drawing.Size(77, 33);
            this.oneColorObjectRadioButton.TabIndex = 0;
            this.oneColorObjectRadioButton.TabStop = true;
            this.oneColorObjectRadioButton.Text = "One color";
            this.oneColorObjectRadioButton.UseVisualStyleBackColor = true;
            this.oneColorObjectRadioButton.CheckedChanged += new System.EventHandler(this.oneColorObjectRadioButton_CheckedChanged);
            // 
            // imageColorObjectRadioButton
            // 
            this.imageColorObjectRadioButton.AutoSize = true;
            this.imageColorObjectRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageColorObjectRadioButton.Location = new System.Drawing.Point(3, 42);
            this.imageColorObjectRadioButton.Name = "imageColorObjectRadioButton";
            this.imageColorObjectRadioButton.Size = new System.Drawing.Size(77, 33);
            this.imageColorObjectRadioButton.TabIndex = 1;
            this.imageColorObjectRadioButton.TabStop = true;
            this.imageColorObjectRadioButton.Text = "Image";
            this.imageColorObjectRadioButton.UseVisualStyleBackColor = true;
            this.imageColorObjectRadioButton.CheckedChanged += new System.EventHandler(this.imageColorObjectRadioButton_CheckedChanged);
            // 
            // objectColorPanel
            // 
            this.objectColorPanel.AutoSize = true;
            this.objectColorPanel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.objectColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.objectColorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectColorPanel.Location = new System.Drawing.Point(86, 3);
            this.objectColorPanel.Name = "objectColorPanel";
            this.objectColorPanel.Size = new System.Drawing.Size(133, 33);
            this.objectColorPanel.TabIndex = 4;
            this.objectColorPanel.Click += new System.EventHandler(this.objectColorPanel_Click);
            // 
            // loadObjectImageButton
            // 
            this.loadObjectImageButton.AutoSize = true;
            this.loadObjectImageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadObjectImageButton.Location = new System.Drawing.Point(86, 42);
            this.loadObjectImageButton.Name = "loadObjectImageButton";
            this.loadObjectImageButton.Size = new System.Drawing.Size(133, 33);
            this.loadObjectImageButton.TabIndex = 5;
            this.loadObjectImageButton.Text = "Load file";
            this.loadObjectImageButton.UseVisualStyleBackColor = true;
            this.loadObjectImageButton.Click += new System.EventHandler(this.loadObjectImageButton_Click);
            // 
            // paintMethodGroupBox
            // 
            this.paintMethodGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paintMethodGroupBox.AutoSize = true;
            this.paintMethodGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.paintMethodGroupBox.Location = new System.Drawing.Point(3, 227);
            this.paintMethodGroupBox.Name = "paintMethodGroupBox";
            this.paintMethodGroupBox.Size = new System.Drawing.Size(228, 72);
            this.paintMethodGroupBox.TabIndex = 2;
            this.paintMethodGroupBox.TabStop = false;
            this.paintMethodGroupBox.Text = "Paint method";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.colorInterpolationRadioButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.normalsInterpolationRadioButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(222, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // colorInterpolationRadioButton
            // 
            this.colorInterpolationRadioButton.AutoSize = true;
            this.colorInterpolationRadioButton.Checked = true;
            this.colorInterpolationRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorInterpolationRadioButton.Location = new System.Drawing.Point(3, 3);
            this.colorInterpolationRadioButton.Name = "colorInterpolationRadioButton";
            this.colorInterpolationRadioButton.Size = new System.Drawing.Size(216, 19);
            this.colorInterpolationRadioButton.TabIndex = 0;
            this.colorInterpolationRadioButton.TabStop = true;
            this.colorInterpolationRadioButton.Text = "Interpolation from vertices\' color";
            this.colorInterpolationRadioButton.UseVisualStyleBackColor = true;
            this.colorInterpolationRadioButton.CheckedChanged += new System.EventHandler(this.colorInterpolationRadioButton_CheckedChanged);
            // 
            // normalsInterpolationRadioButton
            // 
            this.normalsInterpolationRadioButton.AutoSize = true;
            this.normalsInterpolationRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.normalsInterpolationRadioButton.Location = new System.Drawing.Point(3, 28);
            this.normalsInterpolationRadioButton.Name = "normalsInterpolationRadioButton";
            this.normalsInterpolationRadioButton.Size = new System.Drawing.Size(216, 19);
            this.normalsInterpolationRadioButton.TabIndex = 1;
            this.normalsInterpolationRadioButton.Text = "Normal vectors\' interpolation";
            this.normalsInterpolationRadioButton.UseVisualStyleBackColor = true;
            this.normalsInterpolationRadioButton.CheckedChanged += new System.EventHandler(this.normalsInterpolationRadioButton_CheckedChanged);
            // 
            // openObjectImageFileDialog
            // 
            this.openObjectImageFileDialog.FileName = "openFileDialog1";
            // 
            // programLogicBindingSource
            // 
            this.programLogicBindingSource.DataSource = typeof(P2_TrianglesFilling.Logic.ProgramLogic);
            // 
            // programLogicBindingSource1
            // 
            this.programLogicBindingSource1.DataSource = typeof(P2_TrianglesFilling.Logic.ProgramLogic);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Triangles Filling";
            this.mainTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.controlsTableLayoutPanel.ResumeLayout(false);
            this.controlsTableLayoutPanel.PerformLayout();
            this.lightModelGroupBox.ResumeLayout(false);
            this.lightModelGroupBox.PerformLayout();
            this.lightModelTableLayoutPanel.ResumeLayout(false);
            this.lightModelTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k_s_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.k_d_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackBar)).EndInit();
            this.objectColorGroupBox.ResumeLayout(false);
            this.objectColorGroupBox.PerformLayout();
            this.objectColorTableLayoutPanel.ResumeLayout(false);
            this.objectColorTableLayoutPanel.PerformLayout();
            this.paintMethodGroupBox.ResumeLayout(false);
            this.paintMethodGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programLogicBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programLogicBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mainTableLayoutPanel;
        private PictureBox pictureBox;
        private TableLayoutPanel controlsTableLayoutPanel;
        private GroupBox lightModelGroupBox;
        private TableLayoutPanel lightModelTableLayoutPanel;
        private Label label1;
        private Label label2;
        private Label label3;
        private TrackBar k_s_trackBar;
        private TrackBar k_d_trackBar;
        private TrackBar m_trackBar;
        private TextBox k_s_textBox;
        private TextBox k_d_textBox;
        private TextBox m_textBox;
        private GroupBox objectColorGroupBox;
        private TableLayoutPanel objectColorTableLayoutPanel;
        private RadioButton oneColorObjectRadioButton;
        private RadioButton imageColorObjectRadioButton;
        private Panel objectColorPanel;
        private Button loadObjectImageButton;
        private ColorDialog objectColorDialog;
        private OpenFileDialog openObjectImageFileDialog;
        private BindingSource programLogicBindingSource;
        private BindingSource programLogicBindingSource1;
        private GroupBox paintMethodGroupBox;
        private TableLayoutPanel tableLayoutPanel1;
        private RadioButton colorInterpolationRadioButton;
        private RadioButton normalsInterpolationRadioButton;
    }
}