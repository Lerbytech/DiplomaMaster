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
      this.IB_SourceIMG = new Emgu.CV.UI.ImageBox();
      this.IB_Denoised = new Emgu.CV.UI.ImageBox();
      this.IB_InitMask = new Emgu.CV.UI.ImageBox();
      this.IB_Contours = new Emgu.CV.UI.ImageBox();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.TB_SavePath = new System.Windows.Forms.TextBox();
      this.zedGraphControl = new ZedGraph.ZedGraphControl();
      ((System.ComponentModel.ISupportInitialize)(this.IB_SourceIMG)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.IB_Denoised)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.IB_InitMask)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.IB_Contours)).BeginInit();
      this.SuspendLayout();
      // 
      // TB_DataPath
      // 
      this.TB_DataPath.Location = new System.Drawing.Point(81, 12);
      this.TB_DataPath.Name = "TB_DataPath";
      this.TB_DataPath.Size = new System.Drawing.Size(856, 22);
      this.TB_DataPath.TabIndex = 0;
      // 
      // BTN_StartProcessing
      // 
      this.BTN_StartProcessing.Location = new System.Drawing.Point(954, 12);
      this.BTN_StartProcessing.Name = "BTN_StartProcessing";
      this.BTN_StartProcessing.Size = new System.Drawing.Size(75, 23);
      this.BTN_StartProcessing.TabIndex = 1;
      this.BTN_StartProcessing.Text = "Process";
      this.BTN_StartProcessing.UseVisualStyleBackColor = true;
      this.BTN_StartProcessing.Click += new System.EventHandler(this.BTN_StartProcessing_Click);
      // 
      // IB_SourceIMG
      // 
      this.IB_SourceIMG.Location = new System.Drawing.Point(24, 86);
      this.IB_SourceIMG.Name = "IB_SourceIMG";
      this.IB_SourceIMG.Size = new System.Drawing.Size(344, 260);
      this.IB_SourceIMG.TabIndex = 2;
      this.IB_SourceIMG.TabStop = false;
      // 
      // IB_Denoised
      // 
      this.IB_Denoised.Location = new System.Drawing.Point(374, 86);
      this.IB_Denoised.Name = "IB_Denoised";
      this.IB_Denoised.Size = new System.Drawing.Size(344, 260);
      this.IB_Denoised.TabIndex = 3;
      this.IB_Denoised.TabStop = false;
      // 
      // IB_InitMask
      // 
      this.IB_InitMask.Location = new System.Drawing.Point(724, 86);
      this.IB_InitMask.Name = "IB_InitMask";
      this.IB_InitMask.Size = new System.Drawing.Size(344, 260);
      this.IB_InitMask.TabIndex = 4;
      this.IB_InitMask.TabStop = false;
      // 
      // IB_Contours
      // 
      this.IB_Contours.Location = new System.Drawing.Point(24, 352);
      this.IB_Contours.Name = "IB_Contours";
      this.IB_Contours.Size = new System.Drawing.Size(344, 260);
      this.IB_Contours.TabIndex = 5;
      this.IB_Contours.TabStop = false;
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 16;
      this.listBox1.Location = new System.Drawing.Point(374, 352);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(694, 260);
      this.listBox1.TabIndex = 6;
      // 
      // TB_SavePath
      // 
      this.TB_SavePath.Location = new System.Drawing.Point(81, 40);
      this.TB_SavePath.Name = "TB_SavePath";
      this.TB_SavePath.Size = new System.Drawing.Size(856, 22);
      this.TB_SavePath.TabIndex = 7;
      // 
      // zedGraphControl
      // 
      this.zedGraphControl.Location = new System.Drawing.Point(13, 67);
      this.zedGraphControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.zedGraphControl.Name = "zedGraphControl";
      this.zedGraphControl.ScrollGrace = 0D;
      this.zedGraphControl.ScrollMaxX = 0D;
      this.zedGraphControl.ScrollMaxY = 0D;
      this.zedGraphControl.ScrollMaxY2 = 0D;
      this.zedGraphControl.ScrollMinX = 0D;
      this.zedGraphControl.ScrollMinY = 0D;
      this.zedGraphControl.ScrollMinY2 = 0D;
      this.zedGraphControl.Size = new System.Drawing.Size(1055, 545);
      this.zedGraphControl.TabIndex = 8;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1075, 628);
      this.Controls.Add(this.zedGraphControl);
      this.Controls.Add(this.TB_SavePath);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.IB_Contours);
      this.Controls.Add(this.IB_InitMask);
      this.Controls.Add(this.IB_Denoised);
      this.Controls.Add(this.IB_SourceIMG);
      this.Controls.Add(this.BTN_StartProcessing);
      this.Controls.Add(this.TB_DataPath);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.IB_SourceIMG)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.IB_Denoised)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.IB_InitMask)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.IB_Contours)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox TB_DataPath;
    private System.Windows.Forms.Button BTN_StartProcessing;
    private Emgu.CV.UI.ImageBox IB_SourceIMG;
    private Emgu.CV.UI.ImageBox IB_Denoised;
    private Emgu.CV.UI.ImageBox IB_InitMask;
    private Emgu.CV.UI.ImageBox IB_Contours;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.TextBox TB_SavePath;
    private ZedGraph.ZedGraphControl zedGraphControl;
  }
}

