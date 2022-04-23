namespace OfflineMapDownloader
{
    partial class OfflineTileReaderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfflineTileReaderForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mapUrlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maxLimitTextBox = new System.Windows.Forms.TextBox();
            this.extensionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mapProfileComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.readProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.startReadButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.leftBottomLonTextBox = new System.Windows.Forms.TextBox();
            this.leftBottomLatTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rowParamPanel = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.topRightLatTextBox = new System.Windows.Forms.TextBox();
            this.topRightLonTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.zoomToTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.zoomFromTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cancelAddRowParamButton = new System.Windows.Forms.Button();
            this.addToGridButton = new System.Windows.Forms.Button();
            this.copyOSMMapButton = new System.Windows.Forms.Button();
            this.addRowParamButton = new System.Windows.Forms.Button();
            this.calculateTotalTileButton = new System.Windows.Forms.Button();
            this.loadConfigButton = new System.Windows.Forms.Button();
            this.saveConfigButton = new System.Windows.Forms.Button();
            this.pyramidDataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLeftBottomLat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLeftBottomLon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTopRightLat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTopRightLon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnZoomFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnZoomTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalTile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.delayTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.errorLogDataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnErrorRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnErrorTileAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnErrorDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTileUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mongoDBTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.rowParamPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pyramidDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorLogDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mapUrlTextBox
            // 
            this.mapUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapUrlTextBox.Location = new System.Drawing.Point(78, 574);
            this.mapUrlTextBox.Name = "mapUrlTextBox";
            this.mapUrlTextBox.Size = new System.Drawing.Size(1097, 23);
            this.mapUrlTextBox.TabIndex = 1;
            this.mapUrlTextBox.Text = resources.GetString("mapUrlTextBox.Text");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 578);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Map Url:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(825, 523);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total Threads:";
            // 
            // maxLimitTextBox
            // 
            this.maxLimitTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.maxLimitTextBox.Location = new System.Drawing.Point(910, 519);
            this.maxLimitTextBox.Name = "maxLimitTextBox";
            this.maxLimitTextBox.Size = new System.Drawing.Size(65, 23);
            this.maxLimitTextBox.TabIndex = 2;
            this.maxLimitTextBox.Text = "12";
            // 
            // extensionTextBox
            // 
            this.extensionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.extensionTextBox.Location = new System.Drawing.Point(764, 519);
            this.extensionTextBox.Name = "extensionTextBox";
            this.extensionTextBox.Size = new System.Drawing.Size(55, 23);
            this.extensionTextBox.TabIndex = 2;
            this.extensionTextBox.Text = "pbf";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(697, 523);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Extension:";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.Location = new System.Drawing.Point(78, 545);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(446, 23);
            this.outputTextBox.TabIndex = 2;
            this.outputTextBox.Text = "c:\\maptile1\\";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 549);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Output Path:";
            // 
            // mapProfileComboBox
            // 
            this.mapProfileComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapProfileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapProfileComboBox.FormattingEnabled = true;
            this.mapProfileComboBox.Location = new System.Drawing.Point(78, 519);
            this.mapProfileComboBox.Name = "mapProfileComboBox";
            this.mapProfileComboBox.Size = new System.Drawing.Size(446, 23);
            this.mapProfileComboBox.TabIndex = 5;
            this.mapProfileComboBox.SelectedIndexChanged += new System.EventHandler(this.mapProfileComboBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 523);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Profile:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusLabel,
            this.toolStripStatusLabel2,
            this.readProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 607);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1175, 24);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 19);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(1006, 19);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "-";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 19);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // readProgressBar
            // 
            this.readProgressBar.Name = "readProgressBar";
            this.readProgressBar.Size = new System.Drawing.Size(100, 18);
            // 
            // startReadButton
            // 
            this.startReadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startReadButton.Location = new System.Drawing.Point(343, 309);
            this.startReadButton.Name = "startReadButton";
            this.startReadButton.Size = new System.Drawing.Size(106, 42);
            this.startReadButton.TabIndex = 8;
            this.startReadButton.Text = "Start";
            this.startReadButton.UseVisualStyleBackColor = true;
            this.startReadButton.Click += new System.EventHandler(this.startReadButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(169, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Lon:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "Lat:";
            // 
            // leftBottomLonTextBox
            // 
            this.leftBottomLonTextBox.Location = new System.Drawing.Point(205, 30);
            this.leftBottomLonTextBox.Name = "leftBottomLonTextBox";
            this.leftBottomLonTextBox.Size = new System.Drawing.Size(124, 23);
            this.leftBottomLonTextBox.TabIndex = 10;
            this.leftBottomLonTextBox.Text = "48.44049164708894";
            // 
            // leftBottomLatTextBox
            // 
            this.leftBottomLatTextBox.Location = new System.Drawing.Point(39, 30);
            this.leftBottomLatTextBox.Name = "leftBottomLatTextBox";
            this.leftBottomLatTextBox.Size = new System.Drawing.Size(124, 23);
            this.leftBottomLatTextBox.TabIndex = 11;
            this.leftBottomLatTextBox.Text = "36.65012764798955";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rowParamPanel);
            this.groupBox1.Controls.Add(this.copyOSMMapButton);
            this.groupBox1.Controls.Add(this.addRowParamButton);
            this.groupBox1.Controls.Add(this.calculateTotalTileButton);
            this.groupBox1.Controls.Add(this.loadConfigButton);
            this.groupBox1.Controls.Add(this.saveConfigButton);
            this.groupBox1.Controls.Add(this.pyramidDataGridView);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.startReadButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1161, 467);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Read From Bounding Box";
            // 
            // rowParamPanel
            // 
            this.rowParamPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rowParamPanel.Controls.Add(this.groupBox3);
            this.rowParamPanel.Controls.Add(this.groupBox2);
            this.rowParamPanel.Controls.Add(this.label11);
            this.rowParamPanel.Controls.Add(this.groupBox4);
            this.rowParamPanel.Controls.Add(this.cancelAddRowParamButton);
            this.rowParamPanel.Controls.Add(this.addToGridButton);
            this.rowParamPanel.Location = new System.Drawing.Point(7, 303);
            this.rowParamPanel.Name = "rowParamPanel";
            this.rowParamPanel.Size = new System.Drawing.Size(816, 156);
            this.rowParamPanel.TabIndex = 27;
            this.rowParamPanel.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.topRightLatTextBox);
            this.groupBox3.Controls.Add(this.topRightLonTextBox);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(364, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 64);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Top Right";
            // 
            // topRightLatTextBox
            // 
            this.topRightLatTextBox.Location = new System.Drawing.Point(41, 27);
            this.topRightLatTextBox.Name = "topRightLatTextBox";
            this.topRightLatTextBox.Size = new System.Drawing.Size(124, 23);
            this.topRightLatTextBox.TabIndex = 11;
            this.topRightLatTextBox.Text = "36.689956293240485";
            // 
            // topRightLonTextBox
            // 
            this.topRightLonTextBox.Location = new System.Drawing.Point(207, 27);
            this.topRightLonTextBox.Name = "topRightLonTextBox";
            this.topRightLonTextBox.Size = new System.Drawing.Size(124, 23);
            this.topRightLonTextBox.TabIndex = 10;
            this.topRightLonTextBox.Text = "48.58772807584379";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 15);
            this.label13.TabIndex = 13;
            this.label13.Text = "Lat:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(171, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 15);
            this.label14.TabIndex = 12;
            this.label14.Text = "Lon:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.leftBottomLonTextBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.leftBottomLatTextBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 64);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Left Bottom";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Maroon;
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(816, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "* -85 < Lat < 85          -180  < Lon < 180";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.zoomToTextBox);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.zoomFromTextBox);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(3, 76);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(355, 62);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Zoom";
            // 
            // zoomToTextBox
            // 
            this.zoomToTextBox.Location = new System.Drawing.Point(205, 22);
            this.zoomToTextBox.Name = "zoomToTextBox";
            this.zoomToTextBox.Size = new System.Drawing.Size(124, 23);
            this.zoomToTextBox.TabIndex = 10;
            this.zoomToTextBox.Text = "21";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(0, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 15);
            this.label16.TabIndex = 13;
            this.label16.Text = "From:";
            // 
            // zoomFromTextBox
            // 
            this.zoomFromTextBox.Location = new System.Drawing.Point(39, 22);
            this.zoomFromTextBox.Name = "zoomFromTextBox";
            this.zoomFromTextBox.Size = new System.Drawing.Size(124, 23);
            this.zoomFromTextBox.TabIndex = 11;
            this.zoomFromTextBox.Text = "1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(177, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 15);
            this.label17.TabIndex = 12;
            this.label17.Text = "To:";
            // 
            // cancelAddRowParamButton
            // 
            this.cancelAddRowParamButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelAddRowParamButton.Location = new System.Drawing.Point(466, 93);
            this.cancelAddRowParamButton.Name = "cancelAddRowParamButton";
            this.cancelAddRowParamButton.Size = new System.Drawing.Size(96, 42);
            this.cancelAddRowParamButton.TabIndex = 22;
            this.cancelAddRowParamButton.Text = "Cancle";
            this.cancelAddRowParamButton.UseVisualStyleBackColor = true;
            this.cancelAddRowParamButton.Click += new System.EventHandler(this.cancelAddRowParamButton_Click);
            // 
            // addToGridButton
            // 
            this.addToGridButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addToGridButton.Location = new System.Drawing.Point(364, 93);
            this.addToGridButton.Name = "addToGridButton";
            this.addToGridButton.Size = new System.Drawing.Size(96, 42);
            this.addToGridButton.TabIndex = 22;
            this.addToGridButton.Text = "Add to Grid";
            this.addToGridButton.UseVisualStyleBackColor = true;
            this.addToGridButton.Click += new System.EventHandler(this.addToGridButton_Click);
            // 
            // copyOSMMapButton
            // 
            this.copyOSMMapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.copyOSMMapButton.Location = new System.Drawing.Point(455, 309);
            this.copyOSMMapButton.Name = "copyOSMMapButton";
            this.copyOSMMapButton.Size = new System.Drawing.Size(106, 42);
            this.copyOSMMapButton.TabIndex = 29;
            this.copyOSMMapButton.Text = "Create Map ";
            this.copyOSMMapButton.UseVisualStyleBackColor = true;
            this.copyOSMMapButton.Click += new System.EventHandler(this.copyOSMMapButton_Click);
            // 
            // addRowParamButton
            // 
            this.addRowParamButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addRowParamButton.Location = new System.Drawing.Point(7, 309);
            this.addRowParamButton.Name = "addRowParamButton";
            this.addRowParamButton.Size = new System.Drawing.Size(106, 42);
            this.addRowParamButton.TabIndex = 28;
            this.addRowParamButton.Text = "Add Param";
            this.addRowParamButton.UseVisualStyleBackColor = true;
            this.addRowParamButton.Click += new System.EventHandler(this.addRowParamButton_Click);
            // 
            // calculateTotalTileButton
            // 
            this.calculateTotalTileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.calculateTotalTileButton.Location = new System.Drawing.Point(726, 310);
            this.calculateTotalTileButton.Name = "calculateTotalTileButton";
            this.calculateTotalTileButton.Size = new System.Drawing.Size(97, 41);
            this.calculateTotalTileButton.TabIndex = 26;
            this.calculateTotalTileButton.Text = "Calculate Total";
            this.calculateTotalTileButton.UseVisualStyleBackColor = true;
            this.calculateTotalTileButton.Click += new System.EventHandler(this.calculateTotalTileButton_Click);
            // 
            // loadConfigButton
            // 
            this.loadConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadConfigButton.Location = new System.Drawing.Point(119, 309);
            this.loadConfigButton.Name = "loadConfigButton";
            this.loadConfigButton.Size = new System.Drawing.Size(106, 42);
            this.loadConfigButton.TabIndex = 24;
            this.loadConfigButton.Text = "Load Config";
            this.loadConfigButton.UseVisualStyleBackColor = true;
            this.loadConfigButton.Click += new System.EventHandler(this.loadConfigButton_Click);
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveConfigButton.Location = new System.Drawing.Point(231, 309);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(106, 42);
            this.saveConfigButton.TabIndex = 23;
            this.saveConfigButton.Text = "Save All Config";
            this.saveConfigButton.UseVisualStyleBackColor = true;
            this.saveConfigButton.Click += new System.EventHandler(this.saveConfigButton_Click);
            // 
            // pyramidDataGridView
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pyramidDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.pyramidDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pyramidDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.pyramidDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pyramidDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnRow,
            this.ColumnLeftBottomLat,
            this.ColumnLeftBottomLon,
            this.ColumnTopRightLat,
            this.ColumnTopRightLon,
            this.ColumnZoomFrom,
            this.ColumnZoomTo,
            this.ColumnTotalTile});
            this.pyramidDataGridView.Location = new System.Drawing.Point(6, 19);
            this.pyramidDataGridView.Name = "pyramidDataGridView";
            this.pyramidDataGridView.RowHeadersVisible = false;
            this.pyramidDataGridView.RowTemplate.Height = 25;
            this.pyramidDataGridView.Size = new System.Drawing.Size(817, 278);
            this.pyramidDataGridView.TabIndex = 18;
            // 
            // ColumnRow
            // 
            this.ColumnRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnRow.HeaderText = "Row";
            this.ColumnRow.Name = "ColumnRow";
            this.ColumnRow.Width = 50;
            // 
            // ColumnLeftBottomLat
            // 
            this.ColumnLeftBottomLat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnLeftBottomLat.HeaderText = "Left Bottom Lat";
            this.ColumnLeftBottomLat.Name = "ColumnLeftBottomLat";
            this.ColumnLeftBottomLat.Width = 120;
            // 
            // ColumnLeftBottomLon
            // 
            this.ColumnLeftBottomLon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnLeftBottomLon.HeaderText = "Left Bottom Lon";
            this.ColumnLeftBottomLon.Name = "ColumnLeftBottomLon";
            this.ColumnLeftBottomLon.Width = 120;
            // 
            // ColumnTopRightLat
            // 
            this.ColumnTopRightLat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnTopRightLat.HeaderText = "Top Right Lat";
            this.ColumnTopRightLat.Name = "ColumnTopRightLat";
            this.ColumnTopRightLat.Width = 110;
            // 
            // ColumnTopRightLon
            // 
            this.ColumnTopRightLon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnTopRightLon.HeaderText = "Top Right Lon";
            this.ColumnTopRightLon.Name = "ColumnTopRightLon";
            this.ColumnTopRightLon.Width = 110;
            // 
            // ColumnZoomFrom
            // 
            this.ColumnZoomFrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnZoomFrom.HeaderText = "Zoom From";
            this.ColumnZoomFrom.Name = "ColumnZoomFrom";
            // 
            // ColumnZoomTo
            // 
            this.ColumnZoomTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnZoomTo.HeaderText = "Zoom To";
            this.ColumnZoomTo.Name = "ColumnZoomTo";
            this.ColumnZoomTo.Width = 90;
            // 
            // ColumnTotalTile
            // 
            this.ColumnTotalTile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnTotalTile.HeaderText = "Total Tile";
            this.ColumnTotalTile.Name = "ColumnTotalTile";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::OfflineMapDownloader.Properties.Resources.grid;
            this.pictureBox1.Location = new System.Drawing.Point(829, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(338, 305);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(593, 523);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 15);
            this.label15.TabIndex = 17;
            this.label15.Text = "Delay:";
            // 
            // delayTextBox
            // 
            this.delayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delayTextBox.Location = new System.Drawing.Point(633, 519);
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.Size = new System.Drawing.Size(55, 23);
            this.delayTextBox.TabIndex = 16;
            this.delayTextBox.Text = "100";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1175, 501);
            this.tabControl1.TabIndex = 16;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1167, 473);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tile Map Downloader";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.errorLogDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1167, 473);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Error Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // errorLogDataGridView
            // 
            this.errorLogDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.errorLogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorLogDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnErrorRow,
            this.ColumnErrorTileAddress,
            this.ColumnErrorDescription,
            this.ColumnTileUrl});
            this.errorLogDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorLogDataGridView.Location = new System.Drawing.Point(3, 3);
            this.errorLogDataGridView.Name = "errorLogDataGridView";
            this.errorLogDataGridView.RowTemplate.Height = 25;
            this.errorLogDataGridView.Size = new System.Drawing.Size(1161, 467);
            this.errorLogDataGridView.TabIndex = 0;
            // 
            // ColumnErrorRow
            // 
            this.ColumnErrorRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnErrorRow.HeaderText = "Row";
            this.ColumnErrorRow.Name = "ColumnErrorRow";
            this.ColumnErrorRow.Width = 70;
            // 
            // ColumnErrorTileAddress
            // 
            this.ColumnErrorTileAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnErrorTileAddress.HeaderText = "Tile ";
            this.ColumnErrorTileAddress.Name = "ColumnErrorTileAddress";
            // 
            // ColumnErrorDescription
            // 
            this.ColumnErrorDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnErrorDescription.HeaderText = "Description";
            this.ColumnErrorDescription.Name = "ColumnErrorDescription";
            // 
            // ColumnTileUrl
            // 
            this.ColumnTileUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTileUrl.HeaderText = "Tile Url";
            this.ColumnTileUrl.Name = "ColumnTileUrl";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "mfc";
            this.saveFileDialog1.FileName = "Map File Config";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "mfc";
            this.openFileDialog1.FileName = "Map File Config";
            // 
            // mongoDBTextBox
            // 
            this.mongoDBTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mongoDBTextBox.Location = new System.Drawing.Point(633, 545);
            this.mongoDBTextBox.Name = "mongoDBTextBox";
            this.mongoDBTextBox.Size = new System.Drawing.Size(542, 23);
            this.mongoDBTextBox.TabIndex = 2;
            this.mongoDBTextBox.Text = "mongodb://localhost:27017;maptile";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(528, 549);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "MongoDB Setting:";
            // 
            // OfflineTileReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 631);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mapProfileComboBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.delayTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mongoDBTextBox);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.maxLimitTextBox);
            this.Controls.Add(this.extensionTextBox);
            this.Controls.Add(this.mapUrlTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "OfflineTileReaderForm";
            this.Text = "Map Offline Downloader";
            this.Load += new System.EventHandler(this.OfflineTileReaderForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.rowParamPanel.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pyramidDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorLogDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox mapUrlTextBox;
        private System.Windows.Forms.TextBox addressFormatTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox maxLimitTextBox;
        private System.Windows.Forms.TextBox extensionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox mapProfileComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar readProgressBar;
        private System.Windows.Forms.Button startReadButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox leftBottomLonTextBox;
        private System.Windows.Forms.TextBox leftBottomLatTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox topRightLatTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox topRightLonTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox delayTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox zoomFromTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox zoomToTextBox;
        private System.Windows.Forms.Button addToGridButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView pyramidDataGridView;
        private System.Windows.Forms.Button loadConfigButton;
        private System.Windows.Forms.Button saveConfigButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLeftBottomLat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLeftBottomLon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTopRightLat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTopRightLon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnZoomFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnZoomTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalTile;
        private System.Windows.Forms.Button calculateTotalTileButton;
        private System.Windows.Forms.Panel rowParamPanel;
        private System.Windows.Forms.Button addRowParamButton;
        private System.Windows.Forms.Button cancelAddRowParamButton;
        private System.Windows.Forms.Button copyOSMMapButton;
        private System.Windows.Forms.DataGridView errorLogDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnErrorRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnErrorTileAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnErrorDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTileUrl;
        private System.Windows.Forms.TextBox mongoDBTextBox;
        private System.Windows.Forms.Label label6;
    }
}
