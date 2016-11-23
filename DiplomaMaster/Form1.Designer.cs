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
      this.BTN_ChooseInputFolder = new System.Windows.Forms.Button();
      this.BTN_ChooseExportFolder = new System.Windows.Forms.Button();
      this.BTN_ExportParametrs = new System.Windows.Forms.Button();
      this.BTN_ImportParametrs = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.CB_OverwriteFiles = new System.Windows.Forms.CheckBox();
      this.BigImageBox = new Emgu.CV.UI.ImageBox();
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
      this.CB_RecalcMasks = new System.Windows.Forms.CheckBox();
      this.TB_RecalcMasksRate = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.ProgressBar = new System.Windows.Forms.ProgressBar();
      this.LB_FileProperties = new System.Windows.Forms.ListBox();
      this.label10 = new System.Windows.Forms.Label();
      this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.MaskImageBox = new Emgu.CV.UI.ImageBox();
      this.AugImageBox = new Emgu.CV.UI.ImageBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.CB_UseDenoiseOnly = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.BigImageBox)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.MaskImageBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.AugImageBox)).BeginInit();
      this.SuspendLayout();
      // 
      // TB_DataPath
      // 
      this.TB_DataPath.Location = new System.Drawing.Point(59, 3);
      this.TB_DataPath.Margin = new System.Windows.Forms.Padding(2);
      this.TB_DataPath.Name = "TB_DataPath";
      this.TB_DataPath.Size = new System.Drawing.Size(1078, 20);
      this.TB_DataPath.TabIndex = 0;
      // 
      // BTN_StartProcessing
      // 
      this.BTN_StartProcessing.Location = new System.Drawing.Point(1209, 375);
      this.BTN_StartProcessing.Margin = new System.Windows.Forms.Padding(2);
      this.BTN_StartProcessing.Name = "BTN_StartProcessing";
      this.BTN_StartProcessing.Size = new System.Drawing.Size(68, 29);
      this.BTN_StartProcessing.TabIndex = 1;
      this.BTN_StartProcessing.Text = "Process";
      this.BTN_StartProcessing.UseVisualStyleBackColor = true;
      this.BTN_StartProcessing.Click += new System.EventHandler(this.BTN_StartProcessing_Click);
      // 
      // TB_SavePath
      // 
      this.TB_SavePath.Location = new System.Drawing.Point(59, 33);
      this.TB_SavePath.Margin = new System.Windows.Forms.Padding(2);
      this.TB_SavePath.Name = "TB_SavePath";
      this.TB_SavePath.Size = new System.Drawing.Size(1078, 20);
      this.TB_SavePath.TabIndex = 7;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Location = new System.Drawing.Point(12, 10);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.BTN_ChooseInputFolder);
      this.splitContainer1.Panel1.Controls.Add(this.BTN_ChooseExportFolder);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.BTN_ExportParametrs);
      this.splitContainer1.Panel2.Controls.Add(this.BTN_ImportParametrs);
      this.splitContainer1.Panel2.Controls.Add(this.label2);
      this.splitContainer1.Panel2.Controls.Add(this.TB_DataPath);
      this.splitContainer1.Panel2.Controls.Add(this.label1);
      this.splitContainer1.Panel2.Controls.Add(this.TB_SavePath);
      this.splitContainer1.Size = new System.Drawing.Size(1383, 68);
      this.splitContainer1.SplitterDistance = 87;
      this.splitContainer1.TabIndex = 9;
      // 
      // BTN_ChooseInputFolder
      // 
      this.BTN_ChooseInputFolder.Location = new System.Drawing.Point(3, 3);
      this.BTN_ChooseInputFolder.Name = "BTN_ChooseInputFolder";
      this.BTN_ChooseInputFolder.Size = new System.Drawing.Size(75, 23);
      this.BTN_ChooseInputFolder.TabIndex = 10;
      this.BTN_ChooseInputFolder.Text = "Выбрать...";
      this.BTN_ChooseInputFolder.UseVisualStyleBackColor = true;
      this.BTN_ChooseInputFolder.Click += new System.EventHandler(this.BTN_ChooseInputFolder_Click);
      // 
      // BTN_ChooseExportFolder
      // 
      this.BTN_ChooseExportFolder.Location = new System.Drawing.Point(3, 33);
      this.BTN_ChooseExportFolder.Name = "BTN_ChooseExportFolder";
      this.BTN_ChooseExportFolder.Size = new System.Drawing.Size(75, 23);
      this.BTN_ChooseExportFolder.TabIndex = 11;
      this.BTN_ChooseExportFolder.Text = "Выбрать...";
      this.BTN_ChooseExportFolder.UseVisualStyleBackColor = true;
      this.BTN_ChooseExportFolder.Click += new System.EventHandler(this.BTN_ChooseExportFolder_Click);
      // 
      // BTN_ExportParametrs
      // 
      this.BTN_ExportParametrs.Location = new System.Drawing.Point(1169, 31);
      this.BTN_ExportParametrs.Name = "BTN_ExportParametrs";
      this.BTN_ExportParametrs.Size = new System.Drawing.Size(113, 23);
      this.BTN_ExportParametrs.TabIndex = 13;
      this.BTN_ExportParametrs.Text = "Экспорт настроек";
      this.BTN_ExportParametrs.UseVisualStyleBackColor = true;
      this.BTN_ExportParametrs.Click += new System.EventHandler(this.BTN_ExportParametrs_Click);
      // 
      // BTN_ImportParametrs
      // 
      this.BTN_ImportParametrs.Location = new System.Drawing.Point(1169, 3);
      this.BTN_ImportParametrs.Name = "BTN_ImportParametrs";
      this.BTN_ImportParametrs.Size = new System.Drawing.Size(113, 23);
      this.BTN_ImportParametrs.TabIndex = 12;
      this.BTN_ImportParametrs.Text = "Импорт настроек";
      this.BTN_ImportParametrs.UseVisualStyleBackColor = true;
      this.BTN_ImportParametrs.Click += new System.EventHandler(this.BTN_ImportParametrs_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(20, 33);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(34, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Куда:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(46, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "Откуда:";
      // 
      // CB_OverwriteFiles
      // 
      this.CB_OverwriteFiles.AutoSize = true;
      this.CB_OverwriteFiles.Location = new System.Drawing.Point(1198, 86);
      this.CB_OverwriteFiles.Name = "CB_OverwriteFiles";
      this.CB_OverwriteFiles.Size = new System.Drawing.Size(150, 17);
      this.CB_OverwriteFiles.TabIndex = 10;
      this.CB_OverwriteFiles.Text = "Перезаписывать файлы";
      this.CB_OverwriteFiles.UseVisualStyleBackColor = true;
      this.CB_OverwriteFiles.CheckedChanged += new System.EventHandler(this.CB_OverwriteFiles_CheckedChanged);
      // 
      // BigImageBox
      // 
      this.BigImageBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.BigImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.BigImageBox.Location = new System.Drawing.Point(10, 426);
      this.BigImageBox.Name = "BigImageBox";
      this.BigImageBox.Size = new System.Drawing.Size(452, 370);
      this.BigImageBox.TabIndex = 2;
      this.BigImageBox.TabStop = false;
      // 
      // CB_DenoiseMode
      // 
      this.CB_DenoiseMode.FormattingEnabled = true;
      this.CB_DenoiseMode.Location = new System.Drawing.Point(5, 24);
      this.CB_DenoiseMode.Name = "CB_DenoiseMode";
      this.CB_DenoiseMode.Size = new System.Drawing.Size(251, 21);
      this.CB_DenoiseMode.TabIndex = 10;
      this.CB_DenoiseMode.SelectedIndexChanged += new System.EventHandler(this.CB_DenoiseMode_SelectedIndexChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(5, 159);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(160, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "Выбор режима поиска маски:";
      // 
      // CB_MaskingMode
      // 
      this.CB_MaskingMode.FormattingEnabled = true;
      this.CB_MaskingMode.Location = new System.Drawing.Point(5, 186);
      this.CB_MaskingMode.Name = "CB_MaskingMode";
      this.CB_MaskingMode.Size = new System.Drawing.Size(251, 21);
      this.CB_MaskingMode.TabIndex = 12;
      this.CB_MaskingMode.SelectedIndexChanged += new System.EventHandler(this.CB_MaskingMode_SelectedIndexChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(5, 2);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(176, 13);
      this.label4.TabIndex = 11;
      this.label4.Text = "Выбор режима шумоподавления:";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 292F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 418F));
      this.tableLayoutPanel1.Controls.Add(this.label8, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.label9, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.CB_MaskingMode, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.CB_DenoiseMode, 0, 1);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(470, 88);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(701, 306);
      this.tableLayoutPanel1.TabIndex = 14;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(299, 2);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(108, 13);
      this.label8.TabIndex = 25;
      this.label8.Text = "Настройки режима:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(299, 159);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(108, 13);
      this.label9.TabIndex = 26;
      this.label9.Text = "Настройки режима:";
      // 
      // BTN_LoadMask
      // 
      this.BTN_LoadMask.Location = new System.Drawing.Point(1209, 193);
      this.BTN_LoadMask.Name = "BTN_LoadMask";
      this.BTN_LoadMask.Size = new System.Drawing.Size(139, 23);
      this.BTN_LoadMask.TabIndex = 15;
      this.BTN_LoadMask.Text = "Загрузить маску";
      this.BTN_LoadMask.UseVisualStyleBackColor = true;
      this.BTN_LoadMask.Click += new System.EventHandler(this.BTN_LoadMask_Click);
      // 
      // BTN_ExportMask
      // 
      this.BTN_ExportMask.Location = new System.Drawing.Point(1209, 221);
      this.BTN_ExportMask.Name = "BTN_ExportMask";
      this.BTN_ExportMask.Size = new System.Drawing.Size(139, 23);
      this.BTN_ExportMask.TabIndex = 16;
      this.BTN_ExportMask.Text = "Экспортировать маску";
      this.BTN_ExportMask.UseVisualStyleBackColor = true;
      this.BTN_ExportMask.Click += new System.EventHandler(this.BTN_ExportMask_Click);
      // 
      // BTN_SeeAllMasks
      // 
      this.BTN_SeeAllMasks.Location = new System.Drawing.Point(1209, 250);
      this.BTN_SeeAllMasks.Name = "BTN_SeeAllMasks";
      this.BTN_SeeAllMasks.Size = new System.Drawing.Size(139, 23);
      this.BTN_SeeAllMasks.TabIndex = 17;
      this.BTN_SeeAllMasks.Text = "Просмотреть все маски";
      this.BTN_SeeAllMasks.UseVisualStyleBackColor = true;
      this.BTN_SeeAllMasks.Click += new System.EventHandler(this.BTN_SeeAllMasks_Click);
      // 
      // CB_UseCleanFiles
      // 
      this.CB_UseCleanFiles.AutoSize = true;
      this.CB_UseCleanFiles.Location = new System.Drawing.Point(1198, 109);
      this.CB_UseCleanFiles.Name = "CB_UseCleanFiles";
      this.CB_UseCleanFiles.Size = new System.Drawing.Size(187, 17);
      this.CB_UseCleanFiles.TabIndex = 18;
      this.CB_UseCleanFiles.Text = "Взять готовые \"чистые\" файлы";
      this.CB_UseCleanFiles.UseVisualStyleBackColor = true;
      this.CB_UseCleanFiles.CheckedChanged += new System.EventHandler(this.CB_UseCleanFiles_CheckedChanged);
      // 
      // BTN_EditMask
      // 
      this.BTN_EditMask.Location = new System.Drawing.Point(1209, 163);
      this.BTN_EditMask.Name = "BTN_EditMask";
      this.BTN_EditMask.Size = new System.Drawing.Size(139, 23);
      this.BTN_EditMask.TabIndex = 19;
      this.BTN_EditMask.Text = "Редактировать вручную";
      this.BTN_EditMask.UseVisualStyleBackColor = true;
      this.BTN_EditMask.Click += new System.EventHandler(this.BTN_EditMask_Click);
      // 
      // CB_RecalcMasks
      // 
      this.CB_RecalcMasks.AutoSize = true;
      this.CB_RecalcMasks.Location = new System.Drawing.Point(1209, 294);
      this.CB_RecalcMasks.Name = "CB_RecalcMasks";
      this.CB_RecalcMasks.Size = new System.Drawing.Size(140, 17);
      this.CB_RecalcMasks.TabIndex = 20;
      this.CB_RecalcMasks.Text = "Пересчитывать маски";
      this.CB_RecalcMasks.UseVisualStyleBackColor = true;
      this.CB_RecalcMasks.CheckedChanged += new System.EventHandler(this.CB_RecalcMasks_CheckedChanged);
      // 
      // TB_RecalcMasksRate
      // 
      this.TB_RecalcMasksRate.Enabled = false;
      this.TB_RecalcMasksRate.Location = new System.Drawing.Point(1236, 331);
      this.TB_RecalcMasksRate.Name = "TB_RecalcMasksRate";
      this.TB_RecalcMasksRate.Size = new System.Drawing.Size(100, 20);
      this.TB_RecalcMasksRate.TabIndex = 21;
      this.TB_RecalcMasksRate.TextChanged += new System.EventHandler(this.TB_RecalcMasksRate_TextChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(1224, 315);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(97, 13);
      this.label6.TabIndex = 22;
      this.label6.Text = "каждые N кадров";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(1207, 331);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(27, 13);
      this.label7.TabIndex = 23;
      this.label7.Text = "N = ";
      // 
      // ProgressBar
      // 
      this.ProgressBar.Location = new System.Drawing.Point(10, 364);
      this.ProgressBar.Name = "ProgressBar";
      this.ProgressBar.Size = new System.Drawing.Size(452, 23);
      this.ProgressBar.TabIndex = 24;
      // 
      // LB_FileProperties
      // 
      this.LB_FileProperties.FormattingEnabled = true;
      this.LB_FileProperties.Location = new System.Drawing.Point(10, 107);
      this.LB_FileProperties.Name = "LB_FileProperties";
      this.LB_FileProperties.Size = new System.Drawing.Size(452, 251);
      this.LB_FileProperties.TabIndex = 26;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(9, 88);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(108, 13);
      this.label10.TabIndex = 27;
      this.label10.Text = "Свойства настроек:";
      // 
      // MaskImageBox
      // 
      this.MaskImageBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.MaskImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.MaskImageBox.Location = new System.Drawing.Point(475, 426);
      this.MaskImageBox.Name = "MaskImageBox";
      this.MaskImageBox.Size = new System.Drawing.Size(452, 370);
      this.MaskImageBox.TabIndex = 28;
      this.MaskImageBox.TabStop = false;
      // 
      // AugImageBox
      // 
      this.AugImageBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.AugImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.AugImageBox.Location = new System.Drawing.Point(943, 426);
      this.AugImageBox.Name = "AugImageBox";
      this.AugImageBox.Size = new System.Drawing.Size(452, 370);
      this.AugImageBox.TabIndex = 29;
      this.AugImageBox.TabStop = false;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 407);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(130, 13);
      this.label3.TabIndex = 30;
      this.label3.Text = "Исходное изображение:";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(475, 407);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(43, 13);
      this.label11.TabIndex = 31;
      this.label11.Text = "Маска:";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(943, 407);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(177, 13);
      this.label12.TabIndex = 32;
      this.label12.Text = "Аугментированное изображение:";
      // 
      // CB_UseDenoiseOnly
      // 
      this.CB_UseDenoiseOnly.AutoSize = true;
      this.CB_UseDenoiseOnly.Location = new System.Drawing.Point(1198, 132);
      this.CB_UseDenoiseOnly.Name = "CB_UseDenoiseOnly";
      this.CB_UseDenoiseOnly.Size = new System.Drawing.Size(206, 17);
      this.CB_UseDenoiseOnly.TabIndex = 33;
      this.CB_UseDenoiseOnly.Text = "Запустить только шумоподавление";
      this.CB_UseDenoiseOnly.UseVisualStyleBackColor = true;
      this.CB_UseDenoiseOnly.CheckedChanged += new System.EventHandler(this.CB_UseDenoiseOnly_CheckedChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(1404, 810);
      this.Controls.Add(this.CB_UseDenoiseOnly);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.AugImageBox);
      this.Controls.Add(this.MaskImageBox);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.LB_FileProperties);
      this.Controls.Add(this.ProgressBar);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.TB_RecalcMasksRate);
      this.Controls.Add(this.CB_RecalcMasks);
      this.Controls.Add(this.BTN_EditMask);
      this.Controls.Add(this.CB_UseCleanFiles);
      this.Controls.Add(this.BTN_SeeAllMasks);
      this.Controls.Add(this.CB_OverwriteFiles);
      this.Controls.Add(this.BTN_ExportMask);
      this.Controls.Add(this.BTN_LoadMask);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.BigImageBox);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.BTN_StartProcessing);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.BigImageBox)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.MaskImageBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.AugImageBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox TB_DataPath;
    private System.Windows.Forms.Button BTN_StartProcessing;
    private System.Windows.Forms.TextBox TB_SavePath;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Button BTN_ChooseExportFolder;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button BTN_ChooseInputFolder;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox CB_OverwriteFiles;
    private Emgu.CV.UI.ImageBox BigImageBox;
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
    private System.Windows.Forms.CheckBox CB_RecalcMasks;
    private System.Windows.Forms.TextBox TB_RecalcMasksRate;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ProgressBar ProgressBar;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ListBox LB_FileProperties;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    private Emgu.CV.UI.ImageBox MaskImageBox;
    private Emgu.CV.UI.ImageBox AugImageBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.CheckBox CB_UseDenoiseOnly;
  }
}

