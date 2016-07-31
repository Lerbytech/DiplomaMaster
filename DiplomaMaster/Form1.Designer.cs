namespace DiplomaMaster
{
  partial class Form1
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
      this.TB_DataPath = new System.Windows.Forms.TextBox();
      this.BTN_StartProcessing = new System.Windows.Forms.Button();
      this.TB_SavePath = new System.Windows.Forms.TextBox();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.label3 = new System.Windows.Forms.Label();
      this.RB_ExistingExperiment = new System.Windows.Forms.RadioButton();
      this.RB_NewExperiment = new System.Windows.Forms.RadioButton();
      this.BTN_ExportParametrs = new System.Windows.Forms.Button();
      this.BTN_ImportParametrs = new System.Windows.Forms.Button();
      this.BTN_ChooseExportFolder = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.BTN_ChooseInputFolder = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.CB_OverwriteFiles = new System.Windows.Forms.CheckBox();
      this.BigImageBox = new Emgu.CV.UI.ImageBox();
      this.SmallImageBox = new Emgu.CV.UI.ImageBox();
      this.CB_DenoiseMode = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.CB_MaskingMode = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.BTN_LoadMask = new System.Windows.Forms.Button();
      this.BTN_ExportMask = new System.Windows.Forms.Button();
      this.BTN_SeeAllMasks = new System.Windows.Forms.Button();
      this.CB_UseCleanFiles = new System.Windows.Forms.CheckBox();
      this.BTN_EditMask = new System.Windows.Forms.Button();
      this.CB_RewriteMasks = new System.Windows.Forms.CheckBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.ProgressBar = new System.Windows.Forms.ProgressBar();
      this.LB_FileProperties = new System.Windows.Forms.ListBox();
      this.label10 = new System.Windows.Forms.Label();
      this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.label11 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.BigImageBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SmallImageBox)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // TB_DataPath
      // 
      this.TB_DataPath.Location = new System.Drawing.Point(79, 4);
      this.TB_DataPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.TB_DataPath.Name = "TB_DataPath";
      this.TB_DataPath.Size = new System.Drawing.Size(1168, 22);
      this.TB_DataPath.TabIndex = 0;
      // 
      // BTN_StartProcessing
      // 
      this.BTN_StartProcessing.Location = new System.Drawing.Point(627, 514);
      this.BTN_StartProcessing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.BTN_StartProcessing.Name = "BTN_StartProcessing";
      this.BTN_StartProcessing.Size = new System.Drawing.Size(91, 36);
      this.BTN_StartProcessing.TabIndex = 1;
      this.BTN_StartProcessing.Text = "Process";
      this.BTN_StartProcessing.UseVisualStyleBackColor = true;
      this.BTN_StartProcessing.Click += new System.EventHandler(this.BTN_StartProcessing_Click);
      // 
      // TB_SavePath
      // 
      this.TB_SavePath.Location = new System.Drawing.Point(79, 41);
      this.TB_SavePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.TB_SavePath.Name = "TB_SavePath";
      this.TB_SavePath.Size = new System.Drawing.Size(1168, 22);
      this.TB_SavePath.TabIndex = 7;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Location = new System.Drawing.Point(16, 12);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.label3);
      this.splitContainer1.Panel1.Controls.Add(this.RB_ExistingExperiment);
      this.splitContainer1.Panel1.Controls.Add(this.RB_NewExperiment);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.BTN_ExportParametrs);
      this.splitContainer1.Panel2.Controls.Add(this.BTN_ImportParametrs);
      this.splitContainer1.Panel2.Controls.Add(this.BTN_ChooseExportFolder);
      this.splitContainer1.Panel2.Controls.Add(this.label2);
      this.splitContainer1.Panel2.Controls.Add(this.BTN_ChooseInputFolder);
      this.splitContainer1.Panel2.Controls.Add(this.TB_DataPath);
      this.splitContainer1.Panel2.Controls.Add(this.label1);
      this.splitContainer1.Panel2.Controls.Add(this.TB_SavePath);
      this.splitContainer1.Size = new System.Drawing.Size(1844, 84);
      this.splitContainer1.SplitterDistance = 294;
      this.splitContainer1.SplitterWidth = 5;
      this.splitContainer1.TabIndex = 9;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(13, 7);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(108, 17);
      this.label3.TabIndex = 10;
      this.label3.Text = "Режим работы:";
      // 
      // RB_ExistingExperiment
      // 
      this.RB_ExistingExperiment.AutoSize = true;
      this.RB_ExistingExperiment.Location = new System.Drawing.Point(17, 59);
      this.RB_ExistingExperiment.Margin = new System.Windows.Forms.Padding(4);
      this.RB_ExistingExperiment.Name = "RB_ExistingExperiment";
      this.RB_ExistingExperiment.Size = new System.Drawing.Size(209, 21);
      this.RB_ExistingExperiment.TabIndex = 11;
      this.RB_ExistingExperiment.Text = "Проведенный эксперимент";
      this.RB_ExistingExperiment.UseVisualStyleBackColor = true;
      this.RB_ExistingExperiment.CheckedChanged += new System.EventHandler(this.RB_ExistingExperiment_CheckedChanged);
      // 
      // RB_NewExperiment
      // 
      this.RB_NewExperiment.AutoSize = true;
      this.RB_NewExperiment.Checked = true;
      this.RB_NewExperiment.Location = new System.Drawing.Point(17, 31);
      this.RB_NewExperiment.Margin = new System.Windows.Forms.Padding(4);
      this.RB_NewExperiment.Name = "RB_NewExperiment";
      this.RB_NewExperiment.Size = new System.Drawing.Size(161, 21);
      this.RB_NewExperiment.TabIndex = 10;
      this.RB_NewExperiment.TabStop = true;
      this.RB_NewExperiment.Text = "Новый эксперимент";
      this.RB_NewExperiment.UseVisualStyleBackColor = true;
      this.RB_NewExperiment.CheckedChanged += new System.EventHandler(this.RB_NewExperiment_CheckedChanged);
      // 
      // BTN_ExportParametrs
      // 
      this.BTN_ExportParametrs.Location = new System.Drawing.Point(1380, 41);
      this.BTN_ExportParametrs.Margin = new System.Windows.Forms.Padding(4);
      this.BTN_ExportParametrs.Name = "BTN_ExportParametrs";
      this.BTN_ExportParametrs.Size = new System.Drawing.Size(151, 28);
      this.BTN_ExportParametrs.TabIndex = 13;
      this.BTN_ExportParametrs.Text = "Экспорт настроек";
      this.BTN_ExportParametrs.UseVisualStyleBackColor = true;
      this.BTN_ExportParametrs.Click += new System.EventHandler(this.BTN_ExportParametrs_Click);
      // 
      // BTN_ImportParametrs
      // 
      this.BTN_ImportParametrs.Location = new System.Drawing.Point(1380, 4);
      this.BTN_ImportParametrs.Margin = new System.Windows.Forms.Padding(4);
      this.BTN_ImportParametrs.Name = "BTN_ImportParametrs";
      this.BTN_ImportParametrs.Size = new System.Drawing.Size(151, 28);
      this.BTN_ImportParametrs.TabIndex = 12;
      this.BTN_ImportParametrs.Text = "Импорт настроек";
      this.BTN_ImportParametrs.UseVisualStyleBackColor = true;
      this.BTN_ImportParametrs.Click += new System.EventHandler(this.BTN_ImportParametrs_Click);
      // 
      // BTN_ChooseExportFolder
      // 
      this.BTN_ChooseExportFolder.Location = new System.Drawing.Point(1255, 41);
      this.BTN_ChooseExportFolder.Margin = new System.Windows.Forms.Padding(4);
      this.BTN_ChooseExportFolder.Name = "BTN_ChooseExportFolder";
      this.BTN_ChooseExportFolder.Size = new System.Drawing.Size(100, 28);
      this.BTN_ChooseExportFolder.TabIndex = 11;
      this.BTN_ChooseExportFolder.Text = "Выбрать...";
      this.BTN_ChooseExportFolder.UseVisualStyleBackColor = true;
      this.BTN_ChooseExportFolder.Click += new System.EventHandler(this.BTN_ChooseExportFolder_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(27, 41);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(44, 17);
      this.label2.TabIndex = 11;
      this.label2.Text = "Куда:";
      // 
      // BTN_ChooseInputFolder
      // 
      this.BTN_ChooseInputFolder.Location = new System.Drawing.Point(1255, 4);
      this.BTN_ChooseInputFolder.Margin = new System.Windows.Forms.Padding(4);
      this.BTN_ChooseInputFolder.Name = "BTN_ChooseInputFolder";
      this.BTN_ChooseInputFolder.Size = new System.Drawing.Size(100, 28);
      this.BTN_ChooseInputFolder.TabIndex = 10;
      this.BTN_ChooseInputFolder.Text = "Выбрать...";
      this.BTN_ChooseInputFolder.UseVisualStyleBackColor = true;
      this.BTN_ChooseInputFolder.Click += new System.EventHandler(this.BTN_ChooseInputFolder_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(11, 4);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(60, 17);
      this.label1.TabIndex = 10;
      this.label1.Text = "Откуда:";
      // 
      // CB_OverwriteFiles
      // 
      this.CB_OverwriteFiles.AutoSize = true;
      this.CB_OverwriteFiles.Location = new System.Drawing.Point(1620, 106);
      this.CB_OverwriteFiles.Margin = new System.Windows.Forms.Padding(4);
      this.CB_OverwriteFiles.Name = "CB_OverwriteFiles";
      this.CB_OverwriteFiles.Size = new System.Drawing.Size(190, 21);
      this.CB_OverwriteFiles.TabIndex = 10;
      this.CB_OverwriteFiles.Text = "Перезаписывать файлы";
      this.CB_OverwriteFiles.UseVisualStyleBackColor = true;
      this.CB_OverwriteFiles.CheckedChanged += new System.EventHandler(this.CB_OverwriteFiles_CheckedChanged);
      // 
      // BigImageBox
      // 
      this.BigImageBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.BigImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.BigImageBox.Location = new System.Drawing.Point(13, 271);
      this.BigImageBox.Margin = new System.Windows.Forms.Padding(4);
      this.BigImageBox.Name = "BigImageBox";
      this.BigImageBox.Size = new System.Drawing.Size(602, 455);
      this.BigImageBox.TabIndex = 2;
      this.BigImageBox.TabStop = false;
      // 
      // SmallImageBox
      // 
      this.SmallImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.SmallImageBox.Location = new System.Drawing.Point(16, 131);
      this.SmallImageBox.Margin = new System.Windows.Forms.Padding(4);
      this.SmallImageBox.Name = "SmallImageBox";
      this.SmallImageBox.Size = new System.Drawing.Size(172, 130);
      this.SmallImageBox.TabIndex = 2;
      this.SmallImageBox.TabStop = false;
      // 
      // CB_DenoiseMode
      // 
      this.CB_DenoiseMode.FormattingEnabled = true;
      this.CB_DenoiseMode.Location = new System.Drawing.Point(6, 29);
      this.CB_DenoiseMode.Margin = new System.Windows.Forms.Padding(4);
      this.CB_DenoiseMode.Name = "CB_DenoiseMode";
      this.CB_DenoiseMode.Size = new System.Drawing.Size(333, 24);
      this.CB_DenoiseMode.TabIndex = 10;
      this.CB_DenoiseMode.SelectedIndexChanged += new System.EventHandler(this.CB_DenoiseMode_SelectedIndexChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 194);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(202, 17);
      this.label5.TabIndex = 13;
      this.label5.Text = "Выбор режима поиска маски:";
      // 
      // CB_MaskingMode
      // 
      this.CB_MaskingMode.FormattingEnabled = true;
      this.CB_MaskingMode.Location = new System.Drawing.Point(6, 227);
      this.CB_MaskingMode.Margin = new System.Windows.Forms.Padding(4);
      this.CB_MaskingMode.Name = "CB_MaskingMode";
      this.CB_MaskingMode.Size = new System.Drawing.Size(333, 24);
      this.CB_MaskingMode.TabIndex = 12;
      this.CB_MaskingMode.SelectedIndexChanged += new System.EventHandler(this.CB_MaskingMode_SelectedIndexChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 2);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(227, 17);
      this.label4.TabIndex = 11;
      this.label4.Text = "Выбор режима шумоподавления:";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 389F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 544F));
      this.tableLayoutPanel1.Controls.Add(this.label8, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.label9, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.CB_MaskingMode, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.CB_DenoiseMode, 0, 1);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(627, 131);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(935, 377);
      this.tableLayoutPanel1.TabIndex = 14;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(397, 2);
      this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(137, 17);
      this.label8.TabIndex = 25;
      this.label8.Text = "Настройки режима:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(397, 194);
      this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(137, 17);
      this.label9.TabIndex = 26;
      this.label9.Text = "Настройки режима:";
      // 
      // BTN_LoadMask
      // 
      this.BTN_LoadMask.Location = new System.Drawing.Point(1620, 290);
      this.BTN_LoadMask.Margin = new System.Windows.Forms.Padding(4);
      this.BTN_LoadMask.Name = "BTN_LoadMask";
      this.BTN_LoadMask.Size = new System.Drawing.Size(185, 28);
      this.BTN_LoadMask.TabIndex = 15;
      this.BTN_LoadMask.Text = "Загрузить маску";
      this.BTN_LoadMask.UseVisualStyleBackColor = true;
      this.BTN_LoadMask.Click += new System.EventHandler(this.BTN_LoadMask_Click);
      // 
      // BTN_ExportMask
      // 
      this.BTN_ExportMask.Location = new System.Drawing.Point(1620, 325);
      this.BTN_ExportMask.Margin = new System.Windows.Forms.Padding(4);
      this.BTN_ExportMask.Name = "BTN_ExportMask";
      this.BTN_ExportMask.Size = new System.Drawing.Size(185, 28);
      this.BTN_ExportMask.TabIndex = 16;
      this.BTN_ExportMask.Text = "Экспортировать маску";
      this.BTN_ExportMask.UseVisualStyleBackColor = true;
      this.BTN_ExportMask.Click += new System.EventHandler(this.BTN_ExportMask_Click);
      // 
      // BTN_SeeAllMasks
      // 
      this.BTN_SeeAllMasks.Location = new System.Drawing.Point(1620, 361);
      this.BTN_SeeAllMasks.Margin = new System.Windows.Forms.Padding(4);
      this.BTN_SeeAllMasks.Name = "BTN_SeeAllMasks";
      this.BTN_SeeAllMasks.Size = new System.Drawing.Size(185, 28);
      this.BTN_SeeAllMasks.TabIndex = 17;
      this.BTN_SeeAllMasks.Text = "Просмотреть все маски";
      this.BTN_SeeAllMasks.UseVisualStyleBackColor = true;
      this.BTN_SeeAllMasks.Click += new System.EventHandler(this.BTN_SeeAllMasks_Click);
      // 
      // CB_UseCleanFiles
      // 
      this.CB_UseCleanFiles.AutoSize = true;
      this.CB_UseCleanFiles.Location = new System.Drawing.Point(1620, 135);
      this.CB_UseCleanFiles.Margin = new System.Windows.Forms.Padding(4);
      this.CB_UseCleanFiles.Name = "CB_UseCleanFiles";
      this.CB_UseCleanFiles.Size = new System.Drawing.Size(236, 21);
      this.CB_UseCleanFiles.TabIndex = 18;
      this.CB_UseCleanFiles.Text = "Взять готовые \"чистые\" файлы";
      this.CB_UseCleanFiles.UseVisualStyleBackColor = true;
      this.CB_UseCleanFiles.CheckedChanged += new System.EventHandler(this.CB_UseCleanFiles_CheckedChanged);
      // 
      // BTN_EditMask
      // 
      this.BTN_EditMask.Location = new System.Drawing.Point(1620, 254);
      this.BTN_EditMask.Margin = new System.Windows.Forms.Padding(4);
      this.BTN_EditMask.Name = "BTN_EditMask";
      this.BTN_EditMask.Size = new System.Drawing.Size(185, 28);
      this.BTN_EditMask.TabIndex = 19;
      this.BTN_EditMask.Text = "Редактировать вручную";
      this.BTN_EditMask.UseVisualStyleBackColor = true;
      this.BTN_EditMask.Click += new System.EventHandler(this.BTN_EditMask_Click);
      // 
      // CB_RewriteMasks
      // 
      this.CB_RewriteMasks.AutoSize = true;
      this.CB_RewriteMasks.Location = new System.Drawing.Point(1620, 415);
      this.CB_RewriteMasks.Margin = new System.Windows.Forms.Padding(4);
      this.CB_RewriteMasks.Name = "CB_RewriteMasks";
      this.CB_RewriteMasks.Size = new System.Drawing.Size(176, 21);
      this.CB_RewriteMasks.TabIndex = 20;
      this.CB_RewriteMasks.Text = "Пересчитывать маски";
      this.CB_RewriteMasks.UseVisualStyleBackColor = true;
      this.CB_RewriteMasks.CheckedChanged += new System.EventHandler(this.CB_RewriteMasks_CheckedChanged);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(1656, 460);
      this.textBox1.Margin = new System.Windows.Forms.Padding(4);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(132, 22);
      this.textBox1.TabIndex = 21;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(1640, 440);
      this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(122, 17);
      this.label6.TabIndex = 22;
      this.label6.Text = "каждые N кадров";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(1617, 460);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(34, 17);
      this.label7.TabIndex = 23;
      this.label7.Text = "N = ";
      // 
      // ProgressBar
      // 
      this.ProgressBar.Location = new System.Drawing.Point(13, 734);
      this.ProgressBar.Margin = new System.Windows.Forms.Padding(4);
      this.ProgressBar.Name = "ProgressBar";
      this.ProgressBar.Size = new System.Drawing.Size(602, 28);
      this.ProgressBar.TabIndex = 24;
      // 
      // LB_FileProperties
      // 
      this.LB_FileProperties.FormattingEnabled = true;
      this.LB_FileProperties.ItemHeight = 16;
      this.LB_FileProperties.Location = new System.Drawing.Point(207, 131);
      this.LB_FileProperties.Margin = new System.Windows.Forms.Padding(4);
      this.LB_FileProperties.Name = "LB_FileProperties";
      this.LB_FileProperties.Size = new System.Drawing.Size(321, 132);
      this.LB_FileProperties.TabIndex = 26;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(209, 106);
      this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(138, 17);
      this.label10.TabIndex = 27;
      this.label10.Text = "Свойства настроек:";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(13, 106);
      this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(168, 17);
      this.label11.TabIndex = 28;
      this.label11.Text = "Истинное изображение:";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(1863, 911);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.LB_FileProperties);
      this.Controls.Add(this.ProgressBar);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.CB_RewriteMasks);
      this.Controls.Add(this.BTN_EditMask);
      this.Controls.Add(this.CB_UseCleanFiles);
      this.Controls.Add(this.BTN_SeeAllMasks);
      this.Controls.Add(this.CB_OverwriteFiles);
      this.Controls.Add(this.BTN_ExportMask);
      this.Controls.Add(this.BTN_LoadMask);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.SmallImageBox);
      this.Controls.Add(this.BigImageBox);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.BTN_StartProcessing);
      this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.BigImageBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SmallImageBox)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox TB_DataPath;
    private System.Windows.Forms.Button BTN_StartProcessing;
    private System.Windows.Forms.TextBox TB_SavePath;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.RadioButton RB_ExistingExperiment;
    private System.Windows.Forms.RadioButton RB_NewExperiment;
    private System.Windows.Forms.Button BTN_ChooseExportFolder;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button BTN_ChooseInputFolder;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox CB_OverwriteFiles;
    private Emgu.CV.UI.ImageBox BigImageBox;
    private Emgu.CV.UI.ImageBox SmallImageBox;
    private System.Windows.Forms.ComboBox CB_DenoiseMode;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox CB_MaskingMode;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button BTN_ExportParametrs;
    private System.Windows.Forms.Button BTN_ImportParametrs;
    private System.Windows.Forms.Button BTN_LoadMask;
    private System.Windows.Forms.Button BTN_ExportMask;
    private System.Windows.Forms.Button BTN_SeeAllMasks;
    private System.Windows.Forms.CheckBox CB_UseCleanFiles;
    private System.Windows.Forms.Button BTN_EditMask;
    private System.Windows.Forms.CheckBox CB_RewriteMasks;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ProgressBar ProgressBar;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ListBox LB_FileProperties;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    private System.Windows.Forms.Label label11;
  }
}

