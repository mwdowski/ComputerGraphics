namespace P3_Coloring
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getHSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.targetBlueYtextBox = new System.Windows.Forms.TextBox();
            this.targetBlueXtextBox = new System.Windows.Forms.TextBox();
            this.targetGreenYtextBox = new System.Windows.Forms.TextBox();
            this.targetGreenXtextBox = new System.Windows.Forms.TextBox();
            this.targetWhiteXtextBox = new System.Windows.Forms.TextBox();
            this.targetWhiteYtextBox = new System.Windows.Forms.TextBox();
            this.targetRedYtextBox = new System.Windows.Forms.TextBox();
            this.targetRedXtextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.targetComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.targetGammaTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.sourceProfileTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sourceBlueYtextBox = new System.Windows.Forms.TextBox();
            this.sourceBlueXtextBox = new System.Windows.Forms.TextBox();
            this.sourceGreenYtextBox = new System.Windows.Forms.TextBox();
            this.sourceGreenXtextBox = new System.Windows.Forms.TextBox();
            this.sourceWhiteXtextBox = new System.Windows.Forms.TextBox();
            this.sourceWhiteYtextBox = new System.Windows.Forms.TextBox();
            this.sourceRedYtextBox = new System.Windows.Forms.TextBox();
            this.sourceRedXtextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.sourceGammaLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceGammaTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.targetPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.sourceProfileTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.getHSVToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1350, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.loadToolStripMenuItem.Text = "Load image";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // getHSVToolStripMenuItem
            // 
            this.getHSVToolStripMenuItem.Name = "getHSVToolStripMenuItem";
            this.getHSVToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.getHSVToolStripMenuItem.Text = "Get HSV";
            this.getHSVToolStripMenuItem.Click += new System.EventHandler(this.getHSVToolStripMenuItem_Click);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.sourceProfileTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.sourcePictureBox, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.targetPictureBox, 1, 1);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1350, 705);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.targetBlueYtextBox, 7, 4);
            this.tableLayoutPanel1.Controls.Add(this.targetBlueXtextBox, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.targetGreenYtextBox, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.targetGreenXtextBox, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.targetWhiteXtextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.targetWhiteYtextBox, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.targetRedYtextBox, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.targetRedXtextBox, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.label12, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.label13, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.targetComboBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label17, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.targetGammaTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label18, 6, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(675, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(672, 137);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(139, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 27);
            this.label9.TabIndex = 21;
            this.label9.Text = "y";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(58, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 27);
            this.label10.TabIndex = 20;
            this.label10.Text = "x";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(507, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 29);
            this.label11.TabIndex = 19;
            this.label11.Text = "y";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // targetBlueYtextBox
            // 
            this.targetBlueYtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetBlueYtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetBlueYtextBox.Location = new System.Drawing.Point(507, 107);
            this.targetBlueYtextBox.Name = "targetBlueYtextBox";
            this.targetBlueYtextBox.Size = new System.Drawing.Size(75, 21);
            this.targetBlueYtextBox.TabIndex = 17;
            this.targetBlueYtextBox.TextChanged += new System.EventHandler(this.targetBlueYtextBox_TextChanged);
            // 
            // targetBlueXtextBox
            // 
            this.targetBlueXtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetBlueXtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetBlueXtextBox.Location = new System.Drawing.Point(426, 107);
            this.targetBlueXtextBox.Name = "targetBlueXtextBox";
            this.targetBlueXtextBox.Size = new System.Drawing.Size(75, 21);
            this.targetBlueXtextBox.TabIndex = 16;
            this.targetBlueXtextBox.TextChanged += new System.EventHandler(this.targetBlueXtextBox_TextChanged);
            // 
            // targetGreenYtextBox
            // 
            this.targetGreenYtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetGreenYtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetGreenYtextBox.Location = new System.Drawing.Point(507, 80);
            this.targetGreenYtextBox.Name = "targetGreenYtextBox";
            this.targetGreenYtextBox.Size = new System.Drawing.Size(75, 21);
            this.targetGreenYtextBox.TabIndex = 15;
            this.targetGreenYtextBox.TextChanged += new System.EventHandler(this.targetGreenYtextBox_TextChanged);
            // 
            // targetGreenXtextBox
            // 
            this.targetGreenXtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetGreenXtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetGreenXtextBox.Location = new System.Drawing.Point(426, 80);
            this.targetGreenXtextBox.Name = "targetGreenXtextBox";
            this.targetGreenXtextBox.Size = new System.Drawing.Size(75, 21);
            this.targetGreenXtextBox.TabIndex = 14;
            this.targetGreenXtextBox.TextChanged += new System.EventHandler(this.targetGreenXtextBox_TextChanged);
            // 
            // targetWhiteXtextBox
            // 
            this.targetWhiteXtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetWhiteXtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetWhiteXtextBox.Location = new System.Drawing.Point(58, 107);
            this.targetWhiteXtextBox.Name = "targetWhiteXtextBox";
            this.targetWhiteXtextBox.Size = new System.Drawing.Size(75, 21);
            this.targetWhiteXtextBox.TabIndex = 13;
            this.targetWhiteXtextBox.TextChanged += new System.EventHandler(this.targetWhiteXtextBox_TextChanged);
            // 
            // targetWhiteYtextBox
            // 
            this.targetWhiteYtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetWhiteYtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetWhiteYtextBox.Location = new System.Drawing.Point(139, 107);
            this.targetWhiteYtextBox.Name = "targetWhiteYtextBox";
            this.targetWhiteYtextBox.Size = new System.Drawing.Size(75, 21);
            this.targetWhiteYtextBox.TabIndex = 12;
            this.targetWhiteYtextBox.TextChanged += new System.EventHandler(this.targetWhiteYtextBox_TextChanged);
            // 
            // targetRedYtextBox
            // 
            this.targetRedYtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetRedYtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetRedYtextBox.Location = new System.Drawing.Point(507, 53);
            this.targetRedYtextBox.Name = "targetRedYtextBox";
            this.targetRedYtextBox.Size = new System.Drawing.Size(75, 21);
            this.targetRedYtextBox.TabIndex = 10;
            this.targetRedYtextBox.TextChanged += new System.EventHandler(this.targetRedYtextBox_TextChanged);
            // 
            // targetRedXtextBox
            // 
            this.targetRedXtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetRedXtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetRedXtextBox.Location = new System.Drawing.Point(426, 53);
            this.targetRedXtextBox.Name = "targetRedXtextBox";
            this.targetRedXtextBox.Size = new System.Drawing.Size(75, 21);
            this.targetRedXtextBox.TabIndex = 9;
            this.targetRedXtextBox.TextChanged += new System.EventHandler(this.targetRedXtextBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(382, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 33);
            this.label12.TabIndex = 6;
            this.label12.Text = "Blue";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(382, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 27);
            this.label13.TabIndex = 5;
            this.label13.Text = "Green";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label14, 9);
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(666, 21);
            this.label14.TabIndex = 0;
            this.label14.Text = "Target color profile";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // targetComboBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.targetComboBox, 5);
            this.targetComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetComboBox.FormattingEnabled = true;
            this.targetComboBox.Location = new System.Drawing.Point(3, 24);
            this.targetComboBox.Name = "targetComboBox";
            this.targetComboBox.Size = new System.Drawing.Size(373, 23);
            this.targetComboBox.TabIndex = 1;
            this.targetComboBox.SelectedIndexChanged += new System.EventHandler(this.targetComboBox_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(3, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 27);
            this.label15.TabIndex = 2;
            this.label15.Text = "Gamma";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 33);
            this.label16.TabIndex = 3;
            this.label16.Text = "White";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(382, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 27);
            this.label17.TabIndex = 4;
            this.label17.Text = "Red";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // targetGammaTextBox
            // 
            this.targetGammaTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetGammaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.targetGammaTextBox.Location = new System.Drawing.Point(58, 53);
            this.targetGammaTextBox.Name = "targetGammaTextBox";
            this.targetGammaTextBox.Size = new System.Drawing.Size(75, 21);
            this.targetGammaTextBox.TabIndex = 7;
            this.targetGammaTextBox.TextChanged += new System.EventHandler(this.targetGammaTextBox_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(426, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 29);
            this.label18.TabIndex = 18;
            this.label18.Text = "x";
            this.label18.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // sourceProfileTableLayoutPanel
            // 
            this.sourceProfileTableLayoutPanel.AutoSize = true;
            this.sourceProfileTableLayoutPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.sourceProfileTableLayoutPanel.ColumnCount = 9;
            this.sourceProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.sourceProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.sourceProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.sourceProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.sourceProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.sourceProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.sourceProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.sourceProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.sourceProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.sourceProfileTableLayoutPanel.Controls.Add(this.label8, 2, 3);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.label7, 1, 3);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.label6, 7, 1);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceBlueYtextBox, 7, 4);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceBlueXtextBox, 6, 4);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceGreenYtextBox, 7, 3);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceGreenXtextBox, 6, 3);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceWhiteXtextBox, 1, 4);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceWhiteYtextBox, 2, 4);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceRedYtextBox, 7, 2);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceRedXtextBox, 6, 2);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.label4, 5, 4);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.label3, 5, 3);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceLabel, 0, 0);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceComboBox, 0, 1);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceGammaLabel, 0, 2);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.label1, 0, 4);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.label2, 5, 2);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.sourceGammaTextBox, 1, 2);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.label5, 6, 1);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.label19, 5, 0);
            this.sourceProfileTableLayoutPanel.Controls.Add(this.trackBar1, 6, 0);
            this.sourceProfileTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceProfileTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.sourceProfileTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.sourceProfileTableLayoutPanel.Name = "sourceProfileTableLayoutPanel";
            this.sourceProfileTableLayoutPanel.RowCount = 5;
            this.sourceProfileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sourceProfileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sourceProfileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sourceProfileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sourceProfileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sourceProfileTableLayoutPanel.Size = new System.Drawing.Size(672, 137);
            this.sourceProfileTableLayoutPanel.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(139, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 27);
            this.label8.TabIndex = 21;
            this.label8.Text = "y";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(58, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 27);
            this.label7.TabIndex = 20;
            this.label7.Text = "x";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(507, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 29);
            this.label6.TabIndex = 19;
            this.label6.Text = "y";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // sourceBlueYtextBox
            // 
            this.sourceBlueYtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceBlueYtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceBlueYtextBox.Location = new System.Drawing.Point(507, 113);
            this.sourceBlueYtextBox.Name = "sourceBlueYtextBox";
            this.sourceBlueYtextBox.Size = new System.Drawing.Size(75, 21);
            this.sourceBlueYtextBox.TabIndex = 17;
            this.sourceBlueYtextBox.TextChanged += new System.EventHandler(this.sourceBlueYtextBox_TextChanged);
            // 
            // sourceBlueXtextBox
            // 
            this.sourceBlueXtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceBlueXtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceBlueXtextBox.Location = new System.Drawing.Point(426, 113);
            this.sourceBlueXtextBox.Name = "sourceBlueXtextBox";
            this.sourceBlueXtextBox.Size = new System.Drawing.Size(75, 21);
            this.sourceBlueXtextBox.TabIndex = 16;
            this.sourceBlueXtextBox.TextChanged += new System.EventHandler(this.sourceBlueXtextBox_TextChanged);
            // 
            // sourceGreenYtextBox
            // 
            this.sourceGreenYtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceGreenYtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceGreenYtextBox.Location = new System.Drawing.Point(507, 86);
            this.sourceGreenYtextBox.Name = "sourceGreenYtextBox";
            this.sourceGreenYtextBox.Size = new System.Drawing.Size(75, 21);
            this.sourceGreenYtextBox.TabIndex = 15;
            this.sourceGreenYtextBox.TextChanged += new System.EventHandler(this.sourceGreenYtextBox_TextChanged);
            // 
            // sourceGreenXtextBox
            // 
            this.sourceGreenXtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceGreenXtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceGreenXtextBox.Location = new System.Drawing.Point(426, 86);
            this.sourceGreenXtextBox.Name = "sourceGreenXtextBox";
            this.sourceGreenXtextBox.Size = new System.Drawing.Size(75, 21);
            this.sourceGreenXtextBox.TabIndex = 14;
            this.sourceGreenXtextBox.TextChanged += new System.EventHandler(this.sourceGreenXtextBox_TextChanged);
            // 
            // sourceWhiteXtextBox
            // 
            this.sourceWhiteXtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceWhiteXtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceWhiteXtextBox.Location = new System.Drawing.Point(58, 113);
            this.sourceWhiteXtextBox.Name = "sourceWhiteXtextBox";
            this.sourceWhiteXtextBox.Size = new System.Drawing.Size(75, 21);
            this.sourceWhiteXtextBox.TabIndex = 13;
            this.sourceWhiteXtextBox.TextChanged += new System.EventHandler(this.sourceWhiteXtextBox_TextChanged);
            // 
            // sourceWhiteYtextBox
            // 
            this.sourceWhiteYtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceWhiteYtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceWhiteYtextBox.Location = new System.Drawing.Point(139, 113);
            this.sourceWhiteYtextBox.Name = "sourceWhiteYtextBox";
            this.sourceWhiteYtextBox.Size = new System.Drawing.Size(75, 21);
            this.sourceWhiteYtextBox.TabIndex = 12;
            this.sourceWhiteYtextBox.TextChanged += new System.EventHandler(this.sourceWhiteYtextBox_TextChanged);
            // 
            // sourceRedYtextBox
            // 
            this.sourceRedYtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceRedYtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceRedYtextBox.Location = new System.Drawing.Point(507, 59);
            this.sourceRedYtextBox.Name = "sourceRedYtextBox";
            this.sourceRedYtextBox.Size = new System.Drawing.Size(75, 21);
            this.sourceRedYtextBox.TabIndex = 10;
            this.sourceRedYtextBox.TextChanged += new System.EventHandler(this.sourceRedYtextBox_TextChanged);
            // 
            // sourceRedXtextBox
            // 
            this.sourceRedXtextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceRedXtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceRedXtextBox.Location = new System.Drawing.Point(426, 59);
            this.sourceRedXtextBox.Name = "sourceRedXtextBox";
            this.sourceRedXtextBox.Size = new System.Drawing.Size(75, 21);
            this.sourceRedXtextBox.TabIndex = 9;
            this.sourceRedXtextBox.TextChanged += new System.EventHandler(this.sourceRedXtextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(382, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Blue";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(382, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "Green";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceProfileTableLayoutPanel.SetColumnSpan(this.sourceLabel, 5);
            this.sourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceLabel.Location = new System.Drawing.Point(3, 0);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(373, 27);
            this.sourceLabel.TabIndex = 0;
            this.sourceLabel.Text = "Source color profile";
            this.sourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sourceComboBox
            // 
            this.sourceProfileTableLayoutPanel.SetColumnSpan(this.sourceComboBox, 5);
            this.sourceComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceComboBox.FormattingEnabled = true;
            this.sourceComboBox.Location = new System.Drawing.Point(3, 30);
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.Size = new System.Drawing.Size(373, 23);
            this.sourceComboBox.TabIndex = 1;
            this.sourceComboBox.SelectedIndexChanged += new System.EventHandler(this.sourceComboBox_SelectedIndexChanged);
            // 
            // sourceGammaLabel
            // 
            this.sourceGammaLabel.AutoSize = true;
            this.sourceGammaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceGammaLabel.Location = new System.Drawing.Point(3, 56);
            this.sourceGammaLabel.Name = "sourceGammaLabel";
            this.sourceGammaLabel.Size = new System.Drawing.Size(49, 27);
            this.sourceGammaLabel.TabIndex = 2;
            this.sourceGammaLabel.Text = "Gamma";
            this.sourceGammaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "White";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(382, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Red";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sourceGammaTextBox
            // 
            this.sourceGammaTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceGammaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceGammaTextBox.Location = new System.Drawing.Point(58, 59);
            this.sourceGammaTextBox.Name = "sourceGammaTextBox";
            this.sourceGammaTextBox.Size = new System.Drawing.Size(75, 21);
            this.sourceGammaTextBox.TabIndex = 7;
            this.sourceGammaTextBox.TextChanged += new System.EventHandler(this.sourceGammaTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(426, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 29);
            this.label5.TabIndex = 18;
            this.label5.Text = "x";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(382, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 27);
            this.label19.TabIndex = 22;
            this.label19.Text = "V";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.sourceProfileTableLayoutPanel.SetColumnSpan(this.trackBar1, 3);
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Location = new System.Drawing.Point(426, 3);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(243, 21);
            this.trackBar1.TabIndex = 23;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourcePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourcePictureBox.Location = new System.Drawing.Point(3, 146);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(669, 556);
            this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourcePictureBox.TabIndex = 2;
            this.sourcePictureBox.TabStop = false;
            // 
            // targetPictureBox
            // 
            this.targetPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.targetPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetPictureBox.Location = new System.Drawing.Point(678, 146);
            this.targetPictureBox.Name = "targetPictureBox";
            this.targetPictureBox.Size = new System.Drawing.Size(669, 556);
            this.targetPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.targetPictureBox.TabIndex = 3;
            this.targetPictureBox.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFIleDialog";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.Text = "Color profile converter";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.sourceProfileTableLayoutPanel.ResumeLayout(false);
            this.sourceProfileTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem generateToolStripMenuItem;
        private TableLayoutPanel mainTableLayoutPanel;
        private TableLayoutPanel sourceProfileTableLayoutPanel;
        private Label sourceLabel;
        private ComboBox sourceComboBox;
        private Label sourceGammaLabel;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private TextBox sourceGammaTextBox;
        private TextBox sourceBlueYtextBox;
        private TextBox sourceBlueXtextBox;
        private TextBox sourceGreenYtextBox;
        private TextBox sourceGreenXtextBox;
        private TextBox sourceWhiteXtextBox;
        private TextBox sourceWhiteYtextBox;
        private TextBox sourceRedYtextBox;
        private TextBox sourceRedXtextBox;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox targetBlueYtextBox;
        private TextBox targetBlueXtextBox;
        private TextBox targetGreenYtextBox;
        private TextBox targetGreenXtextBox;
        private TextBox targetWhiteXtextBox;
        private TextBox targetWhiteYtextBox;
        private TextBox targetRedYtextBox;
        private TextBox targetRedXtextBox;
        private Label label12;
        private Label label13;
        private Label label14;
        private ComboBox targetComboBox;
        private Label label15;
        private Label label16;
        private Label label17;
        private TextBox targetGammaTextBox;
        private Label label18;
        private PictureBox sourcePictureBox;
        private PictureBox targetPictureBox;
        private OpenFileDialog openFileDialog;
        private ToolStripMenuItem getHSVToolStripMenuItem;
        private Label label19;
        private TrackBar trackBar1;
    }
}