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
      this.button1 = new System.Windows.Forms.Button();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.RB_NewExperiment = new System.Windows.Forms.RadioButton();
      this.RB_ExistingExperiment = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.BTN_ChooseInputFolder = new System.Windows.Forms.Button();
      this.BTN_ChooseExportFolder = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.CB_OverwriteFiles = new System.Windows.Forms.CheckBox();
      this.imageBox1 = new Emgu.CV.UI.ImageBox();
      this.imageBox2 = new Emgu.CV.UI.ImageBox();
      this.CB_DenoiseMode = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.CB_MaskingMode = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.BTN_LoadMask = new System.Windows.Forms.Button();
      this.BTN_ExportMask = new System.Windows.Forms.Button();
      this.BTN_SeeAllMasks = new System.Windows.Forms.Button();
      this.CB_UseCleanFiles = new System.Windows.Forms.CheckBox();
      this.BTN_EditMask = new System.Windows.Forms.Button();
      this.CB_RewriteMasks = new System.Windows.Forms.CheckBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.BTN_ImportParametrs = new System.Windows.Forms.Button();
      this.BTN_ExportParametrs = new System.Windows.Forms.Button();
      this.ProgressBar = new System.Windows.Forms.ProgressBar();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // TB_DataPath
      // 
      this.TB_DataPath.Location = new System.Drawing.Point(59, 3);
      this.TB_DataPath.Margin = new System.Windows.Forms.Padding(2);
      this.TB_DataPath.Name = "TB_DataPath";
      this.TB_DataPath.Size = new System.Drawing.Size(877, 20);
      this.TB_DataPath.TabIndex = 0;
      // 
      // BTN_StartProcessing
      // 
      this.BTN_StartProcessing.Location = new System.Drawing.Point(1105, 481);
      this.BTN_StartProcessing.Margin = new System.Windows.Forms.Padding(2);
      this.BTN_StartProcessing.Name = "BTN_StartProcessing";
      this.BTN_StartProcessing.Size = new System.Drawing.Size(56, 19);
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
      this.TB_SavePath.Size = new System.Drawing.Size(877, 20);
      this.TB_SavePath.TabIndex = 7;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(1230, 522);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 8;
      this.button1.Text = "BTN_LoadPlace";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Location = new System.Drawing.Point(12, 10);
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
      this.splitContainer1.Size = new System.Drawing.Size(1383, 68);
      this.splitContainer1.SplitterDistance = 221;
      this.splitContainer1.TabIndex = 9;
      this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
      // 
      // RB_NewExperiment
      // 
      this.RB_NewExperiment.AutoSize = true;
      this.RB_NewExperiment.Checked = true;
      this.RB_NewExperiment.Location = new System.Drawing.Point(13, 25);
      this.RB_NewExperiment.Name = "RB_NewExperiment";
      this.RB_NewExperiment.Size = new System.Drawing.Size(129, 17);
      this.RB_NewExperiment.TabIndex = 10;
      this.RB_NewExperiment.TabStop = true;
      this.RB_NewExperiment.Text = "Новый эксперимент";
      this.RB_NewExperiment.UseVisualStyleBackColor = true;
      // 
      // RB_ExistingExperiment
      // 
      this.RB_ExistingExperiment.AutoSize = true;
      this.RB_ExistingExperiment.Location = new System.Drawing.Point(13, 48);
      this.RB_ExistingExperiment.Name = "RB_ExistingExperiment";
      this.RB_ExistingExperiment.Size = new System.Drawing.Size(165, 17);
      this.RB_ExistingExperiment.TabIndex = 11;
      this.RB_ExistingExperiment.Text = "Проведенный эксперимент";
      this.RB_ExistingExperiment.UseVisualStyleBackColor = true;
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
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(20, 33);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(34, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Куда:";
      // 
      // BTN_ChooseInputFolder
      // 
      this.BTN_ChooseInputFolder.Location = new System.Drawing.Point(941, 3);
      this.BTN_ChooseInputFolder.Name = "BTN_ChooseInputFolder";
      this.BTN_ChooseInputFolder.Size = new System.Drawing.Size(75, 23);
      this.BTN_ChooseInputFolder.TabIndex = 10;
      this.BTN_ChooseInputFolder.Text = "Выбрать...";
      this.BTN_ChooseInputFolder.UseVisualStyleBackColor = true;
      // 
      // BTN_ChooseExportFolder
      // 
      this.BTN_ChooseExportFolder.Location = new System.Drawing.Point(941, 33);
      this.BTN_ChooseExportFolder.Name = "BTN_ChooseExportFolder";
      this.BTN_ChooseExportFolder.Size = new System.Drawing.Size(75, 23);
      this.BTN_ChooseExportFolder.TabIndex = 11;
      this.BTN_ChooseExportFolder.Text = "Выбрать...";
      this.BTN_ChooseExportFolder.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 6);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(85, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "Режим работы:";
      // 
      // CB_OverwriteFiles
      // 
      this.CB_OverwriteFiles.AutoSize = true;
      this.CB_OverwriteFiles.Location = new System.Drawing.Point(1178, 84);
      this.CB_OverwriteFiles.Name = "CB_OverwriteFiles";
      this.CB_OverwriteFiles.Size = new System.Drawing.Size(150, 17);
      this.CB_OverwriteFiles.TabIndex = 10;
      this.CB_OverwriteFiles.Text = "Перезаписывать файлы";
      this.CB_OverwriteFiles.UseVisualStyleBackColor = true;
      // 
      // imageBox1
      // 
      this.imageBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.imageBox1.Location = new System.Drawing.Point(12, 220);
      this.imageBox1.Name = "imageBox1";
      this.imageBox1.Size = new System.Drawing.Size(430, 325);
      this.imageBox1.TabIndex = 2;
      this.imageBox1.TabStop = false;
      // 
      // imageBox2
      // 
      this.imageBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.imageBox2.Location = new System.Drawing.Point(12, 84);
      this.imageBox2.Name = "imageBox2";
      this.imageBox2.Size = new System.Drawing.Size(172, 130);
      this.imageBox2.TabIndex = 2;
      this.imageBox2.TabStop = false;
      // 
      // CB_DenoiseMode
      // 
      this.CB_DenoiseMode.FormattingEnabled = true;
      this.CB_DenoiseMode.Location = new System.Drawing.Point(5, 24);
      this.CB_DenoiseMode.Name = "CB_DenoiseMode";
      this.CB_DenoiseMode.Size = new System.Drawing.Size(251, 21);
      this.CB_DenoiseMode.TabIndex = 10;
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
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
      this.tableLayoutPanel1.Controls.Add(this.CB_MaskingMode, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.CB_DenoiseMode, 0, 1);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(460, 107);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(701, 306);
      this.tableLayoutPanel1.TabIndex = 14;
      // 
      // BTN_LoadMask
      // 
      this.BTN_LoadMask.Location = new System.Drawing.Point(1178, 233);
      this.BTN_LoadMask.Name = "BTN_LoadMask";
      this.BTN_LoadMask.Size = new System.Drawing.Size(139, 23);
      this.BTN_LoadMask.TabIndex = 15;
      this.BTN_LoadMask.Text = "Загрузить маску";
      this.BTN_LoadMask.UseVisualStyleBackColor = true;
      // 
      // BTN_ExportMask
      // 
      this.BTN_ExportMask.Location = new System.Drawing.Point(1178, 262);
      this.BTN_ExportMask.Name = "BTN_ExportMask";
      this.BTN_ExportMask.Size = new System.Drawing.Size(139, 23);
      this.BTN_ExportMask.TabIndex = 16;
      this.BTN_ExportMask.Text = "Экспортировать маску";
      this.BTN_ExportMask.UseVisualStyleBackColor = true;
      // 
      // BTN_SeeAllMasks
      // 
      this.BTN_SeeAllMasks.Location = new System.Drawing.Point(1178, 291);
      this.BTN_SeeAllMasks.Name = "BTN_SeeAllMasks";
      this.BTN_SeeAllMasks.Size = new System.Drawing.Size(139, 23);
      this.BTN_SeeAllMasks.TabIndex = 17;
      this.BTN_SeeAllMasks.Text = "Просмотреть все маски";
      this.BTN_SeeAllMasks.UseVisualStyleBackColor = true;
      // 
      // CB_UseCleanFiles
      // 
      this.CB_UseCleanFiles.AutoSize = true;
      this.CB_UseCleanFiles.Location = new System.Drawing.Point(1178, 107);
      this.CB_UseCleanFiles.Name = "CB_UseCleanFiles";
      this.CB_UseCleanFiles.Size = new System.Drawing.Size(187, 17);
      this.CB_UseCleanFiles.TabIndex = 18;
      this.CB_UseCleanFiles.Text = "Взять готовые \"чистые\" файлы";
      this.CB_UseCleanFiles.UseVisualStyleBackColor = true;
      // 
      // BTN_EditMask
      // 
      this.BTN_EditMask.Location = new System.Drawing.Point(1178, 204);
      this.BTN_EditMask.Name = "BTN_EditMask";
      this.BTN_EditMask.Size = new System.Drawing.Size(139, 23);
      this.BTN_EditMask.TabIndex = 19;
      this.BTN_EditMask.Text = "Редактировать вручную";
      this.BTN_EditMask.UseVisualStyleBackColor = true;
      // 
      // CB_RewriteMasks
      // 
      this.CB_RewriteMasks.AutoSize = true;
      this.CB_RewriteMasks.Location = new System.Drawing.Point(1178, 335);
      this.CB_RewriteMasks.Name = "CB_RewriteMasks";
      this.CB_RewriteMasks.Size = new System.Drawing.Size(140, 17);
      this.CB_RewriteMasks.TabIndex = 20;
      this.CB_RewriteMasks.Text = "Пересчитывать маски";
      this.CB_RewriteMasks.UseVisualStyleBackColor = true;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(1205, 371);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 20);
      this.textBox1.TabIndex = 21;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(1193, 355);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(97, 13);
      this.label6.TabIndex = 22;
      this.label6.Text = "каждые N кадров";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(1175, 374);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(27, 13);
      this.label7.TabIndex = 23;
      this.label7.Text = "N = ";
      // 
      // BTN_ImportParametrs
      // 
      this.BTN_ImportParametrs.Location = new System.Drawing.Point(1035, 3);
      this.BTN_ImportParametrs.Name = "BTN_ImportParametrs";
      this.BTN_ImportParametrs.Size = new System.Drawing.Size(113, 23);
      this.BTN_ImportParametrs.TabIndex = 12;
      this.BTN_ImportParametrs.Text = "Импорт настроек";
      this.BTN_ImportParametrs.UseVisualStyleBackColor = true;
      // 
      // BTN_ExportParametrs
      // 
      this.BTN_ExportParametrs.Location = new System.Drawing.Point(1035, 33);
      this.BTN_ExportParametrs.Name = "BTN_ExportParametrs";
      this.BTN_ExportParametrs.Size = new System.Drawing.Size(113, 23);
      this.BTN_ExportParametrs.TabIndex = 13;
      this.BTN_ExportParametrs.Text = "Экспорт настроек";
      this.BTN_ExportParametrs.UseVisualStyleBackColor = true;
      // 
      // ProgressBar
      // 
      this.ProgressBar.Location = new System.Drawing.Point(12, 551);
      this.ProgressBar.Name = "ProgressBar";
      this.ProgressBar.Size = new System.Drawing.Size(430, 23);
      this.ProgressBar.TabIndex = 24;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(1397, 740);
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
      this.Controls.Add(this.imageBox2);
      this.Controls.Add(this.imageBox1);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.BTN_StartProcessing);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "Form1";
      this.Text = "Form1";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox TB_DataPath;
    private System.Windows.Forms.Button BTN_StartProcessing;
    private System.Windows.Forms.TextBox TB_SavePath;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.RadioButton RB_ExistingExperiment;
    private System.Windows.Forms.RadioButton RB_NewExperiment;
    private System.Windows.Forms.Button BTN_ChooseExportFolder;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button BTN_ChooseInputFolder;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox CB_OverwriteFiles;
    private Emgu.CV.UI.ImageBox imageBox1;
    private Emgu.CV.UI.ImageBox imageBox2;
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
  }
}

