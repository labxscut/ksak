
namespace SeqDistKPlus
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.cdMain = new System.Windows.Forms.ColorDialog();
            this.sfdMain = new System.Windows.Forms.SaveFileDialog();
            this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImageFont = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChinese = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.inputsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOutgroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.tlpInput = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lvInput = new System.Windows.Forms.ListView();
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSequenceLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scRight = new System.Windows.Forms.SplitContainer();
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.tlpConfig = new System.Windows.Forms.TableLayoutPanel();
            this.gbM = new System.Windows.Forms.GroupBox();
            this.tlpM = new System.Windows.Forms.TableLayoutPanel();
            this.mmbM = new MinMaxBar.MinMaxBar();
            this.nudMMin = new System.Windows.Forms.NumericUpDown();
            this.nudMMax = new System.Windows.Forms.NumericUpDown();
            this.clbAlgebra = new System.Windows.Forms.CheckedListBox();
            this.gbK = new System.Windows.Forms.GroupBox();
            this.tlpK = new System.Windows.Forms.TableLayoutPanel();
            this.mmbK = new MinMaxBar.MinMaxBar();
            this.nudKMin = new System.Windows.Forms.NumericUpDown();
            this.nudKMax = new System.Windows.Forms.NumericUpDown();
            this.gbDrawMethod = new System.Windows.Forms.GroupBox();
            this.cbUseSuper = new System.Windows.Forms.CheckBox();
            this.cbDrawMethod = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gbTree = new System.Windows.Forms.GroupBox();
            this.tcRangeM = new System.Windows.Forms.TabControl();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.tcRangeK = new System.Windows.Forms.TabControl();
            this.tcAlgebra = new System.Windows.Forms.TabControl();
            this.tcImageType = new System.Windows.Forms.TabControl();
            this.tpImageTypeStandard = new System.Windows.Forms.TabPage();
            this.tpImageTypeCircular = new System.Windows.Forms.TabPage();
            this.tpImageTypeAlignText = new System.Windows.Forms.TabPage();
            this.tpImageTypeTriangular = new System.Windows.Forms.TabPage();
            this.tpImageTypeBezier = new System.Windows.Forms.TabPage();
            this.tpImageTypeCircularTriangular = new System.Windows.Forms.TabPage();
            this.tpImageTypeCircularBezier = new System.Windows.Forms.TabPage();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tsslOutput = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspMain = new System.Windows.Forms.ToolStripProgressBar();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.fdMain = new System.Windows.Forms.FontDialog();
            this.ttAlgebra = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbInput.SuspendLayout();
            this.tlpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scRight)).BeginInit();
            this.scRight.Panel1.SuspendLayout();
            this.scRight.Panel2.SuspendLayout();
            this.scRight.SuspendLayout();
            this.gbConfig.SuspendLayout();
            this.tlpConfig.SuspendLayout();
            this.gbM.SuspendLayout();
            this.tlpM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMMax)).BeginInit();
            this.gbK.SuspendLayout();
            this.tlpK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKMax)).BeginInit();
            this.gbDrawMethod.SuspendLayout();
            this.gbTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.tcImageType.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdMain
            // 
            this.ofdMain.Filter = "Fatsa File (*.fasta)|*.fasta|All Files (*.*)|*.*";
            this.ofdMain.Multiselect = true;
            // 
            // msMain
            // 
            this.msMain.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings,
            this.inputsToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.msMain.Size = new System.Drawing.Size(1712, 36);
            this.msMain.TabIndex = 3;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImageFont,
            this.tsmiLanguage});
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(96, 32);
            this.tsmiSettings.Text = "Settings";
            // 
            // tsmiImageFont
            // 
            this.tsmiImageFont.Name = "tsmiImageFont";
            this.tsmiImageFont.Size = new System.Drawing.Size(208, 34);
            this.tsmiImageFont.Text = "Image Font";
            this.tsmiImageFont.Click += new System.EventHandler(this.tsmiImageFont_Click);
            // 
            // tsmiLanguage
            // 
            this.tsmiLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChinese,
            this.tsmiEnglish});
            this.tsmiLanguage.Name = "tsmiLanguage";
            this.tsmiLanguage.Size = new System.Drawing.Size(208, 34);
            this.tsmiLanguage.Text = "Language";
            // 
            // tsmiChinese
            // 
            this.tsmiChinese.Name = "tsmiChinese";
            this.tsmiChinese.Size = new System.Drawing.Size(182, 34);
            this.tsmiChinese.Text = "简体中文";
            this.tsmiChinese.Click += new System.EventHandler(this.tsmiChinese_Click);
            // 
            // tsmiEnglish
            // 
            this.tsmiEnglish.Name = "tsmiEnglish";
            this.tsmiEnglish.Size = new System.Drawing.Size(182, 34);
            this.tsmiEnglish.Text = "English";
            this.tsmiEnglish.Click += new System.EventHandler(this.tsmiEnglish_Click);
            // 
            // inputsToolStripMenuItem
            // 
            this.inputsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOutgroupToolStripMenuItem});
            this.inputsToolStripMenuItem.Name = "inputsToolStripMenuItem";
            this.inputsToolStripMenuItem.Size = new System.Drawing.Size(80, 32);
            this.inputsToolStripMenuItem.Text = "Inputs";
            // 
            // addOutgroupToolStripMenuItem
            // 
            this.addOutgroupToolStripMenuItem.Name = "addOutgroupToolStripMenuItem";
            this.addOutgroupToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.addOutgroupToolStripMenuItem.Text = "Add Outgroup";
            this.addOutgroupToolStripMenuItem.Click += new System.EventHandler(this.addOutgroupToolStripMenuItem_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(3, 2);
            this.scMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbInput);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scRight);
            this.scMain.Size = new System.Drawing.Size(1706, 963);
            this.scMain.SplitterDistance = 265;
            this.scMain.TabIndex = 0;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.tlpInput);
            this.gbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInput.Location = new System.Drawing.Point(0, 0);
            this.gbInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbInput.Name = "gbInput";
            this.gbInput.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbInput.Size = new System.Drawing.Size(265, 963);
            this.gbInput.TabIndex = 0;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Input";
            // 
            // tlpInput
            // 
            this.tlpInput.ColumnCount = 3;
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpInput.Controls.Add(this.btnAdd, 0, 1);
            this.tlpInput.Controls.Add(this.btnLoad, 1, 1);
            this.tlpInput.Controls.Add(this.btnClear, 0, 1);
            this.tlpInput.Controls.Add(this.lvInput, 0, 0);
            this.tlpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInput.Location = new System.Drawing.Point(3, 23);
            this.tlpInput.Margin = new System.Windows.Forms.Padding(4);
            this.tlpInput.Name = "tlpInput";
            this.tlpInput.RowCount = 2;
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpInput.Size = new System.Drawing.Size(259, 938);
            this.tlpInput.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(89, 906);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoad.Location = new System.Drawing.Point(175, 906);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(81, 30);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(3, 906);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lvInput
            // 
            this.lvInput.AllowDrop = true;
            this.lvInput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chSequenceLength});
            this.tlpInput.SetColumnSpan(this.lvInput, 3);
            this.lvInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInput.HideSelection = false;
            this.lvInput.Location = new System.Drawing.Point(4, 4);
            this.lvInput.Margin = new System.Windows.Forms.Padding(4);
            this.lvInput.Name = "lvInput";
            this.lvInput.Size = new System.Drawing.Size(251, 896);
            this.lvInput.TabIndex = 3;
            this.lvInput.UseCompatibleStateImageBehavior = false;
            this.lvInput.View = System.Windows.Forms.View.Details;
            this.lvInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvInput_DragDrop);
            this.lvInput.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvInput_DragEnter);
            this.lvInput.DoubleClick += new System.EventHandler(this.lvInput_DoubleClick);
            this.lvInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvInput_KeyPress);
            this.lvInput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvInput_MouseClick);
            // 
            // chFileName
            // 
            this.chFileName.Text = "Sequence";
            this.chFileName.Width = 187;
            // 
            // chSequenceLength
            // 
            this.chSequenceLength.Text = "Length";
            // 
            // scRight
            // 
            this.scRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scRight.Location = new System.Drawing.Point(0, 0);
            this.scRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scRight.Name = "scRight";
            // 
            // scRight.Panel1
            // 
            this.scRight.Panel1.Controls.Add(this.gbConfig);
            // 
            // scRight.Panel2
            // 
            this.scRight.Panel2.Controls.Add(this.gbTree);
            this.scRight.Size = new System.Drawing.Size(1437, 963);
            this.scRight.SplitterDistance = 540;
            this.scRight.TabIndex = 0;
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.tlpConfig);
            this.gbConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbConfig.Location = new System.Drawing.Point(0, 0);
            this.gbConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbConfig.Size = new System.Drawing.Size(540, 963);
            this.gbConfig.TabIndex = 0;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "Run Parameters";
            // 
            // tlpConfig
            // 
            this.tlpConfig.AutoSize = true;
            this.tlpConfig.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpConfig.ColumnCount = 1;
            this.tlpConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConfig.Controls.Add(this.gbM, 0, 3);
            this.tlpConfig.Controls.Add(this.clbAlgebra, 0, 0);
            this.tlpConfig.Controls.Add(this.gbK, 0, 2);
            this.tlpConfig.Controls.Add(this.gbDrawMethod, 0, 4);
            this.tlpConfig.Controls.Add(this.btnGenerate, 0, 5);
            this.tlpConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConfig.Location = new System.Drawing.Point(3, 23);
            this.tlpConfig.Margin = new System.Windows.Forms.Padding(4);
            this.tlpConfig.Name = "tlpConfig";
            this.tlpConfig.RowCount = 6;
            this.tlpConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tlpConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpConfig.Size = new System.Drawing.Size(534, 938);
            this.tlpConfig.TabIndex = 1;
            // 
            // gbM
            // 
            this.gbM.Controls.Add(this.tlpM);
            this.gbM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbM.Location = new System.Drawing.Point(4, 350);
            this.gbM.Margin = new System.Windows.Forms.Padding(4);
            this.gbM.MaximumSize = new System.Drawing.Size(0, 110);
            this.gbM.MinimumSize = new System.Drawing.Size(750, 110);
            this.gbM.Name = "gbM";
            this.gbM.Padding = new System.Windows.Forms.Padding(4);
            this.gbM.Size = new System.Drawing.Size(750, 110);
            this.gbM.TabIndex = 4;
            this.gbM.TabStop = false;
            this.gbM.Text = "Markov Background Order (for d2S and d2Star only)";
            // 
            // tlpM
            // 
            this.tlpM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpM.ColumnCount = 3;
            this.tlpM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpM.Controls.Add(this.mmbM, 1, 0);
            this.tlpM.Controls.Add(this.nudMMin, 0, 0);
            this.tlpM.Controls.Add(this.nudMMax, 2, 0);
            this.tlpM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpM.Location = new System.Drawing.Point(4, 25);
            this.tlpM.Margin = new System.Windows.Forms.Padding(4);
            this.tlpM.Name = "tlpM";
            this.tlpM.RowCount = 1;
            this.tlpM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpM.Size = new System.Drawing.Size(742, 81);
            this.tlpM.TabIndex = 0;
            // 
            // mmbM
            // 
            this.mmbM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mmbM.Location = new System.Drawing.Point(126, 4);
            this.mmbM.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.mmbM.Maximum = 3;
            this.mmbM.MaximumSize = new System.Drawing.Size(0, 70);
            this.mmbM.MaxValue = 3;
            this.mmbM.Minimum = 0;
            this.mmbM.MinimumSize = new System.Drawing.Size(0, 70);
            this.mmbM.MinValue = 0;
            this.mmbM.Name = "mmbM";
            this.mmbM.Size = new System.Drawing.Size(490, 70);
            this.mmbM.TabIndex = 0;
            this.mmbM.Scroll += new System.Windows.Forms.ScrollEventHandler(this.mmbM_Scroll);
            // 
            // nudMMin
            // 
            this.nudMMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudMMin.Location = new System.Drawing.Point(4, 28);
            this.nudMMin.Margin = new System.Windows.Forms.Padding(4, 28, 4, 4);
            this.nudMMin.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMMin.Name = "nudMMin";
            this.nudMMin.Size = new System.Drawing.Size(112, 28);
            this.nudMMin.TabIndex = 1;
            this.nudMMin.ValueChanged += new System.EventHandler(this.nudMMin_ValueChanged);
            // 
            // nudMMax
            // 
            this.nudMMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudMMax.Location = new System.Drawing.Point(626, 28);
            this.nudMMax.Margin = new System.Windows.Forms.Padding(4, 28, 4, 4);
            this.nudMMax.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMMax.Name = "nudMMax";
            this.nudMMax.Size = new System.Drawing.Size(112, 28);
            this.nudMMax.TabIndex = 2;
            this.nudMMax.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMMax.ValueChanged += new System.EventHandler(this.nudMMax_ValueChanged);
            // 
            // clbAlgebra
            // 
            this.clbAlgebra.CheckOnClick = true;
            this.clbAlgebra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAlgebra.FormattingEnabled = true;
            this.clbAlgebra.Items.AddRange(new object[] {
            "Eu",
            "Ma",
            "Ch",
            "d2",
            "Hao",
            "d2star",
            "d2S"});
            this.clbAlgebra.Location = new System.Drawing.Point(4, 4);
            this.clbAlgebra.Margin = new System.Windows.Forms.Padding(4);
            this.clbAlgebra.Name = "clbAlgebra";
            this.tlpConfig.SetRowSpan(this.clbAlgebra, 2);
            this.clbAlgebra.Size = new System.Drawing.Size(526, 228);
            this.clbAlgebra.TabIndex = 0;
            this.clbAlgebra.DoubleClick += new System.EventHandler(this.clbAlgebra_DoubleClick);
            this.clbAlgebra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.clbAlgebra_MouseMove);
            // 
            // gbK
            // 
            this.gbK.Controls.Add(this.tlpK);
            this.gbK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbK.Location = new System.Drawing.Point(4, 240);
            this.gbK.Margin = new System.Windows.Forms.Padding(4);
            this.gbK.MaximumSize = new System.Drawing.Size(0, 110);
            this.gbK.MinimumSize = new System.Drawing.Size(750, 110);
            this.gbK.Name = "gbK";
            this.gbK.Padding = new System.Windows.Forms.Padding(4);
            this.gbK.Size = new System.Drawing.Size(750, 110);
            this.gbK.TabIndex = 3;
            this.gbK.TabStop = false;
            this.gbK.Text = "K - mer length";
            // 
            // tlpK
            // 
            this.tlpK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpK.ColumnCount = 3;
            this.tlpK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpK.Controls.Add(this.mmbK, 1, 0);
            this.tlpK.Controls.Add(this.nudKMin, 0, 0);
            this.tlpK.Controls.Add(this.nudKMax, 2, 0);
            this.tlpK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpK.Location = new System.Drawing.Point(4, 25);
            this.tlpK.Margin = new System.Windows.Forms.Padding(4);
            this.tlpK.Name = "tlpK";
            this.tlpK.RowCount = 1;
            this.tlpK.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpK.Size = new System.Drawing.Size(742, 81);
            this.tlpK.TabIndex = 0;
            // 
            // mmbK
            // 
            this.mmbK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mmbK.Location = new System.Drawing.Point(126, 4);
            this.mmbK.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.mmbK.Maximum = 18;
            this.mmbK.MaximumSize = new System.Drawing.Size(0, 70);
            this.mmbK.MaxValue = 8;
            this.mmbK.Minimum = 2;
            this.mmbK.MinimumSize = new System.Drawing.Size(0, 70);
            this.mmbK.MinValue = 8;
            this.mmbK.Name = "mmbK";
            this.mmbK.Size = new System.Drawing.Size(490, 70);
            this.mmbK.TabIndex = 0;
            this.mmbK.Scroll += new System.Windows.Forms.ScrollEventHandler(this.mmbK_Scroll);
            // 
            // nudKMin
            // 
            this.nudKMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudKMin.Location = new System.Drawing.Point(4, 28);
            this.nudKMin.Margin = new System.Windows.Forms.Padding(4, 28, 4, 4);
            this.nudKMin.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudKMin.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudKMin.Name = "nudKMin";
            this.nudKMin.Size = new System.Drawing.Size(112, 28);
            this.nudKMin.TabIndex = 1;
            this.nudKMin.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudKMin.ValueChanged += new System.EventHandler(this.nudKMin_ValueChanged);
            // 
            // nudKMax
            // 
            this.nudKMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudKMax.Location = new System.Drawing.Point(626, 28);
            this.nudKMax.Margin = new System.Windows.Forms.Padding(4, 28, 4, 4);
            this.nudKMax.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudKMax.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudKMax.Name = "nudKMax";
            this.nudKMax.Size = new System.Drawing.Size(112, 28);
            this.nudKMax.TabIndex = 2;
            this.nudKMax.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudKMax.ValueChanged += new System.EventHandler(this.nudKMax_ValueChanged);
            // 
            // gbDrawMethod
            // 
            this.gbDrawMethod.Controls.Add(this.checkBox1);
            this.gbDrawMethod.Controls.Add(this.cbUseSuper);
            this.gbDrawMethod.Controls.Add(this.cbDrawMethod);
            this.gbDrawMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDrawMethod.Location = new System.Drawing.Point(4, 460);
            this.gbDrawMethod.Margin = new System.Windows.Forms.Padding(4);
            this.gbDrawMethod.Name = "gbDrawMethod";
            this.gbDrawMethod.Padding = new System.Windows.Forms.Padding(4);
            this.gbDrawMethod.Size = new System.Drawing.Size(526, 74);
            this.gbDrawMethod.TabIndex = 5;
            this.gbDrawMethod.TabStop = false;
            this.gbDrawMethod.Text = "Tree Construction Method";
            // 
            // cbUseSuper
            // 
            this.cbUseSuper.AutoSize = true;
            this.cbUseSuper.Location = new System.Drawing.Point(201, 44);
            this.cbUseSuper.Margin = new System.Windows.Forms.Padding(4);
            this.cbUseSuper.Name = "cbUseSuper";
            this.cbUseSuper.Size = new System.Drawing.Size(160, 22);
            this.cbUseSuper.TabIndex = 3;
            this.cbUseSuper.Text = "Use Super List";
            this.ttAlgebra.SetToolTip(this.cbUseSuper, "click here to improve memory officiency");
            this.cbUseSuper.UseVisualStyleBackColor = true;
            this.cbUseSuper.CheckedChanged += new System.EventHandler(this.cbUseSuper_CheckedChanged);
            // 
            // cbDrawMethod
            // 
            this.cbDrawMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrawMethod.FormattingEnabled = true;
            this.cbDrawMethod.Items.AddRange(new object[] {
            "UPGMA",
            "NJ"});
            this.cbDrawMethod.Location = new System.Drawing.Point(9, 26);
            this.cbDrawMethod.Margin = new System.Windows.Forms.Padding(4);
            this.cbDrawMethod.Name = "cbDrawMethod";
            this.cbDrawMethod.Size = new System.Drawing.Size(180, 26);
            this.cbDrawMethod.TabIndex = 2;
            this.cbDrawMethod.SelectedIndexChanged += new System.EventHandler(this.cbDrawMethod_SelectedIndexChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerate.Location = new System.Drawing.Point(4, 900);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(526, 34);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Run";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // gbTree
            // 
            this.gbTree.Controls.Add(this.tcRangeM);
            this.gbTree.Controls.Add(this.pbMain);
            this.gbTree.Controls.Add(this.tcRangeK);
            this.gbTree.Controls.Add(this.tcAlgebra);
            this.gbTree.Controls.Add(this.tcImageType);
            this.gbTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTree.Location = new System.Drawing.Point(0, 0);
            this.gbTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbTree.Name = "gbTree";
            this.gbTree.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbTree.Size = new System.Drawing.Size(893, 963);
            this.gbTree.TabIndex = 0;
            this.gbTree.TabStop = false;
            this.gbTree.Text = "Output";
            // 
            // tcRangeM
            // 
            this.tcRangeM.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tcRangeM.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcRangeM.Location = new System.Drawing.Point(35, 51);
            this.tcRangeM.Margin = new System.Windows.Forms.Padding(4);
            this.tcRangeM.Multiline = true;
            this.tcRangeM.Name = "tcRangeM";
            this.tcRangeM.SelectedIndex = 0;
            this.tcRangeM.Size = new System.Drawing.Size(32, 866);
            this.tcRangeM.TabIndex = 0;
            this.tcRangeM.Visible = false;
            this.tcRangeM.SelectedIndexChanged += new System.EventHandler(this.tcRangeM_SelectedIndexChanged);
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.Location = new System.Drawing.Point(35, 51);
            this.pbMain.Margin = new System.Windows.Forms.Padding(4);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(855, 866);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.DoubleClick += new System.EventHandler(this.pbMain_DoubleClick);
            this.pbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseClick);
            this.pbMain.Resize += new System.EventHandler(this.pbMain_Resize);
            // 
            // tcRangeK
            // 
            this.tcRangeK.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tcRangeK.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcRangeK.Location = new System.Drawing.Point(3, 51);
            this.tcRangeK.Margin = new System.Windows.Forms.Padding(4);
            this.tcRangeK.Multiline = true;
            this.tcRangeK.Name = "tcRangeK";
            this.tcRangeK.SelectedIndex = 0;
            this.tcRangeK.Size = new System.Drawing.Size(32, 866);
            this.tcRangeK.TabIndex = 0;
            this.tcRangeK.SelectedIndexChanged += new System.EventHandler(this.tcRangeK_SelectedIndexChanged);
            // 
            // tcAlgebra
            // 
            this.tcAlgebra.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcAlgebra.Location = new System.Drawing.Point(3, 23);
            this.tcAlgebra.Margin = new System.Windows.Forms.Padding(4);
            this.tcAlgebra.Multiline = true;
            this.tcAlgebra.Name = "tcAlgebra";
            this.tcAlgebra.SelectedIndex = 0;
            this.tcAlgebra.Size = new System.Drawing.Size(887, 28);
            this.tcAlgebra.TabIndex = 1;
            this.tcAlgebra.SelectedIndexChanged += new System.EventHandler(this.tcAlgebra_SelectedIndexChanged);
            // 
            // tcImageType
            // 
            this.tcImageType.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcImageType.Controls.Add(this.tpImageTypeStandard);
            this.tcImageType.Controls.Add(this.tpImageTypeCircular);
            this.tcImageType.Controls.Add(this.tpImageTypeAlignText);
            this.tcImageType.Controls.Add(this.tpImageTypeTriangular);
            this.tcImageType.Controls.Add(this.tpImageTypeBezier);
            this.tcImageType.Controls.Add(this.tpImageTypeCircularTriangular);
            this.tcImageType.Controls.Add(this.tpImageTypeCircularBezier);
            this.tcImageType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcImageType.Location = new System.Drawing.Point(3, 917);
            this.tcImageType.Margin = new System.Windows.Forms.Padding(4);
            this.tcImageType.Multiline = true;
            this.tcImageType.Name = "tcImageType";
            this.tcImageType.SelectedIndex = 0;
            this.tcImageType.Size = new System.Drawing.Size(887, 44);
            this.tcImageType.TabIndex = 0;
            this.tcImageType.SelectedIndexChanged += new System.EventHandler(this.tcImageType_SelectedIndexChanged);
            // 
            // tpImageTypeStandard
            // 
            this.tpImageTypeStandard.Location = new System.Drawing.Point(4, 4);
            this.tpImageTypeStandard.Margin = new System.Windows.Forms.Padding(4);
            this.tpImageTypeStandard.Name = "tpImageTypeStandard";
            this.tpImageTypeStandard.Padding = new System.Windows.Forms.Padding(4);
            this.tpImageTypeStandard.Size = new System.Drawing.Size(879, 12);
            this.tpImageTypeStandard.TabIndex = 0;
            this.tpImageTypeStandard.Text = "Standard";
            this.tpImageTypeStandard.UseVisualStyleBackColor = true;
            // 
            // tpImageTypeCircular
            // 
            this.tpImageTypeCircular.Location = new System.Drawing.Point(4, 4);
            this.tpImageTypeCircular.Margin = new System.Windows.Forms.Padding(4);
            this.tpImageTypeCircular.Name = "tpImageTypeCircular";
            this.tpImageTypeCircular.Padding = new System.Windows.Forms.Padding(4);
            this.tpImageTypeCircular.Size = new System.Drawing.Size(879, 12);
            this.tpImageTypeCircular.TabIndex = 1;
            this.tpImageTypeCircular.Text = "Circular";
            this.tpImageTypeCircular.UseVisualStyleBackColor = true;
            // 
            // tpImageTypeAlignText
            // 
            this.tpImageTypeAlignText.Location = new System.Drawing.Point(4, 4);
            this.tpImageTypeAlignText.Margin = new System.Windows.Forms.Padding(4);
            this.tpImageTypeAlignText.Name = "tpImageTypeAlignText";
            this.tpImageTypeAlignText.Size = new System.Drawing.Size(879, 12);
            this.tpImageTypeAlignText.TabIndex = 2;
            this.tpImageTypeAlignText.Text = "Label Aligned";
            this.tpImageTypeAlignText.UseVisualStyleBackColor = true;
            // 
            // tpImageTypeTriangular
            // 
            this.tpImageTypeTriangular.Location = new System.Drawing.Point(4, 4);
            this.tpImageTypeTriangular.Margin = new System.Windows.Forms.Padding(4);
            this.tpImageTypeTriangular.Name = "tpImageTypeTriangular";
            this.tpImageTypeTriangular.Size = new System.Drawing.Size(879, 12);
            this.tpImageTypeTriangular.TabIndex = 3;
            this.tpImageTypeTriangular.Text = "Triangular";
            this.tpImageTypeTriangular.UseVisualStyleBackColor = true;
            // 
            // tpImageTypeBezier
            // 
            this.tpImageTypeBezier.Location = new System.Drawing.Point(4, 4);
            this.tpImageTypeBezier.Margin = new System.Windows.Forms.Padding(4);
            this.tpImageTypeBezier.Name = "tpImageTypeBezier";
            this.tpImageTypeBezier.Size = new System.Drawing.Size(879, 12);
            this.tpImageTypeBezier.TabIndex = 4;
            this.tpImageTypeBezier.Text = "Bezier";
            this.tpImageTypeBezier.UseVisualStyleBackColor = true;
            // 
            // tpImageTypeCircularTriangular
            // 
            this.tpImageTypeCircularTriangular.Location = new System.Drawing.Point(4, 4);
            this.tpImageTypeCircularTriangular.Margin = new System.Windows.Forms.Padding(4);
            this.tpImageTypeCircularTriangular.Name = "tpImageTypeCircularTriangular";
            this.tpImageTypeCircularTriangular.Size = new System.Drawing.Size(879, 12);
            this.tpImageTypeCircularTriangular.TabIndex = 5;
            this.tpImageTypeCircularTriangular.Text = "CircularTriangular";
            this.tpImageTypeCircularTriangular.UseVisualStyleBackColor = true;
            // 
            // tpImageTypeCircularBezier
            // 
            this.tpImageTypeCircularBezier.Location = new System.Drawing.Point(4, 4);
            this.tpImageTypeCircularBezier.Margin = new System.Windows.Forms.Padding(4);
            this.tpImageTypeCircularBezier.Name = "tpImageTypeCircularBezier";
            this.tpImageTypeCircularBezier.Size = new System.Drawing.Size(879, 12);
            this.tpImageTypeCircularBezier.TabIndex = 6;
            this.tpImageTypeCircularBezier.Text = "Circular Bezier";
            this.tpImageTypeCircularBezier.UseVisualStyleBackColor = true;
            // 
            // ssMain
            // 
            this.ssMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslOutput,
            this.tspMain});
            this.ssMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ssMain.Location = new System.Drawing.Point(0, 982);
            this.ssMain.MaximumSize = new System.Drawing.Size(0, 30);
            this.ssMain.MinimumSize = new System.Drawing.Size(0, 30);
            this.ssMain.Name = "ssMain";
            this.ssMain.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.ssMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ssMain.Size = new System.Drawing.Size(1712, 30);
            this.ssMain.TabIndex = 1;
            this.ssMain.Text = "statusStrip1";
            // 
            // tsslOutput
            // 
            this.tsslOutput.AutoSize = false;
            this.tsslOutput.Name = "tsslOutput";
            this.tsslOutput.Size = new System.Drawing.Size(500, 17);
            this.tsslOutput.Text = "Ready";
            this.tsslOutput.Click += new System.EventHandler(this.tsslOutput_Click);
            // 
            // tspMain
            // 
            this.tspMain.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspMain.ForeColor = System.Drawing.Color.Maroon;
            this.tspMain.Name = "tspMain";
            this.tspMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tspMain.Size = new System.Drawing.Size(750, 22);
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.ssMain, 2, 1);
            this.tlpMain.Controls.Add(this.scMain, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 36);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(4);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.63636F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.363636F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.Size = new System.Drawing.Size(1712, 1012);
            this.tlpMain.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(358, 44);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(178, 22);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "计算反向互补序列";
            this.ttAlgebra.SetToolTip(this.checkBox1, "click here to improve memory officiency");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1712, 1048);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.msMain);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "Ksak";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gbInput.ResumeLayout(false);
            this.tlpInput.ResumeLayout(false);
            this.scRight.Panel1.ResumeLayout(false);
            this.scRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scRight)).EndInit();
            this.scRight.ResumeLayout(false);
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.tlpConfig.ResumeLayout(false);
            this.gbM.ResumeLayout(false);
            this.tlpM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMMax)).EndInit();
            this.gbK.ResumeLayout(false);
            this.tlpK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudKMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKMax)).EndInit();
            this.gbDrawMethod.ResumeLayout(false);
            this.gbDrawMethod.PerformLayout();
            this.gbTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.tcImageType.ResumeLayout(false);
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.ColorDialog cdMain;
        private System.Windows.Forms.SaveFileDialog sfdMain;
        private System.Windows.Forms.FolderBrowserDialog fbdMain;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiImageFont;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.TableLayoutPanel tlpInput;
        private System.Windows.Forms.ListView lvInput;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ColumnHeader chSequenceLength;
        private System.Windows.Forms.SplitContainer scRight;
        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.TableLayoutPanel tlpConfig;
        private System.Windows.Forms.GroupBox gbM;
        private System.Windows.Forms.TableLayoutPanel tlpM;
        private MinMaxBar.MinMaxBar mmbM;
        private System.Windows.Forms.NumericUpDown nudMMin;
        private System.Windows.Forms.NumericUpDown nudMMax;
        private System.Windows.Forms.CheckedListBox clbAlgebra;
        private System.Windows.Forms.GroupBox gbK;
        private System.Windows.Forms.TableLayoutPanel tlpK;
        private MinMaxBar.MinMaxBar mmbK;
        private System.Windows.Forms.NumericUpDown nudKMin;
        private System.Windows.Forms.NumericUpDown nudKMax;
        private System.Windows.Forms.GroupBox gbDrawMethod;
        private System.Windows.Forms.ComboBox cbDrawMethod;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox gbTree;
        private System.Windows.Forms.TabControl tcRangeM;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.TabControl tcRangeK;
        private System.Windows.Forms.TabControl tcAlgebra;
        private System.Windows.Forms.TabControl tcImageType;
        private System.Windows.Forms.TabPage tpImageTypeStandard;
        private System.Windows.Forms.TabPage tpImageTypeCircular;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tsslOutput;
        private System.Windows.Forms.ToolStripProgressBar tspMain;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.FontDialog fdMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiLanguage;
        private System.Windows.Forms.ToolStripMenuItem tsmiChinese;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnglish;
        private System.Windows.Forms.ToolTip ttAlgebra;
        private System.Windows.Forms.TabPage tpImageTypeAlignText;
        private System.Windows.Forms.TabPage tpImageTypeTriangular;
        private System.Windows.Forms.TabPage tpImageTypeBezier;
        private System.Windows.Forms.TabPage tpImageTypeCircularTriangular;
        private System.Windows.Forms.TabPage tpImageTypeCircularBezier;
        private System.Windows.Forms.CheckBox cbUseSuper;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripMenuItem inputsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addOutgroupToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

